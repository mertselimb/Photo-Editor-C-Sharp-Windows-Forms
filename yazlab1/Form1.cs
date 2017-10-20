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
        //ana kayitlar
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
        }//bmp bos mu diye bakiyoruz
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
        }//text box bosmu diye bakiyoruz
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
        }//veri girisi icin
        #endregion 
        #region histogram
        
        //histogramlari tanimladik
        int[] redHistogram = new int[256];
        int[] greenHistogram = new int[256];
        int[] blueHistogram = new int[256];
        private void btnHistogram_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            //gorunur hale getiriyoruz
            red.Visible = true;
            green.Visible = true;
            blue.Visible = true;
            
            //yeniden tiklamaya karsi bosalttik
            redHistogram = new int[256];
            greenHistogram = new int[256];
            blueHistogram = new int[256];
            //histogrami arraya aldik
            processImageRed();
            processImageGreen();
            processImageBlue();
            //cizdirdik
            Draw();
        }

        private void processImageRed()
        {
            for (int i = 0; i < bitmapMain.Width; i++)
            {
                for (int j = 0; j < bitmapMain.Height; j++)
                {
                    Color pixel = bitmapMain.GetPixel(i, j);

                    redHistogram[pixel.R]++;
                }
            }
        }//pixelleri arraya attık

        private void processImageGreen()
        {
            for (int i = 0; i < bitmapMain.Width; i++)
            {
                for (int j = 0; j < bitmapMain.Height; j++)
                {
                    Color pixel = bitmapMain.GetPixel(i, j);

                    greenHistogram[pixel.G]++;
                }
            }
        }//pixelleri arraya attık

        private void processImageBlue()
        {
            for (int i = 0; i < bitmapMain.Width; i++)
            {
                for (int j = 0; j < bitmapMain.Height; j++)
                {
                    Color pixel = bitmapMain.GetPixel(i, j);

                    blueHistogram[pixel.B]++;
                }
            }
        }//pixelleri arraya attık

        private void Draw()
        {

            for (int i = 0; i < 256; i++)
            {
                red.Series["main"].Points.AddXY(i, redHistogram[i]);
                red.Series["main"].Points[i].AxisLabel = "" + i;
            }

            for (int i = 0; i < 256; i++)
            {
                green.Series["main"].Points.AddXY(i, greenHistogram[i]);
                green.Series["main"].Points[i].AxisLabel = "" + i;
            }

            for (int i = 0; i < 256; i++)
            {
                blue.Series["main"].Points.AddXY(i, blueHistogram[i]);
                blue.Series["main"].Points[i].AxisLabel = "" + i;
            }
        }//charta cizdirdik

        #endregion
        #region userHelpers
        private void btnReOpen_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            ptbDisplay.Image = reOpen;
        }//baslagictan farki gormek icin

        private void btnCloseReOpen_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            ptbDisplay.Image = bitmapMain;
        }//baslagictan farki gormek icin olan degisimi kapatiyoruz

        private void save()//kaynaga her fonksiyon oncesi verileri geri atıyoruz
        {
            if (emptyBMP() == true)
            {
                return;
            }
            //kaynaga her fonksiyon oncesi verileri geri atıyoruz
            back = bitmapMain;
        }

        private void btnGoStart_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            //eski veriyi ana kaynaga kayit ediyoruz
            bitmapMain = reOpen;
            //displaye yukluyoruz
            ptbDisplay.Image = bitmapMain;
        }//en basa verileri kaybederek geri donus

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            //eski veriyi ana kaynaga kayit ediyoruz
            bitmapMain = back;
            //displaye yukluyoruz
            ptbDisplay.Image = back;
        }//bir onceki adıma gecis icin

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (emptyBMP() == true)
            {
                return;
            }
            using (SaveFileDialog dlgSave = new SaveFileDialog())//save dialog acip *.bmp olarak kayit ediyoruz
            {
                dlgSave.Title = "Save Image";
                dlgSave.Filter = "Bitmap Images (*.bmp)|*.bmp|All Files (*.*)|*.*";
                if (dlgSave.ShowDialog(this) == DialogResult.OK)
                {
                    bitmapMain.Save(dlgSave.FileName);
                }
            }
        }//projeyi disa aktarma
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

        public Bitmap transpozeImage(Bitmap image)//matrisi halinde transpozunu alıyoruz
        {
            //matrisin transpozunu alıyoruz
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
        }//matris halinde sutunlarin yerini degistiriyoruz

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
        }//matris halinde satirlarin yerini degistiriyoruz

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
        }//gerekli siraya gore matris fonksiyonlarini cagiriyoruz

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
            int width = bitmapMain.Width;
            int height = bitmapMain.Height;
            //Hiz icin lockbits kullandik
            BitmapData mainData = bitmapMain.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            //byte[] array boyutunu hesapladık tum pikselleri bulmak icin yukseklik*genislik dedik
            int arrayLength = mainData.Stride * mainData.Height;
            byte[] result = new byte[arrayLength];
            byte[] buffer = new byte[arrayLength];
            //marshall kopyalaması kullandık 
            Marshal.Copy(mainData.Scan0, buffer, 0, arrayLength);
            //rami temizledik
            bitmapMain.UnlockBits(mainData);
            int current = 0;
            //rgba kanallari
            int rgba = 3;
            //tum piksellere bakan bir donguye girdik
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //array kullandigimiz icin konumu bunu kullanarak buluyoruz
                    current = y * mainData.Stride + x * 4;
                    for (int c = 0; c < rgba; c++)
                    {
                        //255den tum verileri cikartiyoruz
                        result[current + c] = (byte)(255 - buffer[current + c]);
                    }
                    //alpha verisi
                    result[current + 3] = 255;
                }
            }
            //son urun
            Bitmap outputImage = new Bitmap(width, height);
            //kopyalamadaki hiz icin lockbits kullanip marshall kopyalamasi yaptik
            BitmapData outputData = outputImage.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            //marshall kopyalaması kullandık 
            Marshal.Copy(result, 0, outputData.Scan0, arrayLength);
            //rami temizledik
            outputImage.UnlockBits(outputData);
            bitmapMain = outputImage;
        }//negativini almak icin fonksiyon
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
            Rectangle rect = new Rectangle(0, 0, bitmapMain.Width, bitmapMain.Height);
            //verileri aldik hizli olmasi icin lockbits kullandik
            BitmapData bmpData = bitmapMain.LockBits(rect, ImageLockMode.ReadWrite, bitmapMain.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            //matris boyutu icin yukseklik * genislik
            int bytes = Math.Abs(bmpData.Stride) * bitmapMain.Height;
            //rgbleri matrise atmak icin matris olusturuyoruz
            byte[] rgbValues = new byte[bytes];

            //kitli oldugu icin marshall kullandik
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            //matrisi iceliyoruz
            for (int i = 0; i < rgbValues.Length; i += 3)
            {
                //color matrisine gore pikseli yerlestirdik
                //color matrix setle yapilmisti bu fonksiyon orhan hoca onu yasakladigi icin bu formata gecildi
                byte gray = (byte)(rgbValues[i] * .21 + rgbValues[i + 1] * .71 + rgbValues[i + 2] * .071);
                rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = gray;
            }

            //yine hizli olsun diye marshall copy
            Marshal.Copy(rgbValues, 0, ptr, bytes);

            //Unlock the bits
            bitmapMain.UnlockBits(bmpData);
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

            Bitmap rbmp = new Bitmap(bitmapMain);
            Bitmap gbmp = new Bitmap(bitmapMain);
            Bitmap bbmp = new Bitmap(bitmapMain);
            
            for (int y = 0; y < bitmapMain.Height; y++)
            {
                for (int x = 0; x < bitmapMain.Width; x++)
                {
                    //veriyi aldık
                    Color p = bitmapMain.GetPixel(x, y);

                    //icinden rgba yi ayırdık
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    if (color == "red") {
                         //kırmiziysa ona gore yazdik
                         rbmp.SetPixel(x, y, Color.FromArgb(a, r, 0, 0));
                    } else if(color == "green") {
                        //yesilseyse ona gore yazdik
                        gbmp.SetPixel(x, y, Color.FromArgb(a, 0, g, 0));
                    }else if (color == "blue") {
                        //maviyse ona gore yazdik
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
            
        }//gerekli kanala gore gerekli islemleri yapiyoruz
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
           
            //resmin aynalanmis hali icin kayit
            Bitmap mirrored = new Bitmap(width, height);

            for (int y = 0; y < height-1 ; y++)
            {
                for (int leftX = 0, rightX = width-1; leftX < width; leftX++, rightX--)
                {
                    //veriyi aldik
                    Color p = bitmapMain.GetPixel(leftX, y);

                    //aynadaki yerine yazdik
                    mirrored.SetPixel(leftX, y, p);
                    mirrored.SetPixel(rightX, y, p);
                }
            }

            //veriyi ana kaynaga yazdik
            bitmapMain = mirrored; 
            //veriyi kullanıcıya sunduk
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
           
            //aynalanmis resim icin kayit
            Bitmap mirrored = new Bitmap(width, height);

            for (int y = 0; y < height-1 ; y++)
            {
                for (int leftX = 0, rightX = width-1; leftX < width; leftX++, rightX--)
                {
                    //veriyi aldik
                    Color p = bitmapMain.GetPixel(rightX, y);

                    //aynadaki yerine yazdik
                    mirrored.SetPixel(rightX, y, p);
                    mirrored.SetPixel(leftX, y, p);
                }
            }
            //veriyi ana kaynaga yazdik
            bitmapMain = mirrored;
            //veriyi kullanıcıya sunduk
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

            //yukseklik genislik incelendi
            int sourceWidth = bitmapMain.Width;
            int sourceHeight = bitmapMain.Height;

            //resimin dikey mi yatay mı olduğuna baktık
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;
                //ona gore duzneleme yaptik
                newWidth = newHeight;
                newHeight = buff;

            }

            //null sikinti olacagi icin 0 atadik
            int sourceX = 0, sourceY = 0, destinationX = 0, destinationY = 0;
            float percent = 0, newPercentWidth = 0, newPercentHeight = 0;
            //oranlari aldik
            newPercentWidth = ((float)newWidth / (float)sourceWidth);
            newPercentHeight = ((float)newHeight / (float)sourceHeight);
            //genislik oranı > yukseklik oranı ise
            if (newPercentHeight < newPercentWidth)
            {
                //ana oran buna gore ayarlanıyor
                percent = newPercentHeight;
                //orana gore hedef x belirleniyor
                destinationX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * percent)) / 2);
            }
            //degilse
            else
            {
                //ana oran buna gore ayarlanıyor
                percent = newPercentWidth;
                //orana gore hedef y belirleniyor
                destinationY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * percent)) / 2);
            }
            //buyuk resimde nereye yerlestirecegimize bakiyoruz yeni resmi
            int destinationWidth = (int)(sourceWidth * percent);
            int destinationHeight = (int)(sourceHeight * percent);

            //son urunu olsuturuyoruz
            Bitmap output = new Bitmap(newWidth, newHeight,
                          PixelFormat.Format24bppRgb);

            // kaca kaclık oldugunu ayarlıyoruz resmin bosluk kalmasin diye
            output.SetResolution(bitmapMain.HorizontalResolution,
                         bitmapMain.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(output);
            //arkaplanı siyahla doldurduk
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            //resmi ciziyoruz
            grPhoto.DrawImage(bitmapMain,
                new Rectangle(destinationX, destinationY, destinationWidth, destinationHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            //rami temizledik
            grPhoto.Dispose();
            bitmapMain.Dispose();
            bitmapMain = output;
        }//resmin boyutunu degistiriyoruz
        #endregion
    }
}
