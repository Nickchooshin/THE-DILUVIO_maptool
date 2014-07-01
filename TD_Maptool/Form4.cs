using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TD_Maptool
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public void SetTileSize(int TileSize)
        {
            textBox_TileSize.Text = TileSize.ToString();
        }

        public int GetTileSize()
        {
            return int.Parse(textBox_TileSize.Text.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
