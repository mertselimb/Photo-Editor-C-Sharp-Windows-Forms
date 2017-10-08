using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

        Bitmap bitmapMain;
        Bitmap reOpen;
        Bitmap back;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Wrap the creation of the OpenFileDialog instance in a using statement,
            // rather than manually calling the Dispose method to ensure proper disposal
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image files (*.bmp ; *.jpg)|*.bmp;*.jpg";

                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    ptbDisplay.Image = new Bitmap(dlg.FileName);
                    bitmapMain = new Bitmap(dlg.FileName);
                    reOpen = new Bitmap(dlg.FileName);
                }
            }
        }
        
        private void btnHistogram_Click(object sender, EventArgs e)
        {

        }

        private void btnReOpen_Click(object sender, EventArgs e)
        {
            ptbDisplay.Image = reOpen;
        }

        private void btnCloseReOpen_Click(object sender, EventArgs e)
        {
            ptbDisplay.Image = bitmapMain;
        }

        private void btnRotataMinus90_Click(object sender, EventArgs e)
        {
            save();
            RotateImage(bitmapMain, -90);
            ptbDisplay.Image = bitmapMain;
        }

        private void btnRotataPlus90_Click(object sender, EventArgs e)
        {
            save();
            RotateImage(bitmapMain, +90);
            ptbDisplay.Image = bitmapMain;
        }

        public  Bitmap transpozeImage(Bitmap image)
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

            for (int newX = 0 ; newX < image.Width; newX++)
            {
                for (int newY = 0 , maxY = image.Height - 1; newY < image.Height-1  ; newY++ , maxY--)
                {
                    if (maxY<0)
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
        
        public void colorMatrixTransform(Bitmap original , ColorMatrix colorMatrix)
        {
            //boş bitmap oluşturuyoruz aynı boyutta
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //graphice çeviriyoruz
            Graphics g = Graphics.FromImage(newBitmap);

            ImageAttributes attributes = new ImageAttributes();

            //matrisi ekliyoruz
            attributes.SetColorMatrix(colorMatrix);

            //yeni resme eskisini ekliyoruz
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            bitmapMain = newBitmap;
        }

        private void btnNegative_Click(object sender, EventArgs e)
        {
            save();
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
               {
                  new float[] {-1, 0, 0, 0, 0},
                  new float[] {0, -1, 0, 0, 0},
                  new float[] {0, 0, -1, 0, 0},
                  new float[] {0, 0, 0, 1, 0},
                  new float[] {1, 1, 1, 0, 1}
               });
            colorMatrixTransform(bitmapMain, colorMatrix);
            ptbDisplay.Image = bitmapMain;
        }

        private void btnGrayScale_Click(object sender, EventArgs e)
        {
            save();
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
               });
            colorMatrixTransform(bitmapMain, colorMatrix);
            ptbDisplay.Image = bitmapMain;
        }

        private void btnRedChannel_Click(object sender, EventArgs e)
        {
            save();
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                 new float[] {1, 0, 0, 0, 0},
                 new float[] {0, 0, 0, 0, 0},
                 new float[] {0, 0, 0, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
               });
            colorMatrixTransform(bitmapMain, colorMatrix);
            ptbDisplay.Image = bitmapMain;
        }

        private void btnBlueChannel_Click(object sender, EventArgs e)
        {
            save();
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                 new float[] {0, 0, 0, 0, 0},
                 new float[] {0, 0, 0, 0, 0},
                 new float[] {0, 0, 1, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
               });
            colorMatrixTransform(bitmapMain, colorMatrix);
            ptbDisplay.Image = bitmapMain;
        }

        private void btnGreenChannel_Click(object sender, EventArgs e)
        {
            save();
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                 new float[] {0, 0, 0, 0, 0},
                 new float[] {0, 1, 0, 0, 0},
                 new float[] {0, 0, 0, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
                 
               });
            colorMatrixTransform(bitmapMain, colorMatrix);
            ptbDisplay.Image = bitmapMain;
        }
        
        private void btnMirrorLeft_Click(object sender, EventArgs e)
        {
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

        private void btnGoStart_Click(object sender, EventArgs e)
        {
            bitmapMain = reOpen;
            ptbDisplay.Image = bitmapMain;
        }

        private void save()
        {
            back = bitmapMain;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            bitmapMain = back;
            ptbDisplay.Image = bitmapMain;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
    }
}
