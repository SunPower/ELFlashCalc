using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Microsoft.WindowsAPICodePack.Dialogs;
using Spire.Presentation;
using Spire.Presentation.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELFlashCalc
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> img;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void lblProgress_Click(object sender, EventArgs e)
        {

        }
        private void btn_calc_Click(object sender, EventArgs e)
        {
            try
            {
                string destFile = tb_directory.Text + "/masterFlashData.csv";
                progressBar1.Value = 0;
                progressBar1.Maximum = Directory.GetDirectories(tb_directory.Text).Length;
                progressBar2.Value = 0;
                progressBar2.Maximum = Directory.GetDirectories(tb_directory.Text).Length;
                if (cbELImages.Checked)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                if (cbFlashData.Checked)
                {
                    backgroundWorker2.RunWorkerAsync(argument: destFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            /*foreach (var path in Directory.GetFiles(tb_directory.Text)) 
            {
                Console.WriteLine(path); // full path
                Console.WriteLine(System.IO.Path.GetFileName(path)); // file name
            }*/
        }

        private void btn_directory_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0; 
            progressBar2.Value = 0;
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                tb_directory.Text = dialog.FileName;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Presentation presentation = new Presentation();

                //append new shape
                IAutoShape shapeTitle = presentation.Slides[0].Shapes.AppendShape(ShapeType.Rectangle,
                    new RectangleF(0, 0, presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height));
                //set the LineColor
                shapeTitle.ShapeStyle.LineColor.Color = Color.Empty;
                //set the color and fill style
                shapeTitle.Fill.FillType = Spire.Presentation.Drawing.FillFormatType.Solid;
                shapeTitle.Fill.SolidColor.Color = Color.White;
                shapeTitle.AppendTextFrame(System.IO.Path.GetFileName(tb_directory.Text));
                shapeTitle.TextFrame.Paragraphs[0].Alignment = TextAlignmentType.Center;

                //set the color of text in shape
                TextRange textRange = shapeTitle.TextFrame.TextRange;
                textRange.Fill.FillType = Spire.Presentation.Drawing.FillFormatType.Solid;
                //set the Font of text in shape
                textRange.FontHeight = 21;


                int col = 85;
                bool isFirstFolder = true;


                foreach (var path in Directory.GetDirectories(tb_directory.Text)) // Traverse through subfolders in directory
                {
                    foreach (var sub in Directory.GetDirectories(path)) // Traverse through subfolders in subfolder directory
                    {
                        int row = 60; // Row of img (60 is first row)
                        string folder = System.IO.Path.GetFileName(sub);

                        if (folder.Contains("EL"))
                        {
                            int slide_no = 1;
                            foreach (var ELImg in Directory.GetFiles(sub)) // Traverse through imgs in EL image folder
                            {
                                if (isFirstFolder && row == 60) // append new slide if inserting image into first row
                                {
                                    presentation.Slides.Append();
                                }
                                if (isFirstFolder)
                                {
                                    // Insert midread on the left
                                    IAutoShape shapeMidread = presentation.Slides[slide_no].Shapes.AppendShape(ShapeType.Rectangle,
                                    new RectangleF(10, row + 15, 64, 25));
                                    //set the color and fill style
                                    shapeMidread.Fill.FillType = Spire.Presentation.Drawing.FillFormatType.Solid;
                                    shapeMidread.Fill.SolidColor.Color = Color.BlanchedAlmond;
                                    shapeMidread.AppendTextFrame(System.IO.Path.GetFileName("insert midread"));
                                    shapeMidread.TextFrame.Paragraphs[0].Alignment = TextAlignmentType.Center;
                                    shapeMidread.ShapeStyle.LineColor.Color = Color.Empty;


                                    //set the color of text in shape
                                    TextRange textRangeMidread = shapeMidread.TextFrame.TextRange;
                                    textRangeMidread.Fill.FillType = Spire.Presentation.Drawing.FillFormatType.Solid;
                                    //set the Font of text in shape
                                    textRangeMidread.FontHeight = 6;
                                }
                                if (row == 60) // insert name of folder as title
                                {
                                    IAutoShape shapeFolder = presentation.Slides[slide_no].Shapes.AppendShape(ShapeType.Rectangle,
                                    new RectangleF(col, 20, 64, 25));
                                    //set the color and fill style
                                    shapeFolder.Fill.FillType = Spire.Presentation.Drawing.FillFormatType.Solid;
                                    shapeFolder.Fill.SolidColor.Color = Color.LightGray;
                                    shapeFolder.AppendTextFrame(System.IO.Path.GetFileName(path));
                                    shapeFolder.TextFrame.Paragraphs[0].Alignment = TextAlignmentType.Center;
                                    shapeFolder.ShapeStyle.LineColor.Color = Color.Empty;

                                    //set the color of text in shape
                                    TextRange textRangeFolder = shapeFolder.TextFrame.TextRange;
                                    textRangeFolder.Fill.FillType = Spire.Presentation.Drawing.FillFormatType.Solid;
                                    //set the Font of text in shape
                                    textRangeFolder.FontHeight = 6;
                                }
                                if (ELImg.Contains(".jpg")) // if jpg img, insert into slide with name
                                {
                                    // TODO: Crop ELImg using square detection and append new image to text frame
                                    /*img = new Image<Bgr, byte>(ELImg);
                                    var temp = img.SmoothGaussian(5).Convert<Gray,byte>().ThresholdBinary(new Gray(230),new Gray(255)); // Any pixel 230+ is set to 255
                                    VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                                    Mat m = new Mat();

                                    CvInvoke.FindContours(temp,contours,m,Emgu.CV.CvEnum.RetrType.External,Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
                                    
                                    
                                    double perimeter = CvInvoke.ArcLength(contours[0], true);
                                    VectorOfPoint approx = new VectorOfPoint();
                                    CvInvoke.ApproxPolyDP(contours[0], approx, 0.04 * perimeter, true);

                                    CvInvoke.DrawContours(img, contours, 0, new MCvScalar(0, 0, 255));
                                    var moments = CvInvoke.Moments(contours[0]);
                                    int x = (int)(moments.M10 / moments.M00);
                                    int y = (int)(moments.M01 / moments.M00);*/

                                    RectangleF rect = new RectangleF(col, row, 64, 51);
                                    presentation.Slides[slide_no].Shapes.AppendEmbedImage(ShapeType.Rectangle, ELImg, rect);
                                    presentation.Slides[slide_no].Shapes[0].Line.FillFormat.SolidFillColor.Color = Color.FloralWhite;

                                    IAutoShape shapeImgTitle = presentation.Slides[slide_no].Shapes.AppendShape(ShapeType.Rectangle,
                                    new RectangleF(col, row + 53, 64, 17));
                                    //set the color and fill style
                                    shapeImgTitle.Fill.FillType = Spire.Presentation.Drawing.FillFormatType.Solid;
                                    shapeImgTitle.Fill.SolidColor.Color = Color.Beige;
                                    shapeImgTitle.AppendTextFrame(System.IO.Path.GetFileName(ELImg));
                                    shapeImgTitle.TextFrame.Paragraphs[0].Alignment = TextAlignmentType.Center;
                                    shapeImgTitle.ShapeStyle.LineColor.Color = Color.Empty;

                                    //set the color of text in shape
                                    TextRange textRangeImg = shapeImgTitle.TextFrame.TextRange;
                                    textRangeImg.Fill.FillType = Spire.Presentation.Drawing.FillFormatType.Solid;
                                    //set the Font of text in shape
                                    textRangeImg.FontHeight = 4;

                                    row += 75;
                                }
                                if (row >= 360)
                                {
                                    row = 60;
                                    slide_no++;
                                }
                            }
                            col += 75;
                            isFirstFolder = false;


                        }
                    }
                    backgroundWorker1.ReportProgress(0);
                }

                presentation.SaveToFile(tb_directory.Text + "/ELImages.PPTx", FileFormat.Pptx2013);
                System.Diagnostics.Process.Start(tb_directory.Text + "/ELImages.PPTx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string destFile = (string)e.Argument;
                StreamWriter fileDest = new StreamWriter(destFile, true);
                int isHeader = 0; // if true, read header

                foreach (var path in Directory.GetDirectories(tb_directory.Text)) // Traverse through subfolders in directory
                {
                    foreach (var file in Directory.GetFiles(path)) // Traverse through subfolders in subfolder directory
                    {
                        if (file.Contains(".csv"))
                        {
                            string[] lines = File.ReadAllLines(file);

                            if (isHeader > 0)
                            {
                                lines = lines.Skip(1).ToArray(); // Skip header for all files except for first
                                
                            }

                            foreach (string line in lines)
                            {
                                fileDest.WriteLine(line);
                            }
                            isHeader++;
                        }
                        
                    }
                    backgroundWorker2.ReportProgress(0);
                }
                fileDest.Close();
                calcPercentChange(destFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
        }
        private void calcPercentChange(string destFile)
        {
            StreamReader sr = new StreamReader(destFile);
            var lines = new List<string[]>();

            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                lines.Add(Line);
            }

            var data = lines.ToArray();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value += 1;
        }
        
        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value += 1;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void lblFlash_Click(object sender, EventArgs e)
        {

        }
    }
}

