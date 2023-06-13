using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProiectOOP.JocProiect;

namespace ProiectOOP
{
    public class JocProiect
    {
        int w, h;
        static float l = 134;
        Graphics g;
        Pen creion = new Pen(Color.Black, 1);
        Piesa piesaSelectata;
        public JocProiect(int w, int h, Graphics g)
        {
            this.w = w;
            this.h = h;
            this.g = g;
            piesaSelectata = null;
        }

        public void JocNou()
        {
            JocProiect jocProiect = new JocProiect(300, 300, g);
            g.Clear(Color.White);
            piesaSelectata = null;
            adauga_piesa();
            jocProiect.deseneaza(g, 0, 0);
            

        }
        void adauga_piesa()
        {
            Piesa pion = new Pion(100, 80, 80, 20);
            pion.X = 50;
            pion.Y = 50;
            pion.deseneaza(g);
        }


        public PointF[] deseneazaHexagon(float x0, float y0, int pasX=1,int pasY=1)
        {
            int radius = 30;

            PointF[] hexagon = new PointF[6];
            for (int i = 0; i < 6; i++)
            {
                double angle = 2 * Math.PI / 6 * i + 30 * Math.PI / 180.0; // Unghiul în radiani
                int x = (int)(x0 + l+52*pasX + radius * Math.Cos(angle));
                int y = (int)(y0 + l + radius * Math.Sin(angle));
                hexagon[i] = new PointF(x, y);
            }
            return hexagon;
        }
        public void deseneaza(Graphics g, float x0, float y0)
        {

            deseneazaTabla(g,0, 0);
            //pointFs = { hexagon; hexagon2; };
            //deseneazaTabla(g, 300, 300);

        }
        void deseneazaPiesa()
        {
            Piesa pion = new Pion(0, 0, 20, 20);
            pion.deseneaza(g);
        }
        void deseneazaTabla(Graphics g, float x0, float y0)
        {
            Brush br = new SolidBrush(Color.Black);
            g.Clear(Color.White);

            int radius = 30;

            //primul rand
            for (int i = 1; i < 6; i++)
            {
                g.FillPolygon(br, deseneazaHexagon(x0, y0, i));
            }

            //al doilea rand
            for (int i = 1; i < 7; i++)
            {
                g.FillPolygon(br, deseneazaHexagon(x0 - 26, y0 + 46, i));
            }
            //al 3 rand
            for (int i = 1; i < 8; i++)
            {
                g.FillPolygon(br, deseneazaHexagon(x0 - 26 * 2, y0 + 46 * 2, i));
            }
            //al 4 rand
            for (int i = 1; i < 9; i++)
            {
                g.FillPolygon(br, deseneazaHexagon(x0 - 26 * 3, y0 + 46 * 3, i));
            }
            //al 5 rand
            for (int i = 1; i < 10; i++)
            {
                g.FillPolygon(br, deseneazaHexagon(x0 - 26 * 4, y0 + 46 * 4, i));
            }
            for (int i = 1; i < 9; i++)
            {
                g.FillPolygon(br, deseneazaHexagon(x0 - 26 * 3, y0 + 46 * 5, i));
            }
            for (int i = 1; i < 8; i++)
            {
                g.FillPolygon(br, deseneazaHexagon(x0 - 26 * 2, y0 + 46 * 6, i));
            }
            for (int i = 1; i < 7; i++)
            {
                g.FillPolygon(br, deseneazaHexagon(x0 - 26 * 1, y0 + 46 * 7, i));
            }
            for (int i = 1; i < 6; i++)
            {
                g.FillPolygon(br, deseneazaHexagon(x0, y0 + 46 * 8, i));
            }
        }
        public double XcentrulHexagonului(int x, int y, double angle)
        {
            double center_x, center_y, radius = 0;
            radius = Math.Sqrt(x * x + y * 2);
            
            center_x=radius * Math.Cos(angle);
            return center_x;
        }
        public double YcentrulHexagonului(int x, int y, double angle)
        {
            double center_x, center_y, radius = 0;
            radius = Math.Sqrt(x * x + y * 2);

            center_y = radius * Math.Sin(angle);
            return center_y;
        }
        public abstract class Piesa
        {
            protected int x, y, w, h;
            public abstract void deseneaza(Graphics g);
            public abstract bool este_deasupra(int x, int y);
            public abstract bool valideaza_mutare(int lStart, int cStart, int lEnd, int cEnd);
            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public int Y
            {
                get { return y; }
                set { y = value; }
            }
        }
        public class Pion : Piesa
        {
            Image imgP;
            public Pion(int x, int y, int w, int h)
            {
                this.x = x;
                this.y = y;
                this.w = w;
                this.h = h;
                imgP = Properties.Resources.pion;
            }
            public override bool este_deasupra(int x, int y)
            {
                if (x < this.x) return false;
                if (y < this.y) return false;
                if (x > this.x + this.w) return false;
                if (y > this.y + this.h) return false;
                return true;
            }
            public override bool valideaza_mutare(int lStart, int cStart, int lEnd, int cEnd)
            {
                if (cStart != cEnd) return false;
                if (lStart == 2 && (lEnd < 3 || lEnd > 4)) return false;
                if (lStart > 2 && (lEnd <= lStart || lEnd > lStart + 1)) return false;
                return true;
            }
            public override void deseneaza(Graphics g)
            {
                g.DrawImage(imgP, x, y, w, h);
            }
        }
    }
}
