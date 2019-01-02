using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCMLIB;

namespace DicomParser
{
    public partial class frmImage : Form
    {
        short[] owpixels;    //OW像素缓冲区
        byte[] obpixels;    //OB像素缓冲区
        DCMDataSet items;
        public frmImage(DCMDataSet items)
        {
            InitializeComponent();
            this.items = items;
        }

        private void frmImage_Load(object sender, EventArgs e)
        {
            //限制窗体大小等于图像大小，方便paint事件绘制图片
            this.Width = items[DicomTags.Columns].ReadValue<ushort>()[0];    //列数
            this.Height = items[DicomTags.Rows].ReadValue<ushort>()[0];     //行数
            tsWindow.Text = items[DicomTags.WindowWidth].ReadValue<string>()[0];    //窗宽
            tsLevel.Text = items[DicomTags.WindowCenter].ReadValue<string>()[0];     //窗位

            ushort bs = items[DicomTags.BitsStored].ReadValue<ushort>()[0];    //实际存储位数
            ushort hb = items[DicomTags.HighBit].ReadValue<ushort>()[0];      //最高位
            if (items[DicomTags.BitsAllocated].ReadValue<ushort>()[0] == 16)  //OW  ?//分配储存位数
            {
                //直接将读取的Ushort类型转换成Short类型（即减一取反）
                //减一取反后再进行有效位数的转换，先左移，再除以2的倍数
                owpixels = items[DicomTags.PixelData].ReadValue<short>();   //灰度图像，像素采样数为1，因此，每像素字节数为2，直接用short读
                for (int i = 0; i < owpixels.Length; i++)
                {
                    owpixels[i] =(short)((owpixels[i] << (15-hb))/Math.Pow(2,hb+1-bs));
                }
            }
            else
            {
                obpixels = items[DicomTags.PixelData].ReadValue<byte>();
                //...
			}


        }

        private void tsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = tsList.SelectedItem.ToString();
            switch (key)
            {
                case "脑窗":
                    {
                        tsLevel.Text = "35";
                        tsWindow.Text = "60";
                        break;
                    }
                case "骨窗":
                    {
                        tsLevel.Text = "600";
                        tsWindow.Text = "1400";
                        break;
                    }
                case "纵隔窗":
                    {
                        tsLevel.Text = "0";
                        tsWindow.Text = "350";
                        break;
                    }
                case "肺窗":
                    {
                        tsLevel.Text = "-600";
                        tsWindow.Text = "700";
                        break;
                    }
                case "肝窗":
                    {
                        tsLevel.Text = "30";
                        tsWindow.Text = "150";
                        break;
                    }
                case "腹窗":
                    {
                        tsLevel.Text = "40";
                        tsWindow.Text = "250";
                        break;
                    }
                case "脊柱窗":
                    {
                        tsLevel.Text = "60";
                        tsWindow.Text = "300";
                        break;
                    }
            }
            //Rectangle Rec
            this.Invalidate(); 
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            double c = double.Parse(tsLevel.Text);    //窗位
            double w = double.Parse(tsWindow.Text);   //窗宽
            //double c = -600;    //窗位
            //double w = 700;   //窗宽

            Bitmap bmp = new Bitmap(this.Width, this.Height, e.Graphics);

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int idx = i * Width + j;  //跳行
                    int pixel;
                    if (owpixels != null) //ow
                        pixel = owpixels[idx];
                    else  //ob
                        pixel = obpixels[idx];
                    //窗宽窗位变换
                    if (pixel <= c - w / 2)
                        pixel = 0;
                    else if (pixel > c + w / 2)
                        pixel = 255;
                    else
                        pixel = (int)(((pixel - c) / w + 0.5) * 255);  //8位显示器
                    //显示为灰度值,
                    Color p = Color.FromArgb(pixel, pixel, pixel);
                    bmp.SetPixel(j, i, p);
                }
            }
            e.Graphics.DrawImage(bmp, 0, 0);
            //MessageBox.Show("侧室");
        }
    }
}
