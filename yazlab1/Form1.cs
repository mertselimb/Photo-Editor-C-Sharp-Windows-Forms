using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazlab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region publicDefinitions
        Bitmap bitmapMain;
        Bitmap reOpen;
        Bitmap back;
        #endregion
        #region bugKillers
        private bool emptyBMP()
        {
            bool error = false;
            if (bitmapMain == null) {
                MessageBox.Show("There is no image to process please browse a image.",
                               "Browse first",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                error = true;
            }
            return error;
        }
        private bool emptyTextBox()
        {
            bool error = false;
            if (textX.Text == "" || textY.Text == "")
            {
                MessageBox.Show("There is no value in the scale bar.",
                               "Write numbers in scale bar",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                error = true;
            }
            return error;
        }
        #endregion
        #region browse  
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Wrap the creation of the OpenFileDialog instance in a using statement,
            // rather than manually calling the Dispose method to ensure proper disposal
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image files (*.inputImage ; *.jpg)|*.inputImage;*.jpg";

                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    ptbDisplay.Image = new Bitmap(dlg.FileName);
                    bitmapMain = new Bitmap(dlg.FileName);
                    reOpen = new Bitmap(dlg.FileName);
                    back = new Bitmap(dlg.FileName);
                }
            }
        }
        #endregion 
        #region histogram
        private void btnHistogram_Click(object sender, EventArgs e)
        {

        }

        #endregion
        #region userHelpers
        private void btnReOpen_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            ptbDisplay.Image = reOpen;
        }

        private void btnCloseReOpen_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            ptbDisplay.Image = bitmapMain;
        }

        private void save()
        {
            if (emptyBMP() == true)
            {
                return;
            }
            back = bitmapMain;
        }

        private void btnGoStart_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            bitmapMain = reOpen;
            ptbDisplay.Image = bitmapMain;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            bitmapMain = back;
            ptbDisplay.Image = back;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            using (SaveFileDialog dlgSave = new SaveFileDialog())
            {
                dlgSave.Title = "Save Image";
                dlgSave.Filter = "Bitmap Images (*.bmp)|*.bmp|All Files (*.*)|*.*";
                if (dlgSave.ShowDialog(this) == DialogResult.OK)
                {
                    //If user clicked OK, then save the image into the specified file
                    bitmapMain.Save(dlgSave.FileName);
                }
            }
        }
        #endregion
        #region rotate
        private void btnRotataMinus90_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            save();
            RotateImage(bitmapMain, -90);
            ptbDisplay.Image = bitmapMain;
        }

        private void btnRotataPlus90_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            save();
            RotateImage(bitmapMain, +90);
            ptbDisplay.Image = bitmapMain;
        }

        public Bitmap transpozeImage(Bitmap image)
        {
            //TRANSPOZE
            int width = bitmapMain.Width;
            int height = bitmapMain.Height;

            Bitmap transpozeImg = new Bitmap(height, width);
            for (int mainX = 0; mainX < width; mainX++)
            {
                for (int mainY = 0; mainY < height; mainY++)
                {
                    //get source pixel value
                    Color p = bitmapMain.GetPixel(mainX, mainY);

                    //set mirror pixel value
                    transpozeImg.SetPixel(mainY, mainX, p);
                }
            }

            return transpozeImg;
        }

        public Bitmap reverseColumn(Bitmap image)
        {
            Bitmap reversedColumns = new Bitmap(image.Width, image.Height);

            for (int newX = 0; newX < image.Width; newX++)
            {
                for (int newY = 0, maxY = image.Height - 1; newY < image.Height - 1; newY++, maxY--)
                {
                    if (maxY < 0)
                    {
                        break;
                    }
                    //get source pixel value
                    Color p = image.GetPixel(newX, newY);

                    //set mirror pixel value
                    reversedColumns.SetPixel(newX, maxY, p);
                }
            }

            return reversedColumns;
        }

        public Bitmap reverseRows(Bitmap image)
        {
            Bitmap reversedRows = new Bitmap(image.Width, image.Height);

            for (int mainY = 0; mainY < image.Height; mainY++)
            {
                for (int mainX = 0, maxX = image.Width - 1; mainX < image.Width - 1; mainX++, maxX--)
                {
                    if (maxX < 0)
                    {
                        break;
                    }
                    //get source pixel value
                    Color p = image.GetPixel(mainX, mainY);

                    //set mirror pixel value
                    reversedRows.SetPixel(maxX, mainY, p);
                }
            }

            return reversedRows;
        }

        public void RotateImage(Bitmap image, float angle)
        {
            Bitmap newImage = transpozeImage(image);
            if (angle == -90)
            {
                newImage = transpozeImage(image);
                newImage = reverseColumn(newImage);
                bitmapMain = newImage;
                ptbDisplay.Image = bitmapMain;
            }
            else if (angle == 90)
            {
                newImage = transpozeImage(image);
                newImage = reverseRows(newImage);
                bitmapMain = newImage;
                ptbDisplay.Image = bitmapMain;

            }
        }

        #endregion
        #region negative
        private void btnNegative_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            save();
            Negative();
            ptbDisplay.Image = bitmapMain;
        }

        private void Negative()
        {
            Bitmap image = bitmapMain;
            int w = image.Width;
            int h = image.Height;
            BitmapData srcData = image.LockBits(new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int bytes = srcData.Stride * srcData.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];
            Marshal.Copy(srcData.Scan0, buffer, 0, bytes);
            image.UnlockBits(srcData);
            int current = 0;
            int cChannels = 3;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    current = y * srcData.Stride + x * 4;
                    for (int c = 0; c < cChannels; c++)
                    {
                        result[current + c] = (byte)(255 - buffer[current + c]);
                    }
                    result[current + 3] = 255;
                }
            }
            Bitmap resImg = new Bitmap(w, h);
            BitmapData resData = resImg.LockBits(new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(result, 0, resData.Scan0, bytes);
            resImg.UnlockBits(resData);
            bitmapMain = resImg;
        }//versiyonla
        #endregion
        #region grayScale
        private void btnGrayScale_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            save();
            ConvertBitmapToGrayscale();
            ptbDisplay.Image = bitmapMain;
        }

        private void ConvertBitmapToGrayscale()
        {
            Bitmap bmp = bitmapMain;
            //Lock bitmap's bits to system memory
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);

            //Scan for the first line
            IntPtr ptr = bmpData.Scan0;

            //Declare an array in which your RGB values will be stored
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            //Copy RGB values in that array
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int i = 0; i < rgbValues.Length; i += 3)
            {
                //Set RGB values in a Array where all RGB values are stored
                byte gray = (byte)(rgbValues[i] * .21 + rgbValues[i + 1] * .71 + rgbValues[i + 2] * .071);
                rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = gray;
            }

            //Copy changed RGB values back to bitmap
            Marshal.Copy(rgbValues, 0, ptr, bytes);

            //Unlock the bits
            bmp.UnlockBits(bmpData);
            bitmapMain = bmp;
        }//versiyonla
        #endregion
        #region channel
        private void btnRedChannel_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            save();
            channel("red");
            ptbDisplay.Image = bitmapMain;
        }

        private void btnBlueChannel_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            save();
            channel("blue");
            ptbDisplay.Image = bitmapMain;
        }

        private void btnGreenChannel_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            save();
            channel("green");
            ptbDisplay.Image = bitmapMain;
        }

        private void channel(string color){
            int width = bitmapMain.Width;
            int height = bitmapMain.Height;

            //3 bitmap for red green blue image
            Bitmap rbmp = new Bitmap(bitmapMain);
            Bitmap gbmp = new Bitmap(bitmapMain);
            Bitmap bbmp = new Bitmap(bitmapMain);

            //red green blue image
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = bitmapMain.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    if (color == "red") {
                     //set red image pixel
                     rbmp.SetPixel(x, y, Color.FromArgb(a, r, 0, 0));
                    } else if(color == "green") {
                    //set green image pixel
                    gbmp.SetPixel(x, y, Color.FromArgb(a, 0, g, 0));
                    }else if (color == "blue") {
                    //set blue image pixel
                    bbmp.SetPixel(x, y, Color.FromArgb(a, 0, 0, b));
                    }
                }
            }
            if (color == "red")
            {
                bitmapMain = rbmp;
            }
            else if (color == "green")
            {
                bitmapMain = gbmp;
            }
            else if (color == "blue")
            {
                bitmapMain = bbmp;
            }
            
        }//versiyonla
        #endregion
        #region mirror
        private void btnMirrorLeft_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            save();
            int width = bitmapMain.Width;
            int height = bitmapMain.Height;
           
            //mirror image
            Bitmap mirrorImg = new Bitmap(width, height);

            for (int y = 0; y < height-1 ; y++)
            {
                for (int leftX = 0, rightX = width-1; leftX < width; leftX++, rightX--)
                {
                    //get source pixel value
                    Color p = bitmapMain.GetPixel(leftX, y);

                    //set mirror pixel value
                    mirrorImg.SetPixel(leftX, y, p);
                    mirrorImg.SetPixel(rightX, y, p);
                }
            }

            bitmapMain = mirrorImg; 
            //load mirror image in picture box
            ptbDisplay.Image = bitmapMain;
        }

        private void btnMirrorRight_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            save();
            int width = bitmapMain.Width;
            int height = bitmapMain.Height;
           
            //mirror image
            Bitmap mirrorImg = new Bitmap(width, height);

            for (int y = 0; y < height-1 ; y++)
            {
                for (int leftX = 0, rightX = width-1; leftX < width; leftX++, rightX--)
                {
                    //get source pixel value
                    Color p = bitmapMain.GetPixel(rightX, y);

                    //set mirror pixel value
                    mirrorImg.SetPixel(rightX, y, p);
                    mirrorImg.SetPixel(leftX, y, p);
                }
            }

            bitmapMain = mirrorImg; 
            //load mirror image in picture box
            ptbDisplay.Image = bitmapMain;
        }
        #endregion
        #region scale
        private void btnScale_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            if (emptyTextBox() == true)
            {
                return;
            }
            save();
            resizeImage(Convert.ToInt32(textX.Text), Convert.ToInt32(textY.Text));
            ptbDisplay.Image = bitmapMain;
        }

        public void resizeImage(int newWidth, int newHeight)
        {
            Image imgPhoto = bitmapMain;

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            Bitmap bmPhoto = new Bitmap(newWidth, newHeight,
                          PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            imgPhoto.Dispose();
            bitmapMain = bmPhoto;
        }
        #endregion
    }
}
