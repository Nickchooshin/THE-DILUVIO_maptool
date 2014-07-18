﻿using System;
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
        private int tileSizeXY = 32;
        private int mapSizeX = 0, mapSizeY = 0;
        private int[,] m_Map;
        private Image[] m_Image;
        private int prevSelectedIndex = -1;
        private XmlNodeList m_NodeList;
        private bool m_bDrag = false;
        private bool m_bFrame = false;

        public Form1()
        {
            InitializeComponent();

            listBox_Tile.ItemHeight = tileSizeXY;

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

            form.GetMapSize(ref mapSizeX, ref mapSizeY);

            m_Map = new int[mapSizeY, mapSizeX];

            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    m_Map[i, j] = 0;
                }
            }

            textBox_SizeX.Text = mapSizeX.ToString();
            textBox_SizeY.Text = mapSizeY.ToString();

            ResizePictureBoxLocation();

            panel1.Invalidate();
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.SetMapSize(mapSizeX, mapSizeY);
            form.ShowDialog();

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

            textBox_SizeX.Text = mapSizeX.ToString();
            textBox_SizeY.Text = mapSizeY.ToString();

            ResizePictureBoxLocation();

            panel1.Invalidate();
        }

        private void oepnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            string FilePath = openFileDialog1.FileName;

            FileStream file = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Read);
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

            reader.Close();

            int tileFrameSize = tileSizeXY;
            if (m_bFrame)
                tileFrameSize += 1;

            pictureBox.Location = new Point(mapSizeX * tileFrameSize, mapSizeY * tileFrameSize);

            panel1.Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            string FilePath = saveFileDialog1.FileName;

            FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
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

            int i, j;

            for (i = 0; i < mapSizeY; i++)
            {
                for (j = 0; j < mapSizeX; j++)
                {
                    int x = (j * tileSizeXY);
                    int y = (i * tileSizeXY);

                    if (m_bFrame)
                    {
                        x += j;
                        y += i;
                    }

                    graphics.DrawImage(m_Image[m_Map[i, j]], x, y);
                }
            }

            if(m_bFrame)
            {
                Pen pen = new Pen(Color.Black);
                Point pt1, pt2;
                int x, y ;

                for(i = 0; i < mapSizeX || i < mapSizeY; i++)
                {
                    if(i<mapSizeX)
                    {
                        x = (i + 1) * tileSizeXY + i;
                        y = (mapSizeY * tileSizeXY) + (mapSizeY - 1);

                        pt1 = new Point(x, 0) ;
                        pt2 = new Point(x, y) ;

                        graphics.DrawLine(pen, pt1, pt2);
                    }

                    if(i<mapSizeY)
                    {
                        x = (mapSizeX * tileSizeXY) + (mapSizeX - 1);
                        y = (i + 1) * tileSizeXY + i;

                        pt1 = new Point(0, y);
                        pt2 = new Point(x, y);

                        graphics.DrawLine(pen, pt1, pt2);
                    }
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

            int x = e.Bounds.X + e.Font.Height + tileSizeXY;
            int y = e.Bounds.Y + (listBox_Tile.ItemHeight / 2) - (e.Font.Height / 2);

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

            int X = new int();
            int Y = new int();

            GetPosMouseToTile(e, ref X, ref Y);

            replaceTile(X, Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            m_bDrag = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            int X = new int();
            int Y = new int();

            GetPosMouseToTile(e, ref X, ref Y);

            replaceTile(X, Y);

            textBox_PosX.Text = X.ToString();
            textBox_PosY.Text = Y.ToString();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
        }

        private void tileSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.SetTileSize(tileSizeXY);
            form.ShowDialog();
            tileSizeXY = form.GetTileSize();

            panel1.Invalidate();
            listBox_Tile.ItemHeight = tileSizeXY;
            listBox_Tile.Invalidate();
        }

        private void frameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_bFrame = !m_bFrame;
            frameToolStripMenuItem.Checked = m_bFrame;

            ResizePictureBoxLocation();
            panel1.Invalidate();
        }

        /**********************************************************************/

        private void ResizePictureBoxLocation()
        {
            int tileFrameSize = tileSizeXY;
            if (m_bFrame)
                tileFrameSize += 1;

            pictureBox.Location = new Point(mapSizeX * tileFrameSize, mapSizeY * tileFrameSize);
        }

        private void GetPosMouseToTile(MouseEventArgs e, ref int x, ref int y)
        {
            int tileFrameSize = tileSizeXY;
            if (m_bFrame)
                tileFrameSize += 1;

            x = (e.X - panel1.AutoScrollPosition.X) / tileFrameSize;
            y = (e.Y - panel1.AutoScrollPosition.Y) / tileFrameSize;
        }

        private void replaceTile(int x, int y)
        {
            if (!m_bDrag || prevSelectedIndex == -1)
                return;

            if ((x >= 0 && y >= 0) && (x < mapSizeX && y < mapSizeY))
            {
                m_Map[y, x] = prevSelectedIndex;
                panel1.Invalidate();
            }
        }
    }
}
