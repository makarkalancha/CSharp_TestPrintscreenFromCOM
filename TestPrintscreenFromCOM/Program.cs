using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace TestPrintscreenFromCOM
{
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        public static void Main()
        {
            //STAThreadAttribute.
            Program.TakeAShotMozilla();
        }
        
        public static void TakeAShotMozilla()
        {
            //Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
            //    Screen.PrimaryScreen.Bounds.Height);
            //Graphics graphics = Graphics.FromImage(printscreen as Image);
            //graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            //printscreen.Save(@"c:\printscreen.jpg", ImageFormat.Jpeg);

            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Image Capture: Image Name, File Format and Destination";
            saveFileDialog1.FileName = "Screenshot";
            saveFileDialog1.InitialDirectory = @"c:\";
            saveFileDialog1.DefaultExt = "jpg";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.Filter = "Jpeg Image (JPG)|*.jpg|PNG Image|*.png|GIF Image (GIF)|*.gif|Bitmap (BMP)|*.bmp|EWM Image|*.emf|TIFF Image|*.tiff|Windows Metafile (WMF)|*.wmf|Exchangable image file|*.exif";
            saveFileDialog1.FilterIndex = 1;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImageFormat fmtStyle;
                switch (saveFileDialog1.FilterIndex)
                {
                    case 2: fmtStyle = ImageFormat.Png; break;
                    case 3: fmtStyle = ImageFormat.Gif; break;
                    case 4: fmtStyle = ImageFormat.Bmp; break;
                    case 5: fmtStyle = ImageFormat.Emf; break;
                    case 6: fmtStyle = ImageFormat.Tiff; break;
                    case 7: fmtStyle = ImageFormat.Wmf; break;
                    case 8: fmtStyle = ImageFormat.Exif; break;
                    default: fmtStyle = ImageFormat.Jpeg; break;
                }
                printscreen.Save(saveFileDialog1.FileName, fmtStyle);
            }
        }
        
        //[DllImport("SampleBars.dll")]
        //public static extern void TakeAShot();
        
    }

    //[ComImport, Guid("AE07101B-46D4-4a98-AF68-0333EA26E113")]
    //class HelloWorldBar
    //{
    //    public extern static void TakeShot();
    //}
}
