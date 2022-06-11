using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace FileFinder
{
    using _CFG = Properties.Settings;
    using _RES = Properties.Resources;

    public partial class FormFinder : Form
    {
        const int MAX_DEPTH = 5;
        const double MAX_DIR_SIZE = 5 * MB;
        const double MIN_FILE_SIZE = 5 * MB;
        const double MB = 1024*1024;
        
        TreeNode Root;
        double total_size=  0;
        double total_count= 0;
        double total_dir=   0;
        double total_same=   0;

        List<ListView> Lview = new List<ListView>();

        bool[] Config = new bool[CONFIG_INDEX.SIZE];
        public static class IMAGE
        {
            public const int FOLDER=0;
            public const int FILE=  1;
            public const int PHOTO= 2;
            public const int VIDEO= 3;
            public const int PLAY=  4;
            public const int PLAY2= 5;
            public const int PLAY3= 6;
            public const int PLAY4= 7;
            public const int MKV=   8;
            public const int FINDER=9;
            public const int FINDER2=10;
        };

        public static class CONFIG_INDEX
        {
            public const int ALLFILE = 0; //하위 폴더 파일 보기 1-보기, 0-안보기
            public const int DELFILE = 1; //중복 파일만 보기 1-보기, 0-안보기
            public const int MINFILE = 2; //최저용량 이하 파일 가리기 1-가리기 0-안가리기

            public const int SIZE = 3;
        };

        public static Color[] ListColors = new Color[]
        {
            Color.Silver, Color.White, Color.Gainsboro
        };

        public FormFinder()
        {
            InitializeComponent();
        }

        private void FormFinder_Load(object sender, EventArgs e)
        {
            ImageList iconList = new ImageList();
            iconList.Images.Add(_RES.folder_icon);
            iconList.Images.Add(_RES.file_icon);
            iconList.Images.Add(_RES.photo_icon);
            iconList.Images.Add(_RES.video_icon);
            iconList.Images.Add(_RES.play_icon);
            iconList.Images.Add(_RES.play_icon2);
            iconList.Images.Add(_RES.play_icon3);
            iconList.Images.Add(_RES.play_icon4);
            iconList.Images.Add(_RES.mkv_icon);
            iconList.Images.Add(_RES.finder);
            iconList.Images.Add(_RES.finder2);

            listViewDirinfo.View = View.Details;
            listViewDirinfo.Scrollable = true;
            listViewDirinfo.GridLines = true;
            listViewDirinfo.Items[0].SubItems.Add(total_size.ToString());
            listViewDirinfo.Items[1].SubItems.Add(total_count.ToString());
            listViewDirinfo.Items[2].SubItems.Add(total_dir.ToString());
            listViewDirinfo.Items[3].SubItems.Add(total_same.ToString());
            listViewDirinfo.Items[4].SubItems.Add("5 Depth");
            listViewDirinfo.Items[5].SubItems.Add("같은 크기만");
            listViewDirinfo.Items[6].SubItems.Add("5MB 이상");
          
            treeViewFile.ImageList = iconList;

            Lview.Add(listView_L);
            Lview.Add(listView_R);

            button_L.ImageList = iconList;
            button_L.ImageIndex = IMAGE.FINDER2;
            button_R.ImageList = iconList;
            button_R.ImageIndex = IMAGE.FINDER2;

            foreach ( ListView lv in Lview )
            {
                lv.View = View.Details;
                lv.Scrollable = true;
                lv.GridLines = true;
                lv.FullRowSelect = true;
                lv.StateImageList = iconList;
                lv.ListViewItemSorter = new ListviewItemComparer(0, "desc");
            }

            //Load Config
            Config[CONFIG_INDEX.ALLFILE] = _CFG.Default.AllFile;
            Config[CONFIG_INDEX.DELFILE] = _CFG.Default.DelFile;
            Config[CONFIG_INDEX.MINFILE] = _CFG.Default.MinFile;
            this.textBox_L.Text = _CFG.Default.FilePath_L;
            this.textBox_R.Text = _CFG.Default.FilePath_R;

            //0.용량 1.파일수 2.폴더수 3.중복파일수
            listViewDirinfo.Items[4].Checked = Config[CONFIG_INDEX.ALLFILE];
            listViewDirinfo.Items[5].Checked = Config[CONFIG_INDEX.DELFILE];
            listViewDirinfo.Items[6].Checked = Config[CONFIG_INDEX.MINFILE];

            listViewDirinfo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void InitFileTree(string FilePath)
        {
            if (!Directory.Exists(FilePath))
            {
                Message("폴더가 존재하지 않습니다.", "알림");
                return;
            }
            Root = new TreeNode();
            Root.Text = FilePath;
            Root.SelectedImageIndex = Root.ImageIndex = IMAGE.FOLDER;
            Root.Tag = new DirectoryInfo(FilePath);

            AddChild(Root);

            treeViewFile.Nodes.Add(Root);
            treeViewFile.ExpandAll();
            treeViewFile.SelectedNode = Root;
        }

        private void AddChild(TreeNode parent)
        {
            DirectoryInfo di = (DirectoryInfo)parent.Tag;
            try
            {
                foreach (DirectoryInfo Di in di.GetDirectories())
                {
                    if (SkipOSDir(Di.Name))
                        continue;
                    TreeNode child_node = new TreeNode();
                    child_node.Text = Di.Name;
                    child_node.SelectedImageIndex = child_node.ImageIndex = IMAGE.FOLDER;
                    child_node.Tag = Di;
                    parent.Nodes.Add(child_node);
                }

                foreach (FileInfo File in di.GetFiles())
                {
                    TreeNode child_node = new TreeNode();
                    child_node.Text = File.Name;
                    child_node.SelectedImageIndex = child_node.ImageIndex = GetIconIndex(File.Extension);
                    child_node.Tag = File;
                    parent.Nodes.Add(child_node);
                }
            }
            catch
            {
                //권한 없음 예외
            }

        }

        private void FileList_Clear(ListView lv)
        {
            lv.Items.Clear();
            lv.Clear();
            lv.Columns.Add("크기(MB)▼", -2, HorizontalAlignment.Right);
            lv.Columns.Add("파일명", -2, HorizontalAlignment.Left);
            lv.Columns.Add("유형", 50, HorizontalAlignment.Left);
            
            total_count = total_size = 0;
            total_same = total_dir = 0;
        }

        private void treeViewFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FileList_Clear(listView_L);
            TreeNode sel_node = treeViewFile.SelectedNode;
            try
            {
                if (sel_node.SelectedImageIndex == IMAGE.FOLDER)
                {
                    DirectoryInfo di = (DirectoryInfo)sel_node.Tag;
                    foreach (FileInfo File in di.GetFiles())
                    {
                        AddFileList(File, listView_L);
                    }
                    if (Config[CONFIG_INDEX.ALLFILE])
                    {
                        foreach (DirectoryInfo Di in di.GetDirectories())
                        {
                            if (SkipOSDir(Di.Name))
                                continue;
                            AddDirList(Di, MAX_DEPTH, listView_L);
                            total_dir++;
                        }
                    }
                }
                else
                {
                    AddFileList((FileInfo)sel_node.Tag, listView_L);
                }
            }
            catch
            {
                //권한 없음 예외
            }
            listView_L.Sort();
            listViewSetCol(listView_L);
        }
        
        private void AddFileList(FileInfo File, ListView lv)
        {
            if (Config[CONFIG_INDEX.MINFILE])
                if (File.Length < MIN_FILE_SIZE)
                    return;
            List<string> filestate = new List<string>();
            
            filestate.Add((File.Length / MB).ToString("F4"));
            filestate.Add(File.Name);
            filestate.Add(File.Extension);
            ListViewItem fileitem = new ListViewItem(filestate.ToArray());
            fileitem.StateImageIndex = GetIconIndex(File.Extension);
            fileitem.Tag = File;
            fileitem.ToolTipText = File.FullName;
            lv.Items.Add(fileitem);

            total_count++;
            total_size += File.Length;
        }

        private void AddDirList(DirectoryInfo di, int depth, ListView lv)
        {
            try
            {
                foreach (DirectoryInfo Di in di.GetDirectories())
                {
                    if (SkipOSDir(Di.Name))
                        continue;
                    total_dir++;
                    if (depth < 2)
                        break;
                    AddDirList(Di, --depth, lv);
                }
                foreach (FileInfo File in di.GetFiles())
                {
                    AddFileList(File, lv);
                }
            }
            catch
            {
                //권한 없음 예외
            }
        }

        private void treeViewFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode sel_node = treeViewFile.SelectedNode;
            if (sel_node.Nodes.Count > 0)
            {
                if (sel_node.IsExpanded)
                    sel_node.Collapse();
                else
                    sel_node.Expand();
            }
            else if (sel_node.SelectedImageIndex == IMAGE.FOLDER)
            {
                AddChild(sel_node);
                sel_node.Expand();
            }
        }

        private void CompareFile(object sender, EventArgs e)
        {
            foreach (ListViewItem item_R in listView_R.Items)
            {
                bool match = false;
                foreach (ListViewItem item_L in listView_L.Items)
                {
                    if(item_R.SubItems[0].Text == item_L.SubItems[0].Text)
                    {
                        item_R.BackColor = ListColors.Last();
                        item_R.ToolTipText = item_L.ToolTipText;
                        item_R.SubItems[2].Text = item_L.SubItems[1].Text;
                        match = true;
                        break;
                    }
                }
                if (match == false)
                    item_R.Remove();
            }
        }
        private void AutoDelFile(object sender, EventArgs e)
        {
            int del_count = 0;
            double total_size = 0;
            MenuItem menu = (MenuItem)sender;
            ListView lv;
            if (menu.Text == "자동 중복 파일 삭제")
            {
                lv = listView_L;
            }
            else
            {
                lv = listView_R;
            }
            
            foreach (ListViewItem item in lv.Items)
            {
                if(item.BackColor == ListColors.Last())
                {
                    FileInfo File = (FileInfo)item.Tag;
                    total_size += File.Length;
                    File.Delete();
                    del_count++;
                }
            }
            listViewUpdate(lv);
            Message("파일수:"+del_count.ToString()+", 용량:"+ (total_size /MB).ToString("F4"), "중복 파일 삭제");
        }


        private void AutoDelDir(object sender, EventArgs e)
        {
            int del_count = 0;
            double total_size = 0;
            TreeNode sel_node = treeViewFile.SelectedNode;
            try
            {
                if (sel_node.SelectedImageIndex == IMAGE.FOLDER)
                {
                    DirectoryInfo di = (DirectoryInfo)sel_node.Tag;
                    foreach (DirectoryInfo Di in di.GetDirectories())
                    {
                        if (SkipOSDir(Di.Name))
                            continue;
                        double dir_size = 0;
                        foreach (FileInfo fi in Di.GetFiles("*", SearchOption.AllDirectories))
                        {
                            dir_size += fi.Length;
                        }
                        if(dir_size < MAX_DIR_SIZE)
                        {
                            Di.Delete(true);
                            del_count++;
                            total_size += dir_size;
                        }
                    }
                }
            }
            catch
            {

            }
            Message("폴더수:" + del_count.ToString() + ", 용량:" + (total_size / MB).ToString("F4"), "폴더 자동 삭제");
        }


        private void listViewUpdate(ListView lv = null)
        {
            if(lv != null)
                Update_R();
            else
                treeViewFile_AfterSelect(treeViewFile, new TreeViewEventArgs(treeViewFile.SelectedNode));
        }
        private void listViewSetCol(ListView lv)
        {
            string file_size = "";
            ListViewItem pre_item = null;
            foreach (ListViewItem item in lv.Items)
            {
                if (file_size == item.SubItems[0].Text)
                {
                    item.BackColor = ListColors.First();
                    total_same++;
                    if (pre_item != null)
                        pre_item.BackColor = ListColors.Last();
                }
                else
                {
                    item.BackColor = ListColors[1];
                }
                file_size = item.SubItems[0].Text;
                pre_item = item;
            }
            if (Config[CONFIG_INDEX.DELFILE]) //중복 파일만 보기
            {
                foreach (ListViewItem item in lv.Items)
                {
                    if (item.BackColor == Color.White)
                        item.Remove();
                }
            }
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            update_dirinfo();
        }



        private void listViewFile_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lv=(ListView)sender;
            if (lv.Columns[e.Column].Text.Contains("▼"))
            {
                lv.ListViewItemSorter = new ListviewItemComparer(e.Column, "asc");
                lv.Columns[e.Column].Text = lv.Columns[e.Column].Text.Replace("▼", "▲");
            }
            else
            {
                if(lv.Columns[e.Column].Text.Contains("▲"))
                    lv.Columns[e.Column].Text = lv.Columns[e.Column].Text.Replace("▲", "");
                lv.ListViewItemSorter = new ListviewItemComparer(e.Column, "desc");
                lv.Columns[e.Column].Text = lv.Columns[e.Column].Text + "▼";
            }


            lv.Sort();
            listViewSetCol((ListView)sender);
        }

        private void UpdateView_R(object sender, EventArgs e)
        {
            Update_R();
        }

        private void Update_R()
        {
            FileList_Clear(listView_R);
            DirectoryInfo di = new DirectoryInfo(textBox_R.Text);
            try
            {
                if (true)
                {
                    foreach (FileInfo File in di.GetFiles())
                    {
                        AddFileList(File, listView_R);
                    }
                    if (Config[CONFIG_INDEX.ALLFILE])
                    {
                        foreach (DirectoryInfo Di in di.GetDirectories())
                        {
                            if (SkipOSDir(Di.Name))
                                continue;
                            AddDirList(Di, MAX_DEPTH, listView_R);
                            total_dir++;
                        }
                    }
                }
            }
            catch
            {
                //권한 없음 예외
            }
            listView_R.Sort();
            listViewSetCol(listView_R);
        }

        private void listViewFile_MouseUp(object sender, MouseEventArgs e)
        {
            if (!e.Button.Equals(MouseButtons.Right))
                return;
            ContextMenu m = new ContextMenu();
            MenuItem m0 = new MenuItem();
            MenuItem m1 = new MenuItem();
            MenuItem m2 = new MenuItem();
            
            m0.Text = "선택 파일 삭제";
            m0.Click += new System.EventHandler(DelFile);
            m.MenuItems.Add(m0);

            m1.Text = "자동 중복 파일 삭제";
            m1.Click += new System.EventHandler(AutoDelFile);
            m.MenuItems.Add(m1);

            m2.Text = "자동 폴더 삭제( < 5MB)";
            m2.Click += new System.EventHandler(AutoDelDir);
            m.MenuItems.Add(m2);

            m.Show(listView_L, new Point(e.X, e.Y));
        }
        #region 유틸 함수
        private int GetIconIndex(string ext)
        {
            int icon_index = IMAGE.FILE;

            if (ext.Equals(".avi", StringComparison.OrdinalIgnoreCase))
                icon_index = IMAGE.PLAY;
            else if (ext.Equals(".mp4", StringComparison.OrdinalIgnoreCase))
                icon_index = IMAGE.PLAY2;
            else if (ext.Equals(".wmv", StringComparison.OrdinalIgnoreCase))
                icon_index = IMAGE.VIDEO;
            else if (ext.Equals(".mkv", StringComparison.OrdinalIgnoreCase))
                icon_index = IMAGE.PLAY4;
            else if (ext.Equals(".mov", StringComparison.OrdinalIgnoreCase))
                icon_index = IMAGE.PLAY3;
            else if (ext.Equals(".mpeg", StringComparison.OrdinalIgnoreCase))
                icon_index = IMAGE.MKV;

            return icon_index;
        }
        private void Message(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists((sender as TextBox).Text))
            {
                return;
            }
            else
            {
                treeViewFile.Nodes.Clear();
                InitFileTree((sender as TextBox).Text);
                _CFG.Default.FilePath_L = textBox_L.Text;
                _CFG.Default.Save();
            }
        }
        private void CFG_save()
        {
            _CFG.Default.AllFile = Config[CONFIG_INDEX.ALLFILE];
            _CFG.Default.DelFile = Config[CONFIG_INDEX.DELFILE];
            _CFG.Default.MinFile = Config[CONFIG_INDEX.MINFILE];

            _CFG.Default.Save();
        }
        private bool SkipOSDir(string name)
        {
            string first = name.Substring(0, 1);
            if (first == "$" || first == "#")
            {
                return true;
            }
            return false;
        }
        private void update_dirinfo()
        {
            listViewDirinfo.Items[0].SubItems[1].Text = (total_size / MB).ToString("F4") + " MB";
            listViewDirinfo.Items[1].SubItems[1].Text = total_count.ToString();
            listViewDirinfo.Items[2].SubItems[1].Text = total_dir.ToString();
            listViewDirinfo.Items[3].SubItems[1].Text = total_same.ToString();
        }

        private void listViewDirinfo_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if(e.Item.Index > 3)
            {
                Config[e.Item.Index-4] = listViewDirinfo.Items[e.Item.Index].Checked;
                CFG_save();
                listViewUpdate();
                listViewUpdate(listView_R);
            } else
            {
                listViewDirinfo.Items[e.Item.Index].Checked = false;
                return;
            }
        }
        private void DelFile(object sender, EventArgs e)
        {
            int del_count = 0;
            double total_size = 0;
            foreach (ListViewItem fileitem in listView_L.SelectedItems)
            {
                FileInfo File = (FileInfo)fileitem.Tag;
                total_size += File.Length;
                del_count++;
                File.Delete();
            }
            listViewUpdate();
            Message("파일수:" + del_count.ToString() + ", 용량:" + (total_size / MB).ToString("F4"), "선택 파일 삭제");
        }

        private void DelFile_R(object sender, EventArgs e)
        {
            int del_count = 0;
            double total_size = 0;
            foreach (ListViewItem fileitem in listView_R.SelectedItems)
            {
                FileInfo File = (FileInfo)fileitem.Tag;
                total_size += File.Length;
                del_count++;
                File.Delete();
            }
            listViewUpdate(listView_R);
            Message("파일수:" + del_count.ToString() + ", 용량:" + (total_size / MB).ToString("F4"), "선택 파일 삭제");
        }
        #endregion 유틸 함수

        #region 이벤트 함수
        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            listView_L.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView_R.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewDirinfo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void textBox_R_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists((sender as TextBox).Text))
            {
                return;
            }
            else
            {
                Update_R();
                _CFG.Default.FilePath_R = textBox_R.Text;
                _CFG.Default.Save();
            }
        }

        private void listView_R_MouseUp(object sender, MouseEventArgs e)
        {
            if (!e.Button.Equals(MouseButtons.Right))
                return;
            ContextMenu m = new ContextMenu();
            MenuItem m0 = new MenuItem();
            MenuItem m1 = new MenuItem();
            MenuItem m2 = new MenuItem();
            MenuItem m3 = new MenuItem();

            m1.Text = "선택 파일 삭제";
            m1.Click += new System.EventHandler(DelFile_R);
            m.MenuItems.Add(m1);

            m0.Text = "중복 파일 삭제";
            m0.Click += new System.EventHandler(AutoDelFile);
            m.MenuItems.Add(m0);

            m2.Text = "왼쪽과 비교";
            m2.Click += new System.EventHandler(CompareFile);
            m.MenuItems.Add(m2);

            m3.Text = "새로 고침";
            m3.Click += new System.EventHandler(UpdateView_R);
            m.MenuItems.Add(m3);

            m.Show(listView_R, new Point(e.X, e.Y));
        }

        private void button_L_Click(object sender, EventArgs e)
        {
            if (textBoxFind_L.Text == "")
                return;

            foreach (ListViewItem item in listView_L.Items)
            {
                FileInfo File = (FileInfo)item.Tag;
                if (File.Name.IndexOf(textBoxFind_L.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    continue;
                else
                {
                    item.Remove();
                }
            }
        }

        private void button_R_Click(object sender, EventArgs e)
        {
            if (textBoxFind_R.Text == "")
                return;

            foreach (ListViewItem item in listView_R.Items)
            {
                FileInfo File = (FileInfo)item.Tag;
                if (File.Name.IndexOf(textBoxFind_R.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    continue;
                else
                {
                    item.Remove();
                }
            }
        }

        private void textBoxFind_R_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_R_Click(button_R, new EventArgs());
        }

        private void textBoxFind_L_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_L_Click(button_L, new EventArgs());
        }
        #endregion 이벤트 함수
    }
    #region 리스트 뷰 정렬
    class ListviewItemComparer : IComparer
    {
        private int col;
        public string sort = "asc";
        public ListviewItemComparer()
        {
            col = 0;
        }
        public ListviewItemComparer(int column, string sort)
        {
            col = column;
            this.sort = sort;
        }

        public int Compare(object x, object y)
        {
            if (col != 0)
            {
                if (sort == "asc")
                {
                    return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                }
                else
                {
                    return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
                }
            }
            else
            {
                double dx, dy;
                dx = Double.Parse(((ListViewItem)x).SubItems[col].Text);
                dy = Double.Parse(((ListViewItem)y).SubItems[col].Text);
                if (sort == "asc")
                {
                    if (dx < dy) return -1;
                    else if (dx == dy) return 0;
                    else return 1;
                }
                else
                {
                    if (dx < dy) return 1;
                    else if (dx == dy) return 0;
                    else return -1;
                }
            }
        }
    }
    #endregion 리스트 뷰 정렬
}