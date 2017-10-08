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

        private void btnHistogram_Click(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, bitmapMain.Width, bitmapMain.Height);
            System.Drawing.Imaging.BitmapData bmpData =
              bitmapMain.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bitmapMain.PixelFormat);

            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * bitmapMain.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // do something with the array
            
            ptbDisplay.Image = getHistogramWithSetSize(1920, 1080, convert(rgbValues));

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            bitmapMain.UnlockBits(bmpData);
        }
        public int[] convert(byte[] buf)
        {
            int bufLength = buf.Length / 4;
            int[] intArr = new int[bufLength];
            int offset = 0;
            for (int i = 0; i < intArr.Length; i++)
            {
                intArr[i] = (buf[3 + offset] & 0xFF) | ((buf[2 + offset] & 0xFF) << 8) |
                            ((buf[1 + offset] & 0xFF) << 16) | ((buf[0 + offset] & 0xFF) << 24);
                offset += 4;
            }
            return intArr;
        }
        public static System.Drawing.Image getHistogramWithSetSize(int width, int height, int[] pixelFreqs)
        {
            // Builds you a histogram of canvas size width*height. Takes ~2ms on a 300*300, 15ms on a 2000*1000
            // Bigger ones look cleaner, because the UI does a nice job of scaling them down, and it means that
            // the graphics libraries have a nicer time finding a path through the points.

            // We want to be able to fit at least one 256 (w) by 100 (h) histogram into the space.
            // If the user gave us bad parameters, we won't complain to them, we will just make it
            // bigger than they want it. If their UI is set up to do so, it will scale it down for them.
            if (width < 280) { width = 280; }
            if (height < 120) { height = 130; }
            int widthPerFrequency = width / 256;
            int histWidth = widthPerFrequency * 256; //Width of actual hist we will center horizontally.
            int spaceLeft = width - histWidth;
            int startX = spaceLeft / 2;
            // Define the brushes/pens we will use:
            var axisPen = new System.Drawing.Pen(System.Drawing.Brushes.DarkGray, 2);
            var gridPen = new System.Drawing.Pen(System.Drawing.Brushes.DarkGray, 0.5f);
            var linGrBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                new Point(startX, height - 10),
                new Point(startX + histWidth, height - 10),
                System.Drawing.Color.FromArgb(0, 0, 0),
                System.Drawing.Color.FromArgb(255, 255, 255)
                );
            var bluePen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(51, 153, 255), 2);
            var redPen = new System.Drawing.Pen(System.Drawing.Color.OrangeRed, 2);
            var polyBrush = new SolidBrush(System.Drawing.Color.FromArgb(120, 51, 153, 255));
            // Make canvas and get bitmap gfx handler g
            Bitmap hist = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(hist);
            // Paint the canvas white, add gradient bar
            g.FillRectangle(System.Drawing.Brushes.White, new Rectangle(0, 0, width, height));
            g.FillRectangle(linGrBrush, startX, height - 20, histWidth, 10);
            // Draw the axis
            g.DrawLine(axisPen, startX, 10, startX, height - 30); //y
            g.DrawLine(axisPen, startX, height - 30, startX + histWidth, height - 30); //x
            // Draw meaningless grid marks just beacause it looks nice
            // Draw them every 10th of an x length
            int seperatingPixel = histWidth / 10;
            for (int x = startX; x < startX + histWidth; x += seperatingPixel)
            {
                g.DrawLine(gridPen, x, 10, x, height - 30);
            }
            for (int y = height - 30; y > 10; y -= seperatingPixel)
            {
                g.DrawLine(gridPen, startX, y, startX + histWidth, y);
            }
            int biggestValue = pixelFreqs.Max();
            Point[] polygon = new Point[258];
            // Add a point for each and every pixel frequency
            for (int i = 0; i < 256; i++)
            {
                float percent = (float)pixelFreqs[i] / (float)biggestValue;
                percent = percent * (height - 40);
                int percInt = (int)percent;
                Point addedPoint = new Point((startX + widthPerFrequency * i), (height - 30 - percInt));
                polygon[i] = addedPoint;
            }
            polygon[256] = new Point(widthPerFrequency * 256, height - 30); //Add a line taking us back to the axis
            polygon[257] = new Point(startX, height - 30); //and back to the origin
            g.DrawLines(bluePen, polygon);
            g.FillPolygon(polyBrush, polygon);
            // Draw a line between the min and max values we are showing - insert your resampled values here if you have them
            g.DrawLine(redPen, startX + pixelFreqs.Min() * widthPerFrequency, height - 30, startX + pixelFreqs.Max() * widthPerFrequency, 10);
            return hist;
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
            bitmapMain = RotateImage(bitmapMain, -90);
            ptbDisplay.Image = bitmapMain;
        }

        private void btnRotataPlus90_Click(object sender, EventArgs e)
        {
            save();
            bitmapMain = RotateImage(bitmapMain, +90);
            ptbDisplay.Image = bitmapMain;
        }

        public static Bitmap RotateImage(Image image, float angle)
        {
            const double pi2 = Math.PI / 2.0;
            double oldWidth;
            oldWidth = (double)image.Width;
            double oldHeight;
            oldHeight = (double)image.Height;

            double newAngle = (double)angle;

            // Dereceleri radyan yapalım
            double theta = newAngle * Math.PI / 180.0;
            double locked_theta = theta;

            // Ensure theta is now [0, 2pi)
            while (locked_theta < 0.0)
                locked_theta += 2 * Math.PI;

            double newWidth, newHeight;
            int nWidth, nHeight; // The newWidth/newHeight expressed as ints

            #region Explaination of the calculations
            /*
			 * The trig involved in calculating the new width and height
			 * is fairly simple; the hard part was remembering that when 
			 * PI/2 <= theta <= PI and 3PI/2 <= theta < 2PI the width and 
			 * height are switched.
			 * 
			 * When you rotate a rectangle, r, the bounding box surrounding r
			 * contains for right-triangles of empty space.  Each of the 
			 * triangles hypotenuse's are a known length, either the width or
			 * the height of r.  Because we know the length of the hypotenuse
			 * and we have a known angle of rotation, we can use the trig
			 * function identities to find the length of the other two sides.
			 * 
			 * sine = opposite/hypotenuse
			 * cosine = adjacent/hypotenuse
			 * 
			 * solving for the unknown we get
			 * 
			 * opposite = sine * hypotenuse
			 * adjacent = cosine * hypotenuse
			 * 
			 * Another interesting point about these triangles is that there
			 * are only two different triangles. The proof for which is easy
			 * to see, but its been too long since I've written a proof that
			 * I can't explain it well enough to want to publish it.  
			 * 
			 * Just trust me when I say the triangles formed by the lengths 
			 * width are always the same (for a given theta) and the same 
			 * goes for the height of r.
			 * 
			 * Rather than associate the opposite/adjacent sides with the
			 * width and height of the original bitmap, I'll associate them
			 * based on their position.
			 * 
			 * adjacent/oppositeTop will refer to the triangles making up the 
			 * upper right and lower left corners
			 * 
			 * adjacent/oppositeBottom will refer to the triangles making up 
			 * the upper left and lower right corners
			 * 
			 * The names are based on the right side corners, because thats 
			 * where I did my work on paper (the right side).
			 * 
			 * Now if you draw this out, you will see that the width of the 
			 * bounding box is calculated by adding together adjacentTop and 
			 * oppositeBottom while the height is calculate by adding 
			 * together adjacentBottom and oppositeTop.
			 */
            #endregion

            double adjacentTop, oppositeTop;
            double adjacentBottom, oppositeBottom;

            // We need to calculate the sides of the triangles based
            // on how much rotation is being done to the bitmap.
            //   Refer to the first paragraph in the explaination above for 
            //   reasons why.
            if ((locked_theta >= 0.0 && locked_theta < pi2) ||
                (locked_theta >= Math.PI && locked_theta < (Math.PI + pi2)))
            {
                adjacentTop = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
                oppositeTop = Math.Abs(Math.Sin(locked_theta)) * oldWidth;

                adjacentBottom = Math.Abs(Math.Cos(locked_theta)) * oldHeight;
                oppositeBottom = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
            }
            else
            {
                adjacentTop = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
                oppositeTop = Math.Abs(Math.Cos(locked_theta)) * oldHeight;

                adjacentBottom = Math.Abs(Math.Sin(locked_theta)) * oldWidth;
                oppositeBottom = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
            }

            newWidth = adjacentTop + oppositeBottom;
            newHeight = adjacentBottom + oppositeTop;

            nWidth = (int)Math.Ceiling(newWidth);
            nHeight = (int)Math.Ceiling(newHeight);

            Bitmap rotatedBmp = new Bitmap(nWidth, nHeight);

            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {
                // This array will be used to pass in the three points that 
                // make up the rotated image
                Point[] points;

                /*
				 * The values of opposite/adjacentTop/Bottom are referring to 
				 * fixed locations instead of in relation to the
				 * rotating image so I need to change which values are used
				 * based on the how much the image is rotating.
				 * 
				 * For each point, one of the coordinates will always be 0, 
				 * nWidth, or nHeight.  This because the Bitmap we are drawing on
				 * is the bounding box for the rotated bitmap.  If both of the 
				 * corrdinates for any of the given points wasn't in the set above
				 * then the bitmap we are drawing on WOULDN'T be the bounding box
				 * as required.
				 */
                if (locked_theta >= 0.0 && locked_theta < pi2)
                {
                    points = new Point[] {
                                         new Point( (int) oppositeBottom, 0 ),
                                         new Point( nWidth, (int) oppositeTop ),
                                         new Point( 0, (int) adjacentBottom )
                                         };

                }
                else if (locked_theta >= pi2 && locked_theta < Math.PI)
                {
                    points = new Point[] {new Point( nWidth, (int) oppositeTop ),
                                          new Point( (int) adjacentTop, nHeight ),
                                          new Point( (int) oppositeBottom, 0 )
                                         };
                }
                else if (locked_theta >= Math.PI && locked_theta < (Math.PI + pi2))
                {
                    points = new Point[] {
                                          new Point( (int) adjacentTop, nHeight ),
                                          new Point( 0, (int) adjacentBottom ),
                                          new Point( nWidth, (int) oppositeTop )
                                         };
                }
                else
                {
                    points = new Point[] {
                                          new Point( 0, (int) adjacentBottom ),
                                          new Point( (int) oppositeBottom, 0 ),
                                          new Point( (int) adjacentTop, nHeight )
                                         };
                }

                g.DrawImage(image, points);
            }

            return rotatedBmp;
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
    }
}
