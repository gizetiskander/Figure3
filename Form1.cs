using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Figure3
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(700, 900);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var graphics = pictureBox1.CreateGraphics();
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = pictureBox1.ForeColor;
            Pen pn = new Pen(MyDialog.Color);
            pn.Width = 5.0F;
            string figure = comboBox1.Text;
            if (figure == "Отрезок")
            {
                graphics.DrawLine(pn, 10, 10, 100, 50);
            }

            if (figure == "Круг")
            {
                graphics.DrawEllipse(pn, 50, 50, 50, 50);
            }

            if (figure == "Прямоугольник")
            {
                graphics.DrawRectangle(pn, 50, 50, 50, 50);
            }

            if (figure == "Треугольник")
            {
                Point point1 = new Point(20, 20);
                Point point2 = new Point(100, 150);
                Point point3 = new Point(20, 150);
                Point[] curvePoints =
             {
                 point1, point2, point3,
             };
                graphics.DrawPolygon(pn, curvePoints);

                graphics.Dispose();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var graphics = pictureBox1.CreateGraphics();
            graphics.Clear(Color.White);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = pictureBox1.ForeColor;

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ForeColor = MyDialog.Color;
                Pen pn = new Pen(MyDialog.Color, 5);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp";
            saveFileDialog1.Title = "Сохранение";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                FileStream fs = (FileStream)saveFileDialog1.OpenFile();

                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Jpeg);
                        break;

                    case 2:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Bmp);
                        break;
                }

                fs.Close();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Bitmap image; 

            OpenFileDialog opendialog1 = new OpenFileDialog(); 
            opendialog1.Filter = "Image Files(*.BMP;*.JPG)|*.BMP;*.JPG;|All files (*.*)|*.*"; 
            if (opendialog1.ShowDialog() == DialogResult.OK) 
            {
                try
                {
                    image = new Bitmap(opendialog1.FileName); 
                    this.pictureBox1.Size = image.Size;
                    pictureBox1.Image = image;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}