using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CreateContour;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection; 

namespace ContourTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Contour my_contour = new Contour(6, -6, 6, -6, 1000, 1000);
            surf_func my_func = dist;
            my_contour.file_name = "c:\\complex_func.bmp";
            my_contour.create_contour(my_func);

            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;

            string SourceString = @"public class myclass 
                             { 
                                 public static double testd(double x, double y) 
                                 { 
                                     return System.Math.Sqrt(x*x + y*y); 
                                 } 
                             }";


            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, SourceString);
            if (results.Errors.Count > 0)
            {
                foreach (CompilerError CompErr in results.Errors)
                {
                    Console.WriteLine("Line number " + CompErr.Line + ", Error Number: " + CompErr.ErrorNumber + ", '" + CompErr.ErrorText + ";");
                }
                Console.ReadLine();
            } 
            
            Assembly mAssembly = results.CompiledAssembly;

            Type scripttype = mAssembly.GetType("myclass");
            Contour contour2 = new Contour(100, -100, 100, -100, 1000, 1000);
            contour2.file_name = "c:\\distance.bmp";
            string name = "testd";
            contour2.create_contour(ref scripttype, ref name);


        }

        public static double dist(double x, double y)
        {
            //return Math.Sqrt(x*x + y*y);
            //return Math.Sqrt(2*x*y - x);
            //return (x*x + y*y);
            //return (100 * Math.Pow((y - x * x), 2) + Math.Pow((1 - x), 2));
            //return Math.Cos(x) * Math.Cos(y) * Math.Exp(-Math.Pow(x - Math.PI, 2) - Math.Pow(y - Math.PI, 2));
            return -((1+Math.Cos(12*Math.Sqrt(x*x+y*y)))/(.5*(x*x + y*y)+2));
        }
    }
}
