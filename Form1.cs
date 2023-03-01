using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
        /* Params */
        int MAX_ITER = 100;
        double WIDTH = 300;
        double HEIGHT = 300;

        double RE_START = -2;
        double RE_END = 2;
        double IM_START = -2;
        double IM_END = 2;


        // −0.8 + 0.156i - Dragon
        // 0.285 + 0.01i - Orchidea
        // −0.4 + 0.6i - Cauliflower
        // 0.7885 * e^{ia} - BEST THING!! (a is in range 0..2pi)
        // 0.7785 * e^{ia} - pi is at twin mandelbrot (a is in range 0..2pi)

        double[] c = { 0.285, 0.01 };


		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
            using(new Frissítés(false))
            {
                // MandelbrotSet();
                JuliaSet(c);

            }
        }

        /* Functions */

        void JuliaSet/*MandelbrotSet*/(double[] cons)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    double[] z/*cons*/ = { 
                        RE_START + (x / WIDTH) * (RE_END - RE_START),
                        IM_START + (y / HEIGHT) * (IM_END - IM_START) 
                            };

                    int j = Julia/*Mandelbrot*/(z, cons);
                    int color = 255 - (j * 255 / MAX_ITER);
                    Tollszín(Color.FromArgb(255, color, color, color));

                    Teleport(x + 400, y + 100);
                    Előre(1);
                    Hátra(1);
                }
            }
        }



        int Julia/*Mandelbrot*/(double[] z, double[] cons)
        {
            int n = 0;
            // double[] z = { 0, 0 };
            while (Math.Abs(z[0]) <= 2 && Math.Abs(z[1]) <= 2 && n < MAX_ITER)
            {
                z = SquareComplex(z);
                z = AddComplex(z, cons);
                n++;

            }
            return n;

        }

        double[] SquareComplex(double[] z)
        {
            double[] a = { z[0] * z[0] - z[1] * z[1], 2 * z[0] * z[1] };
            return a;
        }

        double[] AddComplex(double[] z, double[] b)
        {
            double[] a = { z[0] + b[0], z[1] + b[1] };
            return a;
        }

    }
}
