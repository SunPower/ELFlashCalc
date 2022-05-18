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
                string destFile = tb_directory.Text + "/masterFlashData.csv"; // Path to master csv file
                string cropFolder = System.IO.Path.Combine(tb_directory.Text, "Cropped"); // Create a new folder for Cropped imgs
                progressBar1.Value = 0; // Progress of EL image processing
                progressBar1.Maximum = Directory.GetDirectories(tb_directory.Text).Length + 1; // Set max to size of folders. The "+1" is for the new "Cropped" folder
                progressBar2.Value = 0; // Progress of Flash Calculations
                progressBar2.Maximum = Directory.GetDirectories(tb_directory.Text).Length; // Set max to number of folders
                if (cbELImages.Checked)
                {
                    backgroundWorker1.RunWorkerAsync(argument: cropFolder); // Start a worker to process imgs
                }
                if (cbFlashData.Checked)
                {
                    backgroundWorker2.RunWorkerAsync(argument: destFile); // Start a worker for Flash calculations
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_directory_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0; // Reset progress if selecting a new folder
            progressBar2.Value = 0;
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true; // set to true if a folder was selected
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                tb_directory.Text = dialog.FileName; // Grab text from selected path 
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string cropFolder = (string)e.Argument; // declare/initialize path to "Cropped" folder
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
                string descriptionFile = "";
                // Look for path to description file and store it in a variable
                foreach (var file in Directory.GetFiles(tb_directory.Text))
                {
                    if (System.IO.Path.GetFileName(file).Contains(".csv"))
                    {
                        descriptionFile = file;
                    }
                }
                StreamReader sr = new StreamReader(descriptionFile);
                var dLines = new List<string[]>(); // Declare a new list to store data in descriptionFile
                //Read each line and store it into dLines
                while (!sr.EndOfStream)
                {
                    string[] Line = sr.ReadLine().Split(','); // Read each piece of data separated by a comma
                    dLines.Add(Line);
                }

                var dData = dLines.ToArray(); // Convert to an array for easy access
                sr.Close();

                int row = 60; // Row of img (60 is first row)
                bool isFirstFolder = true;

                System.IO.Directory.CreateDirectory(cropFolder); // Create new folder

                foreach (var path in Directory.GetDirectories(tb_directory.Text)) // Traverse through subfolders in directory
                {
                    foreach (var sub in Directory.GetDirectories(path)) // Traverse through subfolders in subfolder directory
                    {
                        int col = 85;
                        string folder = System.IO.Path.GetFileName(sub);

                        if (folder.Contains("EL")) // if EL folder, process images in this folder
                        {
                            int slide_no = 1; // slide number currently working on
                            int desciptionIndex = 1; // Row or index of sample data. (New name)
                            foreach (var ELImg in Directory.GetFiles(sub)) // Traverse through imgs in EL image folder
                            {
                                if (isFirstFolder && col == 85) // append new slide if inserting image into first row
                                {
                                    presentation.Slides.Append();
                                }
                                if (isFirstFolder)
                                {
                                    // Insert midread on the top
                                    IAutoShape shapeMidread = presentation.Slides[slide_no].Shapes.AppendShape(ShapeType.Rectangle,
                                    new RectangleF(col, 20, 90, 25));
                                    //set the color and fill style
                                    shapeMidread.Fill.FillType = Spire.Presentation.Drawing.FillFormatType.Solid;
                                    shapeMidread.Fill.SolidColor.Color = Color.BlanchedAlmond;
                                    shapeMidread.AppendTextFrame(System.IO.Path.GetFileName(dData[desciptionIndex][3])); // Insert new name into shape
                                    desciptionIndex++;
                                    shapeMidread.TextFrame.Paragraphs[0].Alignment = TextAlignmentType.Center;
                                    shapeMidread.ShapeStyle.LineColor.Color = Color.Empty;


                                    //set the color of text in shape
                                    TextRange textRangeMidread = shapeMidread.TextFrame.TextRange;
                                    textRangeMidread.Fill.FillType = Spire.Presentation.Drawing.FillFormatType.Solid;
                                    //set the Font of text in shape
                                    textRangeMidread.FontHeight = 6;
                                }
                                if (col == 85) // insert name of folder as title on the left
                                {
                                    IAutoShape shapeFolder = presentation.Slides[slide_no].Shapes.AppendShape(ShapeType.Rectangle,
                                    new RectangleF(10, row, 64, 25));
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
                                if (ELImg.Contains(".jpg") || ELImg.Contains(".png")) // if jpg/png img, insert into slide with name
                                {
                                    // TODO: Crop ELImg using square detection and append new image to text frame
                                    Image<Bgr, byte> imgInput;
                                    Image<Gray, byte> CC;

                                    imgInput = new Image<Bgr, byte>(ELImg);
                                    byte[] bytesX = imgInput.ToJpegData();
                                    Image x = (Bitmap)((new ImageConverter()).ConvertFrom(bytesX));
                                    int width=91;
                                    int height=73;
                                    try
                                    {
                                        var temp = imgInput.Convert<Gray, byte>().ThresholdBinary(new Gray(20), new Gray(255))
                                            .Dilate(2).Erode(1);
                                        Mat labels = new Mat();
                                        int nLabels = CvInvoke.ConnectedComponents(temp, labels);
                                        CC = labels.ToImage<Gray, byte>();
                                        byte[] bytesY = temp.ToJpegData();
                                        Image y = (Bitmap)((new ImageConverter()).ConvertFrom(bytesY));

                                        int label = (int)CC[256, 320].Intensity;
                                        if (label != 0)
                                        {
                                            var tempC = CC.InRange(new Gray(label), new Gray(label));
                                            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                                            Mat m = new Mat();

                                            CvInvoke.FindContours(tempC, contours, m, Emgu.CV.CvEnum.RetrType.External,
                                                Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                                            if (contours.Size > 0)
                                            {
                                                Rectangle bbox = CvInvoke.BoundingRectangle(contours[0]);

                                                imgInput.ROI = bbox;
                                                var img = imgInput.Copy();

                                                imgInput.ROI = Rectangle.Empty;

                                                byte[] bytes = img.ToJpegData();
                                                Image z = (Bitmap)((new ImageConverter()).ConvertFrom(bytes));
                                                z.Save(cropFolder + "/" + System.IO.Path.GetFileName(ELImg));
                                                width = z.Width/7;
                                                height = z.Height/7;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                    
                                    RectangleF rect = new RectangleF(col, row, width, height);
                                    try
                                    {
                                        presentation.Slides[slide_no].Shapes.AppendEmbedImage(ShapeType.Rectangle, cropFolder + "/" + System.IO.Path.GetFileName(ELImg), rect);
                                    }
                                    catch
                                    {  
                                        presentation.Slides[slide_no].Shapes.AppendEmbedImage(ShapeType.Rectangle, ELImg, rect);
                                    }
                                       
                                    presentation.Slides[slide_no].Shapes[0].Line.FillFormat.SolidFillColor.Color = Color.FloralWhite;

                                    IAutoShape shapeImgTitle = presentation.Slides[slide_no].Shapes.AppendShape(ShapeType.Rectangle,
                                    new RectangleF(col, row + 70, 91, 17));
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
                                    textRangeImg.FontHeight = 6;

                                    col += 100;
                                }
                                if (col >= 585)
                                {
                                    col = 85;
                                    slide_no++;
                                }
                            }
                            row += 90;
                            
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
            // Append all flash data to a master flash data file
            try
            {
                string destFile = (string)e.Argument;
                StreamWriter fileDest = new StreamWriter(destFile, true);
                int isHeader = 0; // If true, read header

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
            // Initialize variables
            int serialNoCol = 3;
            int midreadNoCol = 2;
            int[] rawFlashDataCols = {5, 6, 7, 8, 9, 10, 11, 12, 13};
            int calCount = 0;
            IDictionary<string, string[]> initValsForModule = new Dictionary<string, string[]>();
            IDictionary<string, string[]> initCalValsForModule = new Dictionary<string, string[]>();

            //
            StreamWriter fileDest = new StreamWriter(tb_directory.Text + "/PercentChangeMasterFlashData.csv", true);
            StreamReader sr = new StreamReader(destFile);
            var lines = new List<string[]>();

            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                lines.Add(Line);
            }

            var data = lines.ToArray();
            
            // Grab initial data
            foreach (var d in data)
            {
                if (d[0] == "ID")
                {
                    continue;
                }
                
                if (d[midreadNoCol].Substring(0,2)== "01" && !d[midreadNoCol].Contains("Cal"))
                {
                    string serialNo = d[serialNoCol].Substring(0, 3);
                    string[] rawFlashData = new string[rawFlashDataCols.Length];
                    int k = 0;
                    foreach (int j in rawFlashDataCols)
                    {
                        rawFlashData[k] = d[j];
                        k++;
                    }
                    initValsForModule[serialNo] = rawFlashData;
                }

                if (calCount < 3 && d[midreadNoCol].Contains("Cal"))
                {
                    string serialNo = d[serialNoCol];
                    string[] rawCalFlashData = new string[rawFlashDataCols.Length];
                    int k = 0;
                    foreach (int j in rawFlashDataCols)
                    {
                        rawCalFlashData[k] = d[j];
                        k++;
                    }
                    initCalValsForModule[serialNo] = rawCalFlashData;
                    calCount++;
                }
            }
            // Perform calculations
            int i = 0;
            foreach (var d in data)
            {
                if (d[0] == "ID")
                {
                    // Create percent change columns
                    foreach (int col in rawFlashDataCols)
                    {
                        lines[0] = new List<string>(lines[0]) { "%Change_" + lines[0][col] }.ToArray();
                    }
                    i++;
                    continue;
                }
                foreach (int col in rawFlashDataCols)
                {
                    float percentChange = 0;
                    try
                    {
                        float initValFloat = 0;
                        // percent change = (current - initial) / initial
                        if (!d[midreadNoCol].Contains("Cal"))
                        {
                            string initVal = initValsForModule[d[serialNoCol].Substring(0, 3)][col - 5];
                            initValFloat = float.Parse(initVal);
                        }
                        if (d[midreadNoCol].Contains("Cal"))
                        {
                            string initCalVal = initCalValsForModule[d[serialNoCol]][col - 5];
                            initValFloat = float.Parse(initCalVal);
                        }
                    
                        float currValFloat = float.Parse(d[col]);
                        percentChange = (currValFloat - initValFloat) / initValFloat;
                    }
                    catch
                    {
                        
                    }
                    
                    lines[i] = new List<string>(lines[i]) { percentChange.ToString() }.ToArray();
                }
                i++;
            }
            data = lines.ToArray();
            foreach (var line in data)
            {
                fileDest.WriteLine(string.Join(",",line));
            }
            fileDest.Close();
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

