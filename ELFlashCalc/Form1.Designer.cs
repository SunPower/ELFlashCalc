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
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.threeCellBtn = new System.Windows.Forms.RadioButton();
            this.oneCellBtn = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.horizontalBtn = new System.Windows.Forms.RadioButton();
            this.verticalBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_directory
            // 
            this.tb_directory.Location = new System.Drawing.Point(12, 51);
            this.tb_directory.Name = "tb_directory";
            this.tb_directory.Size = new System.Drawing.Size(581, 20);
            this.tb_directory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select a Folder";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_calc
            // 
            this.btn_calc.Location = new System.Drawing.Point(543, 232);
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.Size = new System.Drawing.Size(92, 30);
            this.btn_calc.TabIndex = 3;
            this.btn_calc.Text = "Calculate";
            this.btn_calc.UseVisualStyleBackColor = true;
            this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
            // 
            // btn_directory
            // 
            this.btn_directory.Location = new System.Drawing.Point(600, 51);
            this.btn_directory.Name = "btn_directory";
            this.btn_directory.Size = new System.Drawing.Size(35, 20);
            this.btn_directory.TabIndex = 4;
            this.btn_directory.Text = "▪▪▪";
            this.btn_directory.UseVisualStyleBackColor = true;
            this.btn_directory.Click += new System.EventHandler(this.btn_directory_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 172);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(623, 10);
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
            this.lblProgress.Location = new System.Drawing.Point(8, 156);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(104, 13);
            this.lblProgress.TabIndex = 6;
            this.lblProgress.Text = "Progress: EL Images";
            this.lblProgress.Click += new System.EventHandler(this.lblProgress_Click);
            // 
            // cbELImages
            // 
            this.cbELImages.AutoSize = true;
            this.cbELImages.Checked = true;
            this.cbELImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbELImages.Location = new System.Drawing.Point(12, 99);
            this.cbELImages.Name = "cbELImages";
            this.cbELImages.Size = new System.Drawing.Size(76, 17);
            this.cbELImages.TabIndex = 7;
            this.cbELImages.Text = "EL Images";
            this.cbELImages.UseVisualStyleBackColor = true;
            // 
            // cbFlashData
            // 
            this.cbFlashData.AutoSize = true;
            this.cbFlashData.Location = new System.Drawing.Point(12, 122);
            this.cbFlashData.Name = "cbFlashData";
            this.cbFlashData.Size = new System.Drawing.Size(77, 17);
            this.cbFlashData.TabIndex = 8;
            this.cbFlashData.Text = "Flash Data";
            this.cbFlashData.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 16);
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
            this.progressBar2.Location = new System.Drawing.Point(11, 216);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(623, 10);
            this.progressBar2.TabIndex = 10;
            // 
            // lblFlash
            // 
            this.lblFlash.AutoSize = true;
            this.lblFlash.Location = new System.Drawing.Point(8, 200);
            this.lblFlash.Name = "lblFlash";
            this.lblFlash.Size = new System.Drawing.Size(211, 13);
            this.lblFlash.TabIndex = 11;
            this.lblFlash.Text = "Progress: Calculating Flash Data % Change";
            this.lblFlash.Click += new System.EventHandler(this.lblFlash_Click);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork_1);
            this.backgroundWorker3.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker3_ProgressChanged);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.threeCellBtn);
            this.groupBox1.Controls.Add(this.oneCellBtn);
            this.groupBox1.Location = new System.Drawing.Point(240, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 89);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Number of Cells";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // threeCellBtn
            // 
            this.threeCellBtn.AutoSize = true;
            this.threeCellBtn.Location = new System.Drawing.Point(6, 40);
            this.threeCellBtn.Name = "threeCellBtn";
            this.threeCellBtn.Size = new System.Drawing.Size(56, 17);
            this.threeCellBtn.TabIndex = 19;
            this.threeCellBtn.Text = "3 Cells";
            this.threeCellBtn.UseVisualStyleBackColor = true;
            // 
            // oneCellBtn
            // 
            this.oneCellBtn.AutoSize = true;
            this.oneCellBtn.Checked = true;
            this.oneCellBtn.Location = new System.Drawing.Point(6, 17);
            this.oneCellBtn.Name = "oneCellBtn";
            this.oneCellBtn.Size = new System.Drawing.Size(51, 17);
            this.oneCellBtn.TabIndex = 19;
            this.oneCellBtn.TabStop = true;
            this.oneCellBtn.Text = "1 Cell";
            this.oneCellBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.horizontalBtn);
            this.groupBox2.Controls.Add(this.verticalBtn);
            this.groupBox2.Location = new System.Drawing.Point(424, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 89);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vertical or Horizontal Data";
            // 
            // horizontalBtn
            // 
            this.horizontalBtn.AutoSize = true;
            this.horizontalBtn.Checked = true;
            this.horizontalBtn.Location = new System.Drawing.Point(6, 40);
            this.horizontalBtn.Name = "horizontalBtn";
            this.horizontalBtn.Size = new System.Drawing.Size(72, 17);
            this.horizontalBtn.TabIndex = 19;
            this.horizontalBtn.TabStop = true;
            this.horizontalBtn.Text = "Horizontal";
            this.horizontalBtn.UseVisualStyleBackColor = true;
            this.horizontalBtn.CheckedChanged += new System.EventHandler(this.horizontalBtn_CheckedChanged);
            // 
            // verticalBtn
            // 
            this.verticalBtn.AutoSize = true;
            this.verticalBtn.Location = new System.Drawing.Point(6, 17);
            this.verticalBtn.Name = "verticalBtn";
            this.verticalBtn.Size = new System.Drawing.Size(60, 17);
            this.verticalBtn.TabIndex = 19;
            this.verticalBtn.Text = "Vertical";
            this.verticalBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 274);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EL and Flash Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton threeCellBtn;
        private System.Windows.Forms.RadioButton oneCellBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton horizontalBtn;
        private System.Windows.Forms.RadioButton verticalBtn;
    }
}

