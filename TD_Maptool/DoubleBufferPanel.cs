using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TD_Maptool
{
    public class DoubleBufferPanel : Panel
    {
        public DoubleBufferPanel()
        {
            //this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            this.UpdateStyles();
        }
    }

    public static class MyIO
    {
        public static string[] scanf(this StreamReader fp)
        {
            return get_vals(fp.ReadLine());
        }

        public static string[] get_vals(string line)
        {
            char[] split = { ' ', '=', ',', '\t', '\"', '/' };

            return line.Split(split, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
