namespace ELFlashCalc
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
            this.tb_directory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_calc = new System.Windows.Forms.Button();
            this.btn_directory = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblProgress = new System.Windows.Forms.Label();
            this.cbELImages = new System.Windows.Forms.CheckBox();
            this.cbFlashData = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.lblFlash = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_directory
            // 
            this.tb_directory.Location = new System.Drawing.Point(16, 63);
            this.tb_directory.Margin = new System.Windows.Forms.Padding(4);
            this.tb_directory.Name = "tb_directory";
            this.tb_directory.Size = new System.Drawing.Size(773, 22);
            this.tb_directory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select a Folder";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_calc
            // 
            this.btn_calc.Location = new System.Drawing.Point(724, 286);
            this.btn_calc.Margin = new System.Windows.Forms.Padding(4);
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.Size = new System.Drawing.Size(123, 37);
            this.btn_calc.TabIndex = 3;
            this.btn_calc.Text = "Calculate";
            this.btn_calc.UseVisualStyleBackColor = true;
            this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
            // 
            // btn_directory
            // 
            this.btn_directory.Location = new System.Drawing.Point(800, 63);
            this.btn_directory.Margin = new System.Windows.Forms.Padding(4);
            this.btn_directory.Name = "btn_directory";
            this.btn_directory.Size = new System.Drawing.Size(47, 25);
            this.btn_directory.TabIndex = 4;
            this.btn_directory.Text = "▪▪▪";
            this.btn_directory.UseVisualStyleBackColor = true;
            this.btn_directory.Click += new System.EventHandler(this.btn_directory_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 212);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(831, 12);
            this.progressBar1.TabIndex = 5;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(11, 192);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(132, 16);
            this.lblProgress.TabIndex = 6;
            this.lblProgress.Text = "Progress: EL Images";
            this.lblProgress.Click += new System.EventHandler(this.lblProgress_Click);
            // 
            // cbELImages
            // 
            this.cbELImages.AutoSize = true;
            this.cbELImages.Location = new System.Drawing.Point(16, 122);
            this.cbELImages.Margin = new System.Windows.Forms.Padding(4);
            this.cbELImages.Name = "cbELImages";
            this.cbELImages.Size = new System.Drawing.Size(93, 20);
            this.cbELImages.TabIndex = 7;
            this.cbELImages.Text = "EL Images";
            this.cbELImages.UseVisualStyleBackColor = true;
            // 
            // cbFlashData
            // 
            this.cbFlashData.AutoSize = true;
            this.cbFlashData.Location = new System.Drawing.Point(16, 150);
            this.cbFlashData.Margin = new System.Windows.Forms.Padding(4);
            this.cbFlashData.Name = "cbFlashData";
            this.cbFlashData.Size = new System.Drawing.Size(94, 20);
            this.cbFlashData.TabIndex = 8;
            this.cbFlashData.Text = "Flash Data";
            this.cbFlashData.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Please Select Data to Process";
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(15, 266);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(831, 12);
            this.progressBar2.TabIndex = 10;
            // 
            // lblFlash
            // 
            this.lblFlash.AutoSize = true;
            this.lblFlash.Location = new System.Drawing.Point(11, 246);
            this.lblFlash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlash.Name = "lblFlash";
            this.lblFlash.Size = new System.Drawing.Size(267, 16);
            this.lblFlash.TabIndex = 11;
            this.lblFlash.Text = "Progress: Calculating Flash Data % Change";
            this.lblFlash.Click += new System.EventHandler(this.lblFlash_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 337);
            this.Controls.Add(this.lblFlash);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFlashData);
            this.Controls.Add(this.cbELImages);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_directory);
            this.Controls.Add(this.btn_calc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_directory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EL and Flash Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_directory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_calc;
        private System.Windows.Forms.Button btn_directory;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.CheckBox cbELImages;
        private System.Windows.Forms.CheckBox cbFlashData;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label lblFlash;
    }
}

