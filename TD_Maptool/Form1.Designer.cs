namespace TD_Maptool
{
    partial class Form1
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oepnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_SizeX = new System.Windows.Forms.TextBox();
            this.textBox_SizeY = new System.Windows.Forms.TextBox();
            this.Label_SizeX = new System.Windows.Forms.Label();
            this.Label_SizeY = new System.Windows.Forms.Label();
            this.listBox_Tile = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new TD_Maptool.DoubleBufferPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(830, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.resizeToolStripMenuItem,
            this.oepnToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.resizeToolStripMenuItem.Text = "Resize";
            this.resizeToolStripMenuItem.Click += new System.EventHandler(this.resizeToolStripMenuItem_Click);
            // 
            // oepnToolStripMenuItem
            // 
            this.oepnToolStripMenuItem.Name = "oepnToolStripMenuItem";
            this.oepnToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.oepnToolStripMenuItem.Text = "Oepn";
            this.oepnToolStripMenuItem.Click += new System.EventHandler(this.oepnToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileSizeToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // tileSizeToolStripMenuItem
            // 
            this.tileSizeToolStripMenuItem.Name = "tileSizeToolStripMenuItem";
            this.tileSizeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.tileSizeToolStripMenuItem.Text = "TileSize";
            this.tileSizeToolStripMenuItem.Click += new System.EventHandler(this.tileSizeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // textBox_SizeX
            // 
            this.textBox_SizeX.Enabled = false;
            this.textBox_SizeX.Location = new System.Drawing.Point(178, 46);
            this.textBox_SizeX.Name = "textBox_SizeX";
            this.textBox_SizeX.Size = new System.Drawing.Size(68, 21);
            this.textBox_SizeX.TabIndex = 2;
            this.textBox_SizeX.Text = "0";
            // 
            // textBox_SizeY
            // 
            this.textBox_SizeY.Enabled = false;
            this.textBox_SizeY.Location = new System.Drawing.Point(252, 46);
            this.textBox_SizeY.Name = "textBox_SizeY";
            this.textBox_SizeY.Size = new System.Drawing.Size(68, 21);
            this.textBox_SizeY.TabIndex = 3;
            this.textBox_SizeY.Text = "0";
            // 
            // Label_SizeX
            // 
            this.Label_SizeX.AutoSize = true;
            this.Label_SizeX.Location = new System.Drawing.Point(178, 31);
            this.Label_SizeX.Name = "Label_SizeX";
            this.Label_SizeX.Size = new System.Drawing.Size(13, 12);
            this.Label_SizeX.TabIndex = 4;
            this.Label_SizeX.Text = "X";
            // 
            // Label_SizeY
            // 
            this.Label_SizeY.AutoSize = true;
            this.Label_SizeY.Location = new System.Drawing.Point(250, 31);
            this.Label_SizeY.Name = "Label_SizeY";
            this.Label_SizeY.Size = new System.Drawing.Size(13, 12);
            this.Label_SizeY.TabIndex = 5;
            this.Label_SizeY.Text = "Y";
            // 
            // listBox_Tile
            // 
            this.listBox_Tile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox_Tile.FormattingEnabled = true;
            this.listBox_Tile.ItemHeight = 32;
            this.listBox_Tile.Location = new System.Drawing.Point(12, 73);
            this.listBox_Tile.Name = "listBox_Tile";
            this.listBox_Tile.Size = new System.Drawing.Size(160, 580);
            this.listBox_Tile.TabIndex = 1;
            this.listBox_Tile.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_Tile_DrawItem);
            this.listBox_Tile.SelectedIndexChanged += new System.EventHandler(this.listBox_Tile_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "dat 파일|*.dat|모든 파일|*.*";
            this.openFileDialog1.InitialDirectory = "./";
            this.openFileDialog1.Tag = "";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "dat 파일|*.dat|모든 파일|*.*";
            this.saveFileDialog1.InitialDirectory = "./";
            this.saveFileDialog1.Tag = "";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(178, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 640);
            this.panel1.TabIndex = 6;
            this.panel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1, 1);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 726);
            this.Controls.Add(this.listBox_Tile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Label_SizeY);
            this.Controls.Add(this.Label_SizeX);
            this.Controls.Add(this.textBox_SizeY);
            this.Controls.Add(this.textBox_SizeX);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "THE DILUVIO - map_tool  v 1.01";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oepnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_SizeX;
        private System.Windows.Forms.TextBox textBox_SizeY;
        private System.Windows.Forms.Label Label_SizeX;
        private System.Windows.Forms.Label Label_SizeY;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ListBox listBox_Tile;
        private DoubleBufferPanel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
    }
}

