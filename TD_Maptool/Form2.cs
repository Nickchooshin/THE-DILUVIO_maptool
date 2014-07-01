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
    public partial class Form2 : Form
    {
        private int SizeX, SizeY;

        public Form2()
        {
            InitializeComponent();
        }

        public void SetMapSize(int x, int y)
        {
            textBox_SizeX.Text = x.ToString();
            textBox_SizeY.Text = y.ToString();
        }

        public void GetMapSize(ref int x, ref int y)
        {
            x = SizeX;
            y = SizeY;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SizeX = int.Parse(textBox_SizeX.Text);
            SizeY = int.Parse(textBox_SizeY.Text);

            this.Close();
        }
    }
}
