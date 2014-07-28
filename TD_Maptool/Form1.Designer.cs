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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oepnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_SizeX = new System.Windows.Forms.TextBox();
            this.textBox_SizeY = new System.Windows.Forms.TextBox();
            this.Label_SizeX = new System.Windows.Forms.Label();
            this.listBox_Tile = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_PosY = new System.Windows.Forms.TextBox();
            this.textBox_PosX = new System.Windows.Forms.TextBox();
            this.label_Link = new System.Windows.Forms.Label();
            this.textBox_LinkY = new System.Windows.Forms.TextBox();
            this.textBox_LinkX = new System.Windows.Forms.TextBox();
            this.button_Pen = new System.Windows.Forms.Button();
            this.button_Mouse = new System.Windows.Forms.Button();
            this.button_Link = new System.Windows.Forms.Button();
            this.panel1 = new TD_Maptool.DoubleBufferPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button_LinkDelete = new System.Windows.Forms.Button();
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
            this.tileSizeToolStripMenuItem,
            this.frameToolStripMenuItem});
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
            // frameToolStripMenuItem
            // 
            this.frameToolStripMenuItem.Name = "frameToolStripMenuItem";
            this.frameToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.frameToolStripMenuItem.Text = "Frame";
            this.frameToolStripMenuItem.Click += new System.EventHandler(this.frameToolStripMenuItem_Click);
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
            this.textBox_SizeX.Location = new System.Drawing.Point(12, 46);
            this.textBox_SizeX.Name = "textBox_SizeX";
            this.textBox_SizeX.Size = new System.Drawing.Size(68, 21);
            this.textBox_SizeX.TabIndex = 2;
            this.textBox_SizeX.Text = "0";
            // 
            // textBox_SizeY
            // 
            this.textBox_SizeY.Enabled = false;
            this.textBox_SizeY.Location = new System.Drawing.Point(86, 46);
            this.textBox_SizeY.Name = "textBox_SizeY";
            this.textBox_SizeY.Size = new System.Drawing.Size(68, 21);
            this.textBox_SizeY.TabIndex = 3;
            this.textBox_SizeY.Text = "0";
            // 
            // Label_SizeX
            // 
            this.Label_SizeX.AutoSize = true;
            this.Label_SizeX.Location = new System.Drawing.Point(12, 31);
            this.Label_SizeX.Name = "Label_SizeX";
            this.Label_SizeX.Size = new System.Drawing.Size(59, 12);
            this.Label_SizeX.TabIndex = 4;
            this.Label_SizeX.Text = "Map Size";
            // 
            // listBox_Tile
            // 
            this.listBox_Tile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox_Tile.FormattingEnabled = true;
            this.listBox_Tile.ItemHeight = 32;
            this.listBox_Tile.Location = new System.Drawing.Point(12, 107);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "X";
            // 
            // textBox_PosY
            // 
            this.textBox_PosY.Enabled = false;
            this.textBox_PosY.Location = new System.Drawing.Point(252, 46);
            this.textBox_PosY.Name = "textBox_PosY";
            this.textBox_PosY.Size = new System.Drawing.Size(68, 21);
            this.textBox_PosY.TabIndex = 8;
            this.textBox_PosY.Text = "0";
            // 
            // textBox_PosX
            // 
            this.textBox_PosX.Enabled = false;
            this.textBox_PosX.Location = new System.Drawing.Point(178, 46);
            this.textBox_PosX.Name = "textBox_PosX";
            this.textBox_PosX.Size = new System.Drawing.Size(68, 21);
            this.textBox_PosX.TabIndex = 7;
            this.textBox_PosX.Text = "0";
            // 
            // label_Link
            // 
            this.label_Link.AutoSize = true;
            this.label_Link.Location = new System.Drawing.Point(676, 31);
            this.label_Link.Name = "label_Link";
            this.label_Link.Size = new System.Drawing.Size(28, 12);
            this.label_Link.TabIndex = 13;
            this.label_Link.Text = "Link";
            // 
            // textBox_LinkY
            // 
            this.textBox_LinkY.Location = new System.Drawing.Point(750, 46);
            this.textBox_LinkY.Name = "textBox_LinkY";
            this.textBox_LinkY.Size = new System.Drawing.Size(68, 21);
            this.textBox_LinkY.TabIndex = 12;
            this.textBox_LinkY.Text = "0";
            // 
            // textBox_LinkX
            // 
            this.textBox_LinkX.Location = new System.Drawing.Point(676, 46);
            this.textBox_LinkX.Name = "textBox_LinkX";
            this.textBox_LinkX.Size = new System.Drawing.Size(68, 21);
            this.textBox_LinkX.TabIndex = 11;
            this.textBox_LinkX.Text = "0";
            // 
            // button_Pen
            // 
            this.button_Pen.Image = ((System.Drawing.Image)(resources.GetObject("button_Pen.Image")));
            this.button_Pen.Location = new System.Drawing.Point(12, 73);
            this.button_Pen.Name = "button_Pen";
            this.button_Pen.Size = new System.Drawing.Size(28, 28);
            this.button_Pen.TabIndex = 14;
            this.button_Pen.UseVisualStyleBackColor = true;
            this.button_Pen.Click += new System.EventHandler(this.button_Pen_Click);
            // 
            // button_Mouse
            // 
            this.button_Mouse.Image = ((System.Drawing.Image)(resources.GetObject("button_Mouse.Image")));
            this.button_Mouse.Location = new System.Drawing.Point(43, 73);
            this.button_Mouse.Name = "button_Mouse";
            this.button_Mouse.Size = new System.Drawing.Size(28, 28);
            this.button_Mouse.TabIndex = 15;
            this.button_Mouse.UseVisualStyleBackColor = true;
            this.button_Mouse.Click += new System.EventHandler(this.button_Mouse_Click);
            // 
            // button_Link
            // 
            this.button_Link.Location = new System.Drawing.Point(676, 73);
            this.button_Link.Name = "button_Link";
            this.button_Link.Size = new System.Drawing.Size(68, 28);
            this.button_Link.TabIndex = 16;
            this.button_Link.Text = "Link";
            this.button_Link.UseVisualStyleBackColor = true;
            this.button_Link.Click += new System.EventHandler(this.button_Link_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(178, 107);
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
            // button_LinkDelete
            // 
            this.button_LinkDelete.Location = new System.Drawing.Point(750, 73);
            this.button_LinkDelete.Name = "button_LinkDelete";
            this.button_LinkDelete.Size = new System.Drawing.Size(68, 28);
            this.button_LinkDelete.TabIndex = 17;
            this.button_LinkDelete.Text = "Delete";
            this.button_LinkDelete.UseVisualStyleBackColor = true;
            this.button_LinkDelete.Click += new System.EventHandler(this.button_LinkDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 760);
            this.Controls.Add(this.button_LinkDelete);
            this.Controls.Add(this.button_Link);
            this.Controls.Add(this.button_Mouse);
            this.Controls.Add(this.button_Pen);
            this.Controls.Add(this.label_Link);
            this.Controls.Add(this.textBox_LinkY);
            this.Controls.Add(this.textBox_LinkX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_PosY);
            this.Controls.Add(this.textBox_PosX);
            this.Controls.Add(this.listBox_Tile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Label_SizeX);
            this.Controls.Add(this.textBox_SizeY);
            this.Controls.Add(this.textBox_SizeX);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "THE DILUVIO - map_tool  v 1.02";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_PosY;
        private System.Windows.Forms.TextBox textBox_PosX;
        private System.Windows.Forms.ToolStripMenuItem frameToolStripMenuItem;
        private System.Windows.Forms.Label label_Link;
        private System.Windows.Forms.TextBox textBox_LinkY;
        private System.Windows.Forms.TextBox textBox_LinkX;
        private System.Windows.Forms.Button button_Pen;
        private System.Windows.Forms.Button button_Mouse;
        private System.Windows.Forms.Button button_Link;
        private System.Windows.Forms.Button button_LinkDelete;
    }
}

