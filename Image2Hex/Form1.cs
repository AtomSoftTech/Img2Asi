using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Image2Hex
{
    public partial class Form1 : Form
    {

        Bitmap theImage;
        string theImageURL;
        string theName;


        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            switch (cmdFormat.Text)
            { 
                case "RGB565":
                    GenRGB565();
                    break;
            }


        }
        Bitmap targetBmp;
        private void GenRGB565()
        {
            int IMAGE_HEIGHT = theImage.Height;
            int IMAGE_WIDTH = theImage.Width;

            int x, y;

            byte redp,greenp,bluep;

            int ByteCount = (IMAGE_WIDTH * IMAGE_HEIGHT) * 2;

            byte[] imageBuffer = new byte[ByteCount];

            int bytePOS = 0;
            int byteINC = 2;

            

            Bitmap newBmp = new Bitmap(theImage);
            targetBmp = newBmp.Clone(new Rectangle(0, 0, newBmp.Width, newBmp.Height), PixelFormat.Format16bppRgb565);

            /*
            pictureBox1.Image = targetBmp;

            if (MessageBox.Show("Review Image... Continue?", "Image2Hex", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;
            */

            for (y = 0; y < IMAGE_HEIGHT; y++)
            {
                for (x = 0; x < IMAGE_WIDTH; x++)
                {
                    
                    redp = targetBmp.GetPixel(x, y).R;
                    greenp = targetBmp.GetPixel(x, y).G;
                    bluep = theImage.GetPixel(x, y).B;
                    /*
                    imageBuffer[bytePOS] = (byte)((redp << 3) | (greenp >> 5));
                    imageBuffer[bytePOS + 1] = (byte)((greenp << 5) | bluep);
                    */

                    UInt32 retPixel = (UInt32)(redp<<16)|(UInt32)(greenp<<8)|(UInt32)(bluep);
                    aPixel tempPixel = TF2ST(retPixel);

                    imageBuffer[bytePOS] = tempPixel.uPixel;
                    imageBuffer[bytePOS + 1] = tempPixel.lPixel;

                    bytePOS += byteINC;
                }
            }
            /*
            string userData = "";

            for (x = 0; x < ByteCount; x++)
            {
                userData += "0x" + imageBuffer[x].ToString("x") + ",";
                if (((x+1) % 40)==0)
                    userData += "\r\n    ";
            }

            userData = userData.Substring(0, userData.Length - 1);

            string userHeader = "";

            userHeader += "unsigned char "+ theName + "["+ByteCount+"] = {\r\n    "+userData+"};";
            txtUser.Text = userHeader;
            */
            string newASBMP = theImageURL.Substring(0,theImageURL.Length -4).ToLower() + ".asi";

            byte[] IMG_HEADER_HEIGHT = new byte[2];
            byte[] IMG_HEADER_WIDTH = new byte[2];
            
            FileStream fs = new FileStream(newASBMP, FileMode.Create);
            BinaryWriter w = new BinaryWriter(fs);

            IMG_HEADER_HEIGHT[1] = (byte)(IMAGE_HEIGHT >> 8);
            IMG_HEADER_HEIGHT[0] = (byte)(IMAGE_HEIGHT & 0xFF);

            IMG_HEADER_WIDTH[1] = (byte)(IMAGE_WIDTH >> 8);
            IMG_HEADER_WIDTH[0] = (byte)(IMAGE_WIDTH & 0xFF);

            w.Write("atomsoftech asi");
            w.Write(IMG_HEADER_HEIGHT);
            w.Write(IMG_HEADER_WIDTH);
            
            w.Write(imageBuffer);
        
            w.Close();
            fs.Close();

            MessageBox.Show("Created: " + newASBMP);


        }



        private void btnOpen_Click(object sender, EventArgs e)
        {
            dlgOpen.FileName = "";

            if (dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;

            theImageURL = dlgOpen.FileName;

            theImage = new Bitmap(theImageURL);

            bool isLarger = false;
            /*
            if (theImage.Width > 480) isLarger = true;
            if (theImage.Height > 272) isLarger = true;

            if (isLarger == true)
            {
                MessageBox.Show("Image is larger than display and will be canceled.\nSize: " + theImage.Width + "x" + theImage.Height, "AtomSoftTech");
                return;
            }
            */
            imgMain.Width = theImage.Width;
            imgMain.Height = theImage.Height;


            imgMain.Image = theImage;

            if(theImage.Width > 528)
                this.Width = theImage.Width + 38;

            if (theImage.Height > 365)
                this.Height = theImage.Height + 90;

            string[] tempArray = theImageURL.Split('\\');
            theName = tempArray[tempArray.Length-1];
            theName = theName.Replace(".", "_");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dlgOpen.Filter = "All Files|*.*";
            dlgOpen.Title = "Open Image";

            imgMain.SizeMode = PictureBoxSizeMode.Normal;
            
        }

        public class aPixel
        {
            // Field 
            public byte uPixel;
            public byte lPixel;

            // Constructor that takes no arguments. 
            public aPixel()
            {
                uPixel = 0;
                lPixel = 0;
            }

            // Constructor that takes one argument. 
            public aPixel(byte anuPixel, byte anlPixel)
            {
                uPixel = anuPixel;
                lPixel = anlPixel;
            }

            // Method 
            public void aPixelSet(byte anuPixel, byte anlPixel)
            {
                uPixel = anuPixel;
                lPixel = anlPixel;
            }
        }

        private aPixel TF2ST(UInt32 inPixel)
        {
            aPixel outPixel = new aPixel();
            byte upperP, lowerP;

            UInt16 RED   = (UInt16)((inPixel >> 16) & 0xF8);
            UInt16 GREEN = (UInt16)((inPixel >> 8) & 0xFC);
            UInt16 BLUE  = (UInt16)(inPixel & 0xF8);

            upperP = (byte)(RED | (GREEN >> 5));
            lowerP = (byte)((GREEN << 3) | (BLUE >> 3));

            outPixel.aPixelSet(upperP, lowerP);

            return outPixel;
        }

        private void imgMain_Click(object sender, EventArgs e)
        {

        }

        private void imgMain_MouseMove(object sender, MouseEventArgs e)
        {

            this.Text = "Location - X: " + e.X + " Y:" + e.Y;
        }

        private void imgMain_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void imgMain_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            
        }

    }
}
