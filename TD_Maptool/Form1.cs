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
        private Image m_Image;
        private TileInfo[] m_tileInfo;
        private int prevSelectedIndex = -1;
        private int m_nNumLinkList = 0;
        private Point[,] m_LinkList;
        private Point selectPoint = new Point(0, 0);
        private bool m_bDrag = false;
        private bool m_bFrame = false;
        private bool m_bLinkUI = false;
        private int m_defaultTile = 0;

        private enum Pen_State { PEN=0, MOUSE } ;
        private Pen_State m_PenState = Pen_State.PEN;

        public Form1()
        {
            InitializeComponent();

            listBox_Tile.ItemHeight = tileSizeXY;
            
            tileSetLoad("Resources/tile_data.xml");

            VisibleLinkUI(false);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.SetMapSize(mapSizeX, mapSizeY);
            form.ShowDialog();

            form.GetMapSize(ref mapSizeX, ref mapSizeY);

            m_Map = new int[mapSizeY, mapSizeX];
            m_LinkList = new Point[mapSizeY, mapSizeX];

            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    m_Map[i, j] = m_defaultTile;
                    m_LinkList[i, j] = new Point(-1, -1);
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
            Point[,] linkList = new Point[mapSizeY, mapSizeX];

            if (prevSizeX > mapSizeX)
                prevSizeX = mapSizeX;
            if (prevSizeY > mapSizeY)
                prevSizeY = mapSizeY;

            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    map[i, j] = 0;
                    linkList[i, j] = new Point(-1, -1);
                }
            }

            for (int i = 0; i < prevSizeY; i++)
            {
                for (int j = 0; j < prevSizeX; j++)
                {
                    map[i, j] = m_Map[i, j];
                    linkList[i, j] = m_LinkList[i, j];
                }
            }

            m_Map = map;
            m_LinkList = linkList;

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

            // Open Map .dat file

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

            // Open Map .link file

            m_LinkList = new Point[mapSizeY, mapSizeX];

            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    m_LinkList[i, j] = new Point(-1, -1);
                }
            }

            try
            {
                StringBuilder LinkFilePath = new StringBuilder(openFileDialog1.FileName);
                LinkFilePath.Replace("dat", "link", LinkFilePath.Length - 3, 3);

                file = new FileStream(LinkFilePath.ToString(), FileMode.Open, FileAccess.Read);
                reader = new StreamReader(file);

                str = reader.scanf();

                m_nNumLinkList = int.Parse(str[0]);

                //m_LinkList = new Point[mapSizeY, mapSizeX];

                for (int i = 0; i < m_nNumLinkList; i++)
                {
                    str = reader.scanf();

                    Point pointLink = new Point(int.Parse(str[0]), int.Parse(str[1]));
                    Point pointLinked = new Point(int.Parse(str[2]), int.Parse(str[3]));

                    m_LinkList[pointLink.Y, pointLink.X] = pointLinked;
                }

                reader.Close();
            }
            catch (FileNotFoundException exception)
            {
            }

            // Resize panel1 scroll

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

            // Save Map .dat file

            FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);

            writer.WriteLine(mapSizeX + " " + mapSizeY);

            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    writer.Write(m_tileInfo[m_Map[i, j]].num + " ");
                }

                writer.WriteLine();
            }

            writer.Close();

            // Save Map .link file

            if (m_nNumLinkList == 0)
                return;

            StringBuilder LinkFilePath = new StringBuilder(saveFileDialog1.FileName);
            LinkFilePath.Replace("dat", "link", LinkFilePath.Length - 3, 3);

            file = new FileStream(LinkFilePath.ToString(), FileMode.Create, FileAccess.Write);
            writer = new StreamWriter(file);

            int numLinkList = 0;
            Point[] LinkIndex = new Point[m_nNumLinkList];
            Point[] LinkList = new Point[m_nNumLinkList];
            Point temp = new Point(-1, -1) ;

            for (int i = 0; i < mapSizeY && numLinkList != m_nNumLinkList; i++)
            {
                for (int j = 0; j < mapSizeX && numLinkList != m_nNumLinkList; j++)
                {
                    if (m_LinkList[i, j] != temp)
                    {
                        LinkIndex[numLinkList] = new Point(j, i);
                        LinkList[numLinkList] = m_LinkList[i, j];
                        ++numLinkList;
                    }
                }
            }

            writer.WriteLine(numLinkList);

            for (int i = 0; i < numLinkList; i++)
            {
                writer.WriteLine(LinkIndex[i].X + " " + LinkIndex[i].Y + "\t" + LinkList[i].X + " " + LinkList[i].Y);
            }

            writer.Close();        }

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
                    Point point = new Point();
                    point.X = (j * tileSizeXY);
                    point.Y = (i * tileSizeXY);

                    if (m_bFrame)
                    {
                        point.X += j;
                        point.Y += i;
                    }
                    
                    graphics.DrawImage(m_Image, new Rectangle(point.X, point.Y, tileSizeXY, tileSizeXY), m_tileInfo[m_Map[i, j]].rect, GraphicsUnit.Pixel);

                    if (m_bLinkUI && (m_LinkList[i, j].X != -1 && m_LinkList[i, j].Y != -1))
                    {
                        Pen pen = new Pen(Color.Black);
                        Brush brush = Brushes.PaleVioletRed;
                        Rectangle rect = new Rectangle(point.X + 3, point.Y + 3, tileSizeXY - 6, tileSizeXY - 6);

                        graphics.FillRectangle(brush, rect);
                        graphics.DrawRectangle(pen, rect);
                    }
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

            if (m_bLinkUI)
            {
                Pen pen = new Pen(Color.Red, 2);
                Rectangle rect = new Rectangle(selectPoint.X * tileSizeXY, selectPoint.Y * tileSizeXY, tileSizeXY, tileSizeXY);

                if (m_bFrame)
                {
                    rect.X += selectPoint.X;
                    rect.Y += selectPoint.Y;
                }

                graphics.DrawRectangle(pen, rect);
            }
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            panel1.Invalidate();
        }

        private void listBox_Tile_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index < 0)
                return;

            Brush brush;
            if (listBox_Tile.SelectedIndex == e.Index)
                brush = Brushes.White;
            else
                brush = Brushes.Black;

            Point point = new Point();
            point.X = e.Bounds.X + e.Font.Height + tileSizeXY;
            point.Y = e.Bounds.Y + (listBox_Tile.ItemHeight / 2) - (e.Font.Height / 2);
            
            e.Graphics.DrawImage(m_Image, new Rectangle(0, e.Bounds.Y, tileSizeXY, tileSizeXY), m_tileInfo[e.Index].rect, GraphicsUnit.Pixel);
            e.Graphics.DrawString(listBox_Tile.Items[e.Index].ToString(), e.Font, brush, point, StringFormat.GenericDefault);
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

            clickTile(X, Y);
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

            clickTile(X, Y);

            textBox_PosX.Text = X.ToString();
            textBox_PosY.Text = Y.ToString();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
        }

        private void tileSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() != DialogResult.OK)
                return;

            tileSetLoad(openFileDialog2.FileName);
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

        private void button_Pen_Click(object sender, EventArgs e)
        {
            m_PenState = Pen_State.PEN;

            VisibleLinkUI(false);
        }

        private void button_Mouse_Click(object sender, EventArgs e)
        {
            m_PenState = Pen_State.MOUSE;

            VisibleLinkUI(true);
        }

        private void button_Link_Click(object sender, EventArgs e)
        {
            int LinkX = int.Parse(textBox_LinkX.Text);
            int LinkY = int.Parse(textBox_LinkY.Text);
            Point pointLinked = new Point(LinkX, LinkY);

            // m_nNumLinkList Count
            Point temp = new Point(-1, -1) ;
            if (m_LinkList[selectPoint.Y, selectPoint.X] == temp && pointLinked != temp)
                ++m_nNumLinkList;

            m_LinkList[selectPoint.Y, selectPoint.X] = pointLinked;

            panel1.Invalidate();
        }

        private void button_LinkDelete_Click(object sender, EventArgs e)
        {
            // m_nNumLinkList Count
            Point temp = new Point(-1, -1);
            if (m_LinkList[selectPoint.Y, selectPoint.X] != temp)
                --m_nNumLinkList;

            m_LinkList[selectPoint.Y, selectPoint.X] = temp;

            panel1.Invalidate();
        }

        /**********************************************************************/

        private void VisibleLinkUI(bool bFlag)
        {
            m_bLinkUI = bFlag;
            label_Link.Visible = bFlag;
            textBox_LinkX.Visible = bFlag;
            textBox_LinkY.Visible = bFlag;
            button_Link.Visible = bFlag;
            button_LinkDelete.Visible = bFlag;

            panel1.Invalidate();
        }

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

        private void clickTile(int x, int y)
        {
            if (m_bDrag &&
                (x >= 0 && y >= 0) && (x < mapSizeX && y < mapSizeY))
            {
                if (m_PenState == Pen_State.PEN)
                {
                    replaceTile(x, y);
                }
                else if (m_PenState == Pen_State.MOUSE)
                {
                    selectTile(x, y);
                }
            }
        }

        private void replaceTile(int x, int y)
        {
            if (prevSelectedIndex == -1)
                return;
            
            m_Map[y, x] = m_tileInfo[prevSelectedIndex].num;

            panel1.Invalidate();
        }

        private void selectTile(int x, int y)
        {
            selectPoint.X = x;
            selectPoint.Y = y;

            Point pointLink = m_LinkList[selectPoint.Y, selectPoint.X];
            textBox_LinkX.Text = pointLink.X.ToString();
            textBox_LinkY.Text = pointLink.Y.ToString();

            panel1.Invalidate();
        }

        private void tileSetLoad(string filePath)
        {
            XmlDocument xmlFile = new XmlDocument();
            XmlNodeList xmlNodeList = null;

            xmlFile.Load(filePath);
            xmlNodeList = xmlFile.SelectNodes("tile/data");
            
            XmlNode nodeSetting = xmlFile.SelectSingleNode("tile/setting");
            m_Image = Image.FromFile(nodeSetting["image"].InnerText.ToString());

            m_tileInfo = new TileInfo[xmlNodeList.Count];

            listBox_Tile.Items.Clear();

            int i = 0;
            foreach (XmlNode node in xmlNodeList)
            {
                m_tileInfo[i] = new TileInfo();

                listBox_Tile.Items.Add(node["name"].InnerText.ToString());
                m_tileInfo[i].num = int.Parse(node["number"].InnerText.ToString());
                m_tileInfo[i].rect.X = int.Parse(node["image_rect"]["x"].InnerText.ToString());
                m_tileInfo[i].rect.Y = int.Parse(node["image_rect"]["y"].InnerText.ToString());
                m_tileInfo[i].rect.Width = int.Parse(node["image_rect"]["width"].InnerText.ToString());
                m_tileInfo[i].rect.Height = int.Parse(node["image_rect"]["height"].InnerText.ToString());

                if (node["default_tile"] != null)
                    m_defaultTile = i;

                ++i;
            }

            panel1.Invalidate();
        }
    }
    
    public class TileInfo
    {
        public Rectangle rect = new Rectangle(0, 0, 0, 0);
        public int num = 0;
    }
}