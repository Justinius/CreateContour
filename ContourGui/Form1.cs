using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection; 
using CreateContour;

namespace ContourGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //double DeJongX_max = 6, DeJongX_min = -6;
            //double RosenbrockX_max = 2, RosenbrockX_min = -2;
            //double RastriginX_max = 4, RastriginX_min = -4;
            //double SchwefelX_max = 100, SchwefelX_min = -100;
            //double GriewangkX_max = 10, GriewangkX_min = -10;
            //double MichalewiczX_max = 4, MichalewiczX_min = 0;
            //double EasomX_max = 20, EasomX_min = -20;
            //double DropWaveX_max = 1, DropWaveX_min = -1;
            //double SchubertX_max = 4, SchubertX_min = -4;

            if (MaxBoxX.Text.Equals(""))
                MaxBoxX.Text = "100";
            if (MinBoxX.Text.Equals(""))
                MinBoxX.Text = "-100";

            if (MaxBoxY.Text.Equals(""))
                MaxBoxY.Text = "100";
            if (MinBoxY.Text.Equals(""))
                MinBoxY.Text = "-100";

            double maxX_v = double.Parse(MaxBoxX.Text);
            double minX_v = double.Parse(MinBoxX.Text);
            double maxY_v = double.Parse(MaxBoxY.Text);
            double minY_v = double.Parse(MinBoxY.Text);

            if (maxX_v == minX_v)
                maxX_v = minX_v + 100;
            if (maxX_v < minX_v)
            {
                double temp = maxX_v;
                maxX_v = minX_v;
                minX_v = temp;
            }

            if (maxY_v == minY_v)
                maxY_v = minY_v + 100;
            if (maxY_v < minY_v)
            {
                double temp = maxY_v;
                maxY_v = minY_v;
                minY_v = temp;
            }

            Contour this_contour = new Contour(maxX_v, minX_v, maxY_v, minY_v, 500, 500);
                    
            //De Jong 1
            //Rosenbrock's Valley
            //Rastrigin's Function
            //Schwefel's Function
            //Griewangk's Function
            //Michalewicz's Function
            //Easom's Function
            //Drop Wave Function
            //Schubert's Function
            //User Entered
            switch(defaultFunctions.SelectedIndex)
            {
                case 0:
                    this_contour.create_contour(Program.DeJong);
                    break;
                case 1:
                    this_contour.create_contour(Program.Rosenbrock);
                    break;
                case 2:
                    this_contour.create_contour(Program.Rastrigin);
                    break;
                case 3:
                    this_contour.create_contour(Program.Schwefel);
                    break;
                case 4:
                    this_contour.create_contour(Program.Griewangk);
                    break;
                case 5:
                    this_contour.create_contour(Program.Michalewicz);
                    break;
                case 6:
                    this_contour.create_contour(Program.Easom);
                    break;
                case 7:
                    this_contour.create_contour(Program.DropWave);
                    break;
                case 8:
                    this_contour.create_contour(Program.Schubert);
                    break;
                case 9:
                    CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
                    CompilerParameters parameters = new CompilerParameters();
                    parameters.GenerateInMemory = true;
                    
                    string SourceString = SourceCode.Text;
                    CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, SourceString);
                    
                    string error_string = "";
                    if (results.Errors.Count > 0)
                    {
                        foreach (CompilerError CompErr in results.Errors)
                        {
                            error_string = String.Format("{0} \n Line number " + CompErr.Line + ", Error Number: " + CompErr.ErrorNumber + ", '" + CompErr.ErrorText + ";", error_string);
                        }
                        ErrorText.Text = error_string;
                        return;
                    }

                    Assembly mAssembly = results.CompiledAssembly;
                    
                    #region error checking
                    MethodInfo[] user_meth = mAssembly.GetType("userclass").GetMethods(BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static);
                    if (user_meth.Length != 1)
                    {
                        ErrorText.Text = "Either no class: \"userclass\" or no functions were defined.";
                        return;
                    }

                    string func_name = user_meth[0].Name;

                    ParameterInfo[] param = user_meth[0].GetParameters();
                    if (param.Length != 2)
                    {
                        ErrorText.Text = "Function has an incorrect number of parameters: Should be 2.";
                        return;
                    }

                    if (param[0].ParameterType != Type.GetType("System.Double") || param[1].ParameterType != Type.GetType("System.Double"))
                    {
                        ErrorText.Text = "Function requires parameters of type double.";
                        return;
                    }

                    if (user_meth[0].ReturnType != Type.GetType("System.Double"))
                    {
                        ErrorText.Text = "Function returns an incorrect data type: Should be double.";
                        return;
                    }

                    if (user_meth[0].ReturnType != Type.GetType("System.Double"))
                    {
                        ErrorText.Text = "Function returns an incorrect data type: Should be double.";
                        return;
                    }
                    #endregion

                    Type script = mAssembly.GetType("userclass");
                    this_contour.create_contour(ref script, ref func_name);
 
                    break;
                default:
                    ErrorText.Text = "Nothing Selected.";
                    break;
            }


            ContourBox.Image = this_contour.contour_bmp;
        }

                
    }
}
