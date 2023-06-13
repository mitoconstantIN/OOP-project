using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectOOP
{
    public partial class Form1 : Form
    {
        Image img;
        Graphics g;
        JocProiect joc;
        int x0, y0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
           g = Graphics.FromImage(img);
           joc = new JocProiect(img.Width, img.Height, g);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JocProiect jocProiect = new JocProiect(300, 300, g);
            panel3.Visible=false;
            panel2.Visible=true;
            g.Clear(Color.White);

            jocProiect.deseneaza(g, 1, 1);
            //joc.JocNou();
            //pictureBox1.Refresh();
        }



        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            JocProiect jocProiect = new JocProiect(500, 500, g);
            g.Clear(Color.White);
            
            jocProiect.deseneaza(g,100,20);
        }

        private void jocNouToolStrip3_Click(object sender, EventArgs e)
        {
            JocProiect jocProiect = new JocProiect(500, 500, g);
            panel3.Visible = false;
            panel2.Visible = true;

            jocProiect.JocNou();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = false;
            panel1.Visible = true;
        }

    }
}
