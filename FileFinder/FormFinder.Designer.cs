
namespace FileFinder
{
    partial class FormFinder
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.ColumnHeader columnHeader2;
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "용량"}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Gainsboro, new System.Drawing.Font("맑은 고딕", 8F));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "파일 수"}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("맑은 고딕", 8F));
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "폴더 수"}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Gainsboro, new System.Drawing.Font("맑은 고딕", 8F));
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "중복 파일 수"}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("맑은 고딕", 8F));
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "폴더파일 보기"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Gainsboro, null);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("중복만 보기");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "큰파일 보기"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Gainsboro, null);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFinder));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutLeft = new System.Windows.Forms.TableLayoutPanel();
            this.listViewDirinfo = new System.Windows.Forms.ListView();
            this.LabelFixHdr = new System.Windows.Forms.Label();
            this.treeViewFile = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayout_BotR = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxFind_R = new System.Windows.Forms.TextBox();
            this.button_R = new System.Windows.Forms.Button();
            this.textBox_L = new System.Windows.Forms.TextBox();
            this.textBox_R = new System.Windows.Forms.TextBox();
            this.listView_R = new System.Windows.Forms.ListView();
            this.listView_L = new System.Windows.Forms.ListView();
            this.tableLayout_BotL = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxFind_L = new System.Windows.Forms.TextBox();
            this.button_L = new System.Windows.Forms.Button();
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutLeft.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayout_BotR.SuspendLayout();
            this.tableLayout_BotL.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "필드";
            columnHeader1.Width = 127;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "값";
            columnHeader2.Width = 208;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 777F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 777);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 777);
            this.splitContainer1.SplitterDistance = 158;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SizeChanged += new System.EventHandler(this.splitContainer1_SizeChanged);
            // 
            // tableLayoutLeft
            // 
            this.tableLayoutLeft.ColumnCount = 1;
            this.tableLayoutLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutLeft.Controls.Add(this.listViewDirinfo, 0, 2);
            this.tableLayoutLeft.Controls.Add(this.LabelFixHdr, 0, 1);
            this.tableLayoutLeft.Controls.Add(this.treeViewFile, 0, 0);
            this.tableLayoutLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutLeft.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutLeft.Name = "tableLayoutLeft";
            this.tableLayoutLeft.RowCount = 3;
            this.tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutLeft.Size = new System.Drawing.Size(158, 777);
            this.tableLayoutLeft.TabIndex = 0;
            // 
            // listViewDirinfo
            // 
            this.listViewDirinfo.CheckBoxes = true;
            this.listViewDirinfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            columnHeader2});
            this.listViewDirinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDirinfo.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.listViewDirinfo.FullRowSelect = true;
            this.listViewDirinfo.GridLines = true;
            this.listViewDirinfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDirinfo.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            listViewItem5.StateImageIndex = 0;
            listViewItem6.StateImageIndex = 0;
            listViewItem7.StateImageIndex = 0;
            this.listViewDirinfo.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
            this.listViewDirinfo.Location = new System.Drawing.Point(0, 625);
            this.listViewDirinfo.Margin = new System.Windows.Forms.Padding(0);
            this.listViewDirinfo.Name = "listViewDirinfo";
            this.listViewDirinfo.Size = new System.Drawing.Size(158, 152);
            this.listViewDirinfo.TabIndex = 3;
            this.listViewDirinfo.UseCompatibleStateImageBehavior = false;
            this.listViewDirinfo.View = System.Windows.Forms.View.Details;
            this.listViewDirinfo.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewDirinfo_ItemChecked);
            // 
            // LabelFixHdr
            // 
            this.LabelFixHdr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelFixHdr.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LabelFixHdr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelFixHdr.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.LabelFixHdr.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LabelFixHdr.Image = ((System.Drawing.Image)(resources.GetObject("LabelFixHdr.Image")));
            this.LabelFixHdr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelFixHdr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LabelFixHdr.Location = new System.Drawing.Point(3, 605);
            this.LabelFixHdr.Name = "LabelFixHdr";
            this.LabelFixHdr.Size = new System.Drawing.Size(152, 20);
            this.LabelFixHdr.TabIndex = 2;
            this.LabelFixHdr.Text = "     파일 정보, 설정";
            this.LabelFixHdr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // treeViewFile
            // 
            this.treeViewFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFile.Location = new System.Drawing.Point(0, 0);
            this.treeViewFile.Margin = new System.Windows.Forms.Padding(0);
            this.treeViewFile.Name = "treeViewFile";
            this.treeViewFile.ShowNodeToolTips = true;
            this.treeViewFile.Size = new System.Drawing.Size(158, 605);
            this.treeViewFile.TabIndex = 1;
            this.treeViewFile.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFile_AfterSelect);
            this.treeViewFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeViewFile_MouseDoubleClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayout_BotR, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBox_L, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_R, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.listView_R, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.listView_L, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayout_BotL, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(639, 777);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayout_BotR
            // 
            this.tableLayout_BotR.ColumnCount = 2;
            this.tableLayout_BotR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout_BotR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout_BotR.Controls.Add(this.textBoxFind_R, 0, 0);
            this.tableLayout_BotR.Controls.Add(this.button_R, 1, 0);
            this.tableLayout_BotR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout_BotR.Location = new System.Drawing.Point(319, 757);
            this.tableLayout_BotR.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayout_BotR.Name = "tableLayout_BotR";
            this.tableLayout_BotR.RowCount = 1;
            this.tableLayout_BotR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout_BotR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout_BotR.Size = new System.Drawing.Size(320, 20);
            this.tableLayout_BotR.TabIndex = 5;
            // 
            // textBoxFind_R
            // 
            this.textBoxFind_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFind_R.Location = new System.Drawing.Point(0, 0);
            this.textBoxFind_R.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxFind_R.Name = "textBoxFind_R";
            this.textBoxFind_R.Size = new System.Drawing.Size(300, 23);
            this.textBoxFind_R.TabIndex = 3;
            this.textBoxFind_R.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFind_R_KeyDown);
            // 
            // button_R
            // 
            this.button_R.BackColor = System.Drawing.SystemColors.Window;
            this.button_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_R.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_R.Location = new System.Drawing.Point(300, 0);
            this.button_R.Margin = new System.Windows.Forms.Padding(0);
            this.button_R.Name = "button_R";
            this.button_R.Size = new System.Drawing.Size(20, 20);
            this.button_R.TabIndex = 4;
            this.button_R.UseVisualStyleBackColor = false;
            this.button_R.Click += new System.EventHandler(this.button_R_Click);
            // 
            // textBox_L
            // 
            this.textBox_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_L.Location = new System.Drawing.Point(0, 0);
            this.textBox_L.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_L.Name = "textBox_L";
            this.textBox_L.Size = new System.Drawing.Size(319, 23);
            this.textBox_L.TabIndex = 0;
            this.textBox_L.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBox_R
            // 
            this.textBox_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_R.Location = new System.Drawing.Point(319, 0);
            this.textBox_R.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_R.Name = "textBox_R";
            this.textBox_R.Size = new System.Drawing.Size(320, 23);
            this.textBox_R.TabIndex = 1;
            this.textBox_R.TextChanged += new System.EventHandler(this.textBox_R_TextChanged);
            // 
            // listView_R
            // 
            this.listView_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_R.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.listView_R.HideSelection = false;
            this.listView_R.Location = new System.Drawing.Point(319, 20);
            this.listView_R.Margin = new System.Windows.Forms.Padding(0);
            this.listView_R.Name = "listView_R";
            this.listView_R.ShowItemToolTips = true;
            this.listView_R.Size = new System.Drawing.Size(320, 737);
            this.listView_R.TabIndex = 2;
            this.listView_R.UseCompatibleStateImageBehavior = false;
            this.listView_R.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewFile_ColumnClick);
            this.listView_R.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView_R_MouseUp);
            // 
            // listView_L
            // 
            this.listView_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_L.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.listView_L.HideSelection = false;
            this.listView_L.Location = new System.Drawing.Point(0, 20);
            this.listView_L.Margin = new System.Windows.Forms.Padding(0);
            this.listView_L.Name = "listView_L";
            this.listView_L.ShowItemToolTips = true;
            this.listView_L.Size = new System.Drawing.Size(319, 737);
            this.listView_L.TabIndex = 0;
            this.listView_L.UseCompatibleStateImageBehavior = false;
            this.listView_L.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewFile_ColumnClick);
            this.listView_L.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewFile_MouseUp);
            // 
            // tableLayout_BotL
            // 
            this.tableLayout_BotL.ColumnCount = 2;
            this.tableLayout_BotL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout_BotL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout_BotL.Controls.Add(this.textBoxFind_L, 0, 0);
            this.tableLayout_BotL.Controls.Add(this.button_L, 1, 0);
            this.tableLayout_BotL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout_BotL.Location = new System.Drawing.Point(0, 757);
            this.tableLayout_BotL.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayout_BotL.Name = "tableLayout_BotL";
            this.tableLayout_BotL.RowCount = 1;
            this.tableLayout_BotL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout_BotL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout_BotL.Size = new System.Drawing.Size(319, 20);
            this.tableLayout_BotL.TabIndex = 4;
            // 
            // textBoxFind_L
            // 
            this.textBoxFind_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFind_L.Location = new System.Drawing.Point(0, 0);
            this.textBoxFind_L.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxFind_L.Name = "textBoxFind_L";
            this.textBoxFind_L.Size = new System.Drawing.Size(299, 23);
            this.textBoxFind_L.TabIndex = 3;
            this.textBoxFind_L.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFind_L_KeyDown);
            // 
            // button_L
            // 
            this.button_L.BackColor = System.Drawing.SystemColors.Window;
            this.button_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_L.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_L.Location = new System.Drawing.Point(299, 0);
            this.button_L.Margin = new System.Windows.Forms.Padding(0);
            this.button_L.Name = "button_L";
            this.button_L.Size = new System.Drawing.Size(20, 20);
            this.button_L.TabIndex = 4;
            this.button_L.UseVisualStyleBackColor = false;
            this.button_L.Click += new System.EventHandler(this.button_L_Click);
            // 
            // FormFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 777);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormFinder";
            this.Text = "FileFinder";
            this.Load += new System.EventHandler(this.FormFinder_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutLeft.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayout_BotR.ResumeLayout(false);
            this.tableLayout_BotR.PerformLayout();
            this.tableLayout_BotL.ResumeLayout(false);
            this.tableLayout_BotL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView_L;
        private System.Windows.Forms.TableLayoutPanel tableLayoutLeft;
        private System.Windows.Forms.TextBox textBox_L;
        private System.Windows.Forms.TreeView treeViewFile;
        private System.Windows.Forms.ListView listViewDirinfo;
        private System.Windows.Forms.Label LabelFixHdr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBox_R;
        private System.Windows.Forms.ListView listView_R;
        private System.Windows.Forms.TableLayoutPanel tableLayout_BotR;
        private System.Windows.Forms.TextBox textBoxFind_R;
        private System.Windows.Forms.Button button_R;
        private System.Windows.Forms.TableLayoutPanel tableLayout_BotL;
        private System.Windows.Forms.TextBox textBoxFind_L;
        private System.Windows.Forms.Button button_L;
    }
}

