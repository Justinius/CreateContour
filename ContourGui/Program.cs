using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection; 

namespace ContourGui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        
                
        

        public static double DeJong(double x, double y)
        {
            return (x * x + y * y);
        }

        public static double Rosenbrock(double x, double y)
        {
            return (100 * Math.Pow((y - x * x), 2) + Math.Pow((1 - x), 2));
        }

        public static double Rastrigin(double x, double y)
        {
            return 20 + (x*x - 10*Math.Cos(2*Math.PI*x)) + (y*y - 10*Math.Cos(2*Math.PI*y));
        }

        public static double Schwefel(double x, double y)
        {
            return -x*Math.Sin(Math.Sqrt(Math.Abs(x))) - y*Math.Sin(Math.Sqrt(Math.Abs(y)));
        }

        public static double Griewangk(double x, double y)
        {
            return (x*x + y*y)/4000 - Math.Cos(x)*Math.Cos(y/Math.Sqrt(2)) + 1;
        }

        public static double Michalewicz(double x, double y)
        {
            return -Math.Sin(x)*Math.Pow(Math.Sin(x*x/Math.PI),20)-Math.Sin(y)*Math.Pow(Math.Sin(y*y/Math.PI),20);
        }

        public static double Easom(double x, double y)
        {
            return Math.Cos(x) * Math.Cos(y) * Math.Exp(-Math.Pow(x - Math.PI, 2) - Math.Pow(y - Math.PI, 2));
        }

        public static double DropWave(double x, double y)
        {
            return -((1 + Math.Cos(12 * Math.Sqrt(x * x + y * y))) / (.5 * (x * x + y * y) + 2));
        }

        public static double Schubert(double x, double y)
        {
            double a,b;
            a = b = 0;
            for (int i = 1; i < 6; i++)
            {
                a += i * Math.Cos((i + 1) * x + 1);
                b += i * Math.Cos((i + 1) * x + 1);
            }
            return -a * b;
        }
        
    }
}
