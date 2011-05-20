namespace ContourGui
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ContourBox = new System.Windows.Forms.PictureBox();
            this.defaultFunctions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SourceCode = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ErrorText = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.MaxBoxX = new System.Windows.Forms.TextBox();
            this.MinBoxX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MaxBoxY = new System.Windows.Forms.TextBox();
            this.MinBoxY = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ContourBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ContourBox
            // 
            this.ContourBox.BackColor = System.Drawing.SystemColors.Window;
            this.ContourBox.Location = new System.Drawing.Point(124, 2);
            this.ContourBox.Name = "ContourBox";
            this.ContourBox.Size = new System.Drawing.Size(500, 500);
            this.ContourBox.TabIndex = 0;
            this.ContourBox.TabStop = false;
            // 
            // defaultFunctions
            // 
            this.defaultFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaultFunctions.FormattingEnabled = true;
            this.defaultFunctions.Items.AddRange(new object[] {
            "De Jong 1",
            "Rosenbrock\'s Valley",
            "Rastrigin\'s Function",
            "Schwefel\'s Function",
            "Griewangk\'s Function",
            "Michalewicz\'s Function",
            "Easom\'s Function",
            "Drop Wave Function",
            "Schubert\'s Function",
            "User Entered"});
            this.defaultFunctions.Location = new System.Drawing.Point(316, 508);
            this.defaultFunctions.Name = "defaultFunctions";
            this.defaultFunctions.Size = new System.Drawing.Size(121, 21);
            this.defaultFunctions.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 516);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Function";
            // 
            // SourceCode
            // 
            this.SourceCode.Location = new System.Drawing.Point(25, 609);
            this.SourceCode.Name = "SourceCode";
            this.SourceCode.Size = new System.Drawing.Size(700, 115);
            this.SourceCode.TabIndex = 6;
            this.SourceCode.Text = "public class userclass\n{\n     public static double func(double x, double y)\n     " +
                "{\n          return System.Math.Sqrt(x*x + y*y);\n      }\n}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 593);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enter Your Own Function - Replace the body of func with your code.";
            // 
            // ErrorText
            // 
            this.ErrorText.Location = new System.Drawing.Point(25, 743);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(700, 73);
            this.ErrorText.TabIndex = 6;
            this.ErrorText.TabStop = false;
            this.ErrorText.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 727);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Errors";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(499, 508);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 21);
            this.button1.TabIndex = 7;
            this.button1.Text = "Draw Contour";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MaxBoxX
            // 
            this.MaxBoxX.Location = new System.Drawing.Point(142, 551);
            this.MaxBoxX.Name = "MaxBoxX";
            this.MaxBoxX.Size = new System.Drawing.Size(89, 20);
            this.MaxBoxX.TabIndex = 2;
            // 
            // MinBoxX
            // 
            this.MinBoxX.Location = new System.Drawing.Point(271, 551);
            this.MinBoxX.Name = "MinBoxX";
            this.MinBoxX.Size = new System.Drawing.Size(89, 20);
            this.MinBoxX.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 535);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Max Val For X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 535);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Min Val For X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(388, 535);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Max Val For Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(496, 535);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Min Val For Y";
            // 
            // MaxBoxY
            // 
            this.MaxBoxY.Location = new System.Drawing.Point(391, 551);
            this.MaxBoxY.Name = "MaxBoxY";
            this.MaxBoxY.Size = new System.Drawing.Size(89, 20);
            this.MaxBoxY.TabIndex = 4;
            // 
            // MinBoxY
            // 
            this.MinBoxY.Location = new System.Drawing.Point(499, 551);
            this.MinBoxY.Name = "MinBoxY";
            this.MinBoxY.Size = new System.Drawing.Size(89, 20);
            this.MinBoxY.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 832);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MinBoxY);
            this.Controls.Add(this.MinBoxX);
            this.Controls.Add(this.MaxBoxY);
            this.Controls.Add(this.MaxBoxX);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ErrorText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SourceCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.defaultFunctions);
            this.Controls.Add(this.ContourBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ContourBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ContourBox;
        private System.Windows.Forms.ComboBox defaultFunctions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox SourceCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox ErrorText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox MaxBoxX;
        private System.Windows.Forms.TextBox MinBoxX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox MaxBoxY;
        private System.Windows.Forms.TextBox MinBoxY;
    }
}

