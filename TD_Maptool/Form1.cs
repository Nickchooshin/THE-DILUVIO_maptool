using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TD_Maptool
{
    public partial class Form1 : Form
    {
        private int mapSizeX = 0, mapSizeY = 0;
        private Image[,] m_Image;
        private int currenrSelectedIndex = -1, prevSelectedIndex = -1;
        private XmlNodeList m_NodeList;

        public Form1()
        {
            InitializeComponent();

            XmlDocument xmlFile = new XmlDocument();
            xmlFile.Load("Resource/tile_data.xml");
            m_NodeList = xmlFile.SelectNodes("tile/data");

            foreach (XmlNode Node in m_NodeList)
            {
                listBox_Tile.Items.Add(Node["name"].InnerText.ToString());
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();

            //

            int prevSizeX = mapSizeX;
            int prevSizeY = mapSizeY;

            form.GetMapSize(ref mapSizeX, ref mapSizeY);

            Image[,] image = new Image[mapSizeY, mapSizeX];

            if (prevSizeX > mapSizeX)
                prevSizeX = mapSizeX;
            if (prevSizeY > mapSizeY)
                prevSizeY = mapSizeY;

            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    XmlNode Node = m_NodeList[0];
                    image[i, j] = Image.FromFile(Node["image"].InnerText.ToString());
                }
            }

            for (int i = 0; i < prevSizeY; i++)
            {
                for (int j = 0; j < prevSizeX; j++)
                {
                    image[i, j] = m_Image[i, j];
                }
            }

            m_Image = image;

            //

            textBox_SizeX.Text = mapSizeX.ToString();
            textBox_SizeY.Text = mapSizeY.ToString();

            pictureBox.Location = new Point(mapSizeX * 32, mapSizeY * 32);

            panel1.Invalidate();
        }

        private void oepnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.TranslateTransform(panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y);

            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    graphics.DrawImage(m_Image[i, j], j * 32, i * 32);
                }
            }
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            panel1.Invalidate();
        }

        private void listBox_Tile_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            Brush brush;
            if (listBox_Tile.SelectedIndex == e.Index)
                brush = Brushes.White;
            else
                brush = Brushes.Black;

            int x = e.Bounds.X + e.Font.Height + 32;
            int y = e.Bounds.Y + e.Font.Height;

            XmlNode Node = m_NodeList[e.Index];
            Image img = Image.FromFile(Node["image"].InnerText.ToString());
            e.Graphics.DrawImage(img, 0, e.Bounds.Y);
            e.Graphics.DrawString(listBox_Tile.Items[e.Index].ToString(), e.Font, brush, x, y, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void listBox_Tile_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_Tile.Invalidate();

            if (prevSelectedIndex != -1)
                listBox_Tile.Invalidate(listBox_Tile.GetItemRectangle(prevSelectedIndex));

            prevSelectedIndex = listBox_Tile.SelectedIndex;
        }
    }
}
