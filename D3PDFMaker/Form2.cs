using System;
using System.Drawing;
using System.Windows.Forms;

namespace D3PDFMaker
{
    public partial class Form2 : Form
    {
        form1 f1;
        private Image currentImage;
        Point MD = new Point();
        Point MU = new Point();
        Bitmap bmp;
        bool view = false;
        bool init = true;

        private System.Windows.Forms.Button OKButton;

        public Form2(form1 f)
        {
            f1 = f;
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        public Image CurrentImage
        {
            get { return currentImage; }
            set { currentImage = value; }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (currentImage != null)
            {
                //DrawImageメソッドで画像を座標(0, 0)の位置に表示する
                e.Graphics.DrawImage(currentImage, 0, 0, currentImage.Width, currentImage.Height);
                //pictureBox1.Image = currentImage;
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

                if (init)
                {
                    int maxH = Screen.PrimaryScreen.WorkingArea.Height;
                    int maxW = Screen.PrimaryScreen.WorkingArea.Width;
                    this.MaximumSize = new Size(maxW, maxH);

                    int adjustW = 0;
                    int adjustH = 0;
                    if (maxW < currentImage.Width) adjustH = new VScrollBar().Height;
                    if (maxH < currentImage.Height) adjustW = new VScrollBar().Width;
                    this.ClientSize = new Size(currentImage.Width + adjustW, currentImage.Height + adjustH);
                    panel1.Width = pictureBox1.Width = currentImage.Width;
                    panel1.Height = pictureBox1.Height = currentImage.Height;
                    int centerDesktop = (maxW - currentImage.Width) / 2;
                    this.SetDesktopLocation(centerDesktop, 0);
                    init = false;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            view = true;
            if (this.OKButton != null) {
                this.OKButton.Visible = false;
            }

            MD.X = e.X;
            MD.Y = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Point start = new Point();
            Point end = new Point();

            MU.X = e.X;
            MU.Y = e.Y;

            GetRegion(MD, MU, ref start, ref end);
            DrawRegion(start, end);
            pictureBox1.Image = bmp;

            if(!(end.X == start.X)) { 
                MakeButton(end.X, end.Y);
            }

            view = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = new Point();
            Point start = new Point();
            Point end = new Point();

            if (view == false) return;

            p.X = e.X;
            p.Y = e.Y;

            GetRegion(MD, p, ref start, ref end);
            DrawRegion(start, end);

            pictureBox1.Image = bmp;
        }

        private void MakeButton(int x, int y)
        {
            int box_Width = 130;
            int box_Height = 30;

            this.OKButton = new System.Windows.Forms.Button();
            this.OKButton.Name = "OKButton";
            this.OKButton.Text = "範囲を決定する";
            this.OKButton.FlatStyle = FlatStyle.Flat;
            this.OKButton.FlatAppearance.BorderSize = 2;

            this.OKButton.Location = new Point(x - box_Width, y + 5);
            this.OKButton.Size = new System.Drawing.Size(box_Width, box_Height);

            this.OKButton.Click += new EventHandler(button1_Click);

            this.Controls.Add(this.OKButton);
            this.OKButton.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point start = new Point();
            Point end = new Point();
            GetRegion(MD, MU, ref start, ref end);

            int x = start.X + 1;
            int y = end.Y - 1;
            int slctWidth = GetLength(start.X, end.X) - 1;
            int slctHeight = GetLength(start.Y, end.Y) - 1;

            ImgCoordToPDFCoord(ref y, currentImage.Width, currentImage.Height);

            f1.minX = PixelToPoint(x);
            f1.maxY = PixelToPoint(y);
            f1.slctWidth = PixelToPoint(GetLength(start.X, end.X));
            f1.slctHeight = PixelToPoint(GetLength(start.Y, end.Y));

            this.Close();
        }

        private void GetRegion(Point p1, Point p2, ref Point start, ref Point end)
        {
            start.X = Math.Min(p1.X, p2.X);
            start.Y = Math.Min(p1.Y, p2.Y);

            end.X = Math.Max(p1.X, p2.X);
            end.Y = Math.Max(p1.Y, p2.Y);
        }

        private int GetLength(int start, int end)
        {
            return Math.Abs(start - end);
        }

        private void DrawRegion(Point start, Point end)
        {
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Brush b = new SolidBrush(Color.FromArgb(128, Color.DodgerBlue));
            g.DrawRectangle(pen, start.X, start.Y, GetLength(start.X, end.X), GetLength(start.Y, end.Y));
            g.FillRectangle(b, start.X, start.Y, GetLength(start.X, end.X), GetLength(start.Y, end.Y));
            g.Dispose();
            bmp.MakeTransparent();
        }

        private float PixelToPoint(int pixel, int dpi = 96)
        {
            return pixel * 72 / (float)dpi;
        }

        private void ImgCoordToPDFCoord(ref int y, int imgWidth, int imgHeight)
        {
            y = imgHeight - y;
        }
    }
}
