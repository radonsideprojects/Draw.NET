using System.Configuration;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initiate_paint();
        }
        public Pen p = new Pen(Color.Black);
        public Point starter;
        public Point current;
        public Point end;
        public Graphics g;
        public Bitmap bmp;
        public bool isMoving;
        public Point permaStarter;
        public Rectangle rect;
        public int x;
        public int y;
        public int oX;
        public int oY;
        public int mX;
        public int mY;
        Color bColor;
        private void initiate_paint()
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            bmp = new Bitmap(rect.Width, rect.Height);
            g = Graphics.FromImage(bmp);
            isMoving = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = bmp;
            g.Clear(Color.White);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            oX = e.X;
            oY = e.Y;
            starter = e.Location;
            isMoving = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                current = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
            Rectangle rectangle = new Rectangle();

            rectangle.X = oX < e.X ? oX :
                e.X;
            rectangle.Y = oY < e.Y ? oY :
                e.Y;

            rectangle.Width = Math.Abs(e.X - oX);
            rectangle.Height = Math.Abs(e.Y - oY);

            rectangle.Width = Math.Abs(e.X - oX);
            rectangle.Height = Math.Abs(e.Y - oY);

            if (radioButton2.Checked)
            {
                g.DrawRectangle(p, rectangle);
            }
            if (radioButton3.Checked)
            {
                g.DrawEllipse(p, rectangle);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (radioButton1.Checked)
            {
                g.DrawLine(p, starter, current);
                starter = current;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackColor = colorDialog1.Color;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            p.Color = colorDialog1.Color;
            p.Width = (float)trackBar1.Value;

            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
}
