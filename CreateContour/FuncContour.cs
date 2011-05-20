using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection; 

namespace CreateContour
{
    public delegate double surf_func(double x, double y);

    public class Contour
    {
        private double _max_x;
        private double _min_x;
        private double _max_y;
        private double _min_y;

        private int _contour_w;
        private int _contour_h;

        private double[][] func_vals;

        private double res_x;
        private double res_y;

        public string file_name;

        public Bitmap contour_bmp;
        
        public Contour(double max_x, double min_x, double max_y, double min_y, int img_w, int img_h)
        {
            _max_x = max_x;
            _min_x = min_x;
            _max_y = max_y;
            _min_y = min_y;
            _contour_w = img_w;
            _contour_h = img_h;


            if (_max_x < _min_x)
            {
                double temp = _max_x;
                _max_x = _min_x;
                _min_x = temp;
            }

            if (_max_y < _min_y)
            {
                double temp = _max_y;
                _max_y = _min_y;
                _min_y = temp;
            }
            
            res_x = (_max_x - _min_x) / img_w;
            res_y = (_max_y - _min_y) / img_h;

            try
            {
                Array.Resize(ref func_vals, img_h);
                for (int i = 0; i < img_h; i++)
                    Array.Resize(ref func_vals[i], img_w);

                contour_bmp = new Bitmap(img_w, img_h);
            }
            catch
            {
                MessageBox.Show("Could not create array to hold function evaluations");
            }
        }


        private void create_bmp()
        {
            //int[] color_map_blue = new int[566];
            //int[] color_map_red = new int[566];
            //int[] color_map_green = new int[566];

            int[] color_map_blue = new int[114];
            int[] color_map_red = new int[114];
            int[] color_map_green = new int[114];

            //int val = 255;
            //for (int i = 0; i < 256; i++)
            //{
            //    color_map_blue[i] = val - i;
            //    color_map_red[i] = val - i;
            //}

            int val = 255;
            for (int i = 0; i < 52; i++)
            {
                color_map_blue[i] = val - 5*i;
                color_map_red[i] = val - 5*i;
            }

            Array.Reverse(color_map_red);

            //val = 255;
            //for (int i = 155; i < 411; i++)
            //{
            //    color_map_green[i] = val;
            //    val--;
            //}

            val = 255;
            for (int i = 31; i < 83; i++)
            {
                color_map_green[i] = val;
                val-=5;
            }

            double max_val = 0;
            double min_val = 0;
            maxmin(ref func_vals[0], ref max_val, ref min_val);


            double row_max = 0, row_min = 0;

            for (int i = 1; i < _contour_h; i++)
            {

                maxmin(ref func_vals[i], ref row_max, ref row_min);

                if (row_max > max_val)
                    max_val = row_max;

                if (row_min < min_val)
                    min_val = row_min;
            }

            if (double.IsInfinity(max_val) || double.IsInfinity(min_val))
            {
                MessageBox.Show("Function does not appear to have any valid values");
                return;
            }

            //double slope = 565 / (max_val - min_val);
            double slope = 113 / (max_val - min_val);
            
            double b = -slope * min_val;
            int curr_color;
            for (int i = 0; i < _contour_h; i++)
            {
                for (int j = 0; j < _contour_w; j++)
                {
                    if (double.IsInfinity(func_vals[i][j]) || double.IsNaN(func_vals[i][j]))
                        curr_color = -100;
                    else
                    {
                        curr_color = (int)(slope * func_vals[i][j] + b);
                        //if (curr_color > 565)
                        //    curr_color = 565;
                        //else if (curr_color < 0)
                        //    curr_color = 0;

                        if (curr_color > 113)
                            curr_color = 113;
                        else if (curr_color < 0)
                            curr_color = 0;
                    }
                    if (curr_color == -100)
                        contour_bmp.SetPixel(j, i, Color.White);
                    else
                        contour_bmp.SetPixel(j, i, Color.FromArgb(color_map_red[curr_color], color_map_green[curr_color], color_map_blue[curr_color]));
                }
            }
        }

        public void save_img(string filename)
        {
            contour_bmp.Save(filename);
        }

        public void create_contour(surf_func func)
        {
           
            double x, y;
            //double curr_val;
            //only takes two doubles of storage but lot of computation on the x and y
            for (int i = 0; i < _contour_h; i++)
            {
                y = res_y * i + _min_y;
                for (int j = 0; j < _contour_w; j++)
                {
                    x = res_x * j + _min_x;
                    //curr_val = func(x, y);
                    func_vals[_contour_h - i - 1][j] = func(x, y);
                }
            }

            create_bmp();
        }

        public void create_contour(ref Type script, ref string name)
        {
            double x, y;
            //double curr_val;
            for (int i = 0; i < _contour_h; i++)
            {
                y = res_y * i + _min_y;
                for (int j = 0; j < _contour_w; j++)
                {
                    x = res_x * j + _min_x;
                    func_vals[_contour_h - i - 1][j] = (double)script.InvokeMember(name, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, new object[] { x, y });
                }
            }
            create_bmp();
        }

        public void maxmin(ref double[] vals, ref double max_val, ref double min_val)
        {
            int i = 0;
            int vals_length = vals.Length;

            while (double.IsInfinity(vals[i]) || double.IsNaN(vals[i]))
                i++;

            if (i >= vals_length)
            {
                max_val = double.NegativeInfinity;
                min_val = double.PositiveInfinity;
                return;
            }

            max_val = vals[i];
            min_val = vals[i];
            for (int j = i + 1; j < vals_length; j++)
            {
                if (!double.IsInfinity(vals[j]) && !double.IsNaN(vals[j]))
                {
                    if (vals[j] > max_val)
                        max_val = vals[j];
                    if (vals[j] < min_val)
                        min_val = vals[j];
                }
            }
        }

    }
}
