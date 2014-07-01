using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace TD_Maptool
{
    public partial class Form1 : Form
    {
        private int mapSizeX = 0, mapSizeY = 0;
        private int[,] m_Map;
        private Image[] m_Image;
        private int prevSelectedIndex = -1;
        private XmlNodeList m_NodeList;
        private bool m_bDrag=false;

        public Form1()
        {
            InitializeComponent();

            XmlDocument xmlFile = new XmlDocument();
            xmlFile.Load("Resource/tile_data.xml");
            m_NodeList = xmlFile.SelectNodes("tile/data");

            m_Image = new Image[m_NodeList.Count];

            int i = 0;
            foreach (XmlNode Node in m_NodeList)
            {
                listBox_Tile.Items.Add(Node["name"].InnerText.ToString());
                m_Image[i++] = Image.FromFile(Node["image"].InnerText.ToString());
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.SetMapSize(mapSizeX, mapSizeY);
            form.ShowDialog();

            //

            int prevSizeX = mapSizeX;
            int prevSizeY = mapSizeY;

            form.GetMapSize(ref mapSizeX, ref mapSizeY);

            int[,] map = new int[mapSizeY, mapSizeX];

            if (prevSizeX > mapSizeX)
                prevSizeX = mapSizeX;
            if (prevSizeY > mapSizeY)
                prevSizeY = mapSizeY;

            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    map[i, j] = 0;
                }
            }

            for (int i = 0; i < prevSizeY; i++)
            {
                for (int j = 0; j < prevSizeX; j++)
                {
                    map[i, j] = m_Map[i, j];
                }
            }

            m_Map = map;

            //

            textBox_SizeX.Text = mapSizeX.ToString();
            textBox_SizeY.Text = mapSizeY.ToString();

            pictureBox.Location = new Point(mapSizeX * 32, mapSizeY * 32);

            panel1.Invalidate();
        }

        private void oepnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream("map.dat", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            string[] str;
            str = reader.scanf();

            mapSizeX = int.Parse(str[0].ToString());
            mapSizeY = int.Parse(str[1].ToString());

            m_Map = new int[mapSizeY, mapSizeX];

            for (int i = 0; i < mapSizeY; i++)
            {
                str = reader.scanf();
                for (int j = 0; j < mapSizeX; j++)
                {
                    m_Map[i, j] = int.Parse(str[j].ToString());
                }
            }

            pictureBox.Location = new Point(mapSizeX * 32, mapSizeY * 32);

            panel1.Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream("map.dat", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);

            writer.WriteLine(mapSizeX + " " + mapSizeY);

            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    writer.Write(m_Map[i, j] + " ");
                }

                writer.WriteLine();
            }

            writer.Close();
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
                    graphics.DrawImage(m_Image[m_Map[i, j]], j * 32, i * 32);
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
            if (prevSelectedIndex != -1)
                listBox_Tile.Invalidate(listBox_Tile.GetItemRectangle(prevSelectedIndex));

            prevSelectedIndex = listBox_Tile.SelectedIndex;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            m_bDrag = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            m_bDrag = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!m_bDrag || prevSelectedIndex == -1)
                return;

            int X = (e.X - panel1.AutoScrollPosition.X) / 32;
            int Y = (e.Y - panel1.AutoScrollPosition.Y) / 32;

            if ((X >= 0 && Y >= 0) && (X < mapSizeX && Y < mapSizeY))
            {
                m_Map[Y, X] = prevSelectedIndex;
                panel1.Invalidate();
            }
        }
    }
}
