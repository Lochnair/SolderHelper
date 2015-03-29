
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace SolderHelper
{
    partial class MainForm : System.Windows.Forms.Form
    {

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.btn_browseMods = new System.Windows.Forms.Button();
            this.txt_mods = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btn_browseOutput = new System.Windows.Forms.Button();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btn_run = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_browseMods
            // 
            this.btn_browseMods.Location = new System.Drawing.Point(349, 9);
            this.btn_browseMods.Name = "btn_browseMods";
            this.btn_browseMods.Size = new System.Drawing.Size(57, 20);
            this.btn_browseMods.TabIndex = 0;
            this.btn_browseMods.Text = "Browse";
            this.btn_browseMods.UseVisualStyleBackColor = true;
            this.btn_browseMods.Click += new System.EventHandler(this.btn_browseMods_Click);
            // 
            // txt_mods
            // 
            this.txt_mods.BackColor = System.Drawing.Color.White;
            this.txt_mods.Location = new System.Drawing.Point(89, 9);
            this.txt_mods.Name = "txt_mods";
            this.txt_mods.ReadOnly = true;
            this.txt_mods.Size = new System.Drawing.Size(254, 20);
            this.txt_mods.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(65, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Mods folder:";
            // 
            // btn_browseOutput
            // 
            this.btn_browseOutput.Location = new System.Drawing.Point(349, 39);
            this.btn_browseOutput.Name = "btn_browseOutput";
            this.btn_browseOutput.Size = new System.Drawing.Size(57, 20);
            this.btn_browseOutput.TabIndex = 3;
            this.btn_browseOutput.Text = "Browse";
            this.btn_browseOutput.UseVisualStyleBackColor = true;
            this.btn_browseOutput.Click += new System.EventHandler(this.btn_browseOutput_Click);
            // 
            // txt_output
            // 
            this.txt_output.BackColor = System.Drawing.Color.White;
            this.txt_output.Location = new System.Drawing.Point(89, 39);
            this.txt_output.Name = "txt_output";
            this.txt_output.ReadOnly = true;
            this.txt_output.Size = new System.Drawing.Size(254, 20);
            this.txt_output.TabIndex = 4;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 42);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 13);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Output folder:";
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(349, 65);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(57, 20);
            this.btn_run.TabIndex = 6;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 95);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txt_output);
            this.Controls.Add(this.btn_browseOutput);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txt_mods);
            this.Controls.Add(this.btn_browseMods);
            this.Name = "MainForm";
            this.Text = "SolderHelper v0.2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.Button btn_browseMods;
        internal System.Windows.Forms.TextBox txt_mods;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btn_browseOutput;
        internal System.Windows.Forms.TextBox txt_output;
        internal System.Windows.Forms.Label Label2;

        internal System.Windows.Forms.Button btn_run;
    }
}