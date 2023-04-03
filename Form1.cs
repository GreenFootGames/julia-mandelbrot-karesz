using System;
using System.Drawing;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
        /* Params */

        #region Area in pixels
        double WIDTH = 420;
        double HEIGHT = 420;
        #endregion

        #region Complex plane borders
        double RE_START = -2;   // X axis (real) start
        double RE_END = 2;      // X axis (real) end
        double IM_START = -2;   // Y axis (imaginary) start
        double IM_END = 2;      // Y axis (imaginary) end
        #endregion

        #region Julia-set cool coordinates
        // -0.8, 0.156 - Dragon (−0.8 + 0.156i)
        // 0.285, 0.01 - Orchidea (0.285 + 0.01i)
        // -0.4, 0.6 - Cauliflower (−0.4 + 0.6i)
        // -0.7785, 0.0001 - Twin Mandelbrot (-0.7785 + 0.0001i)
        // -0.2, 0.7 - Spirals (-0.2 + 0.7i)
        #endregion

        int MAX_ITER = 100; // Set precision
        double[] c = { -0.8, 0.156 }; // Constant for the Julia-set

        /* End Params */


        void FELADAT()
        {
            using (new Frissítés(false))
            {
                // MandelbrotSet();
                JuliaSet(c);
            }
        }


        /* Functions */

        #region Julia-set
        void JuliaSet(double[] cons)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    double[] z = {
                        RE_START + (x / WIDTH) * (RE_END - RE_START),
                        IM_START + (y / HEIGHT) * (IM_END - IM_START)
                            };

                    int j = Julia(z, cons);
                    int color = 255 - (j * 255 / MAX_ITER);
                    Tollszín(Color.FromArgb(255, color, color, color));

                    Teleport(x + 150, y + 2);
                    Előre(1);
                    Hátra(1);
                }
            }
        }


        int Julia(double[] z, double[] cons)
        {
            int n = 0;

            while (Math.Abs(z[0]) <= 2 && Math.Abs(z[1]) <= 2 && n < MAX_ITER)
            {
                z = SquareComplex(z);
                z = AddComplex(z, cons);
                n++;

            }
            return n;

        }
        #endregion

        #region Mandelbrot-set
        void MandelbrotSet()
        {
            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    double[] cons = {
                        RE_START + (x / WIDTH) * (RE_END - RE_START),
                        IM_START + (y / HEIGHT) * (IM_END - IM_START)
                            };

                    int j = Mandelbrot(cons);
                    int color = 255 - (j * 255 / MAX_ITER);
                    Tollszín(Color.FromArgb(255, color, color, color));

                    Teleport(x + 150, y + 2);
                    Előre(1);
                    Hátra(1);
                }
            }
        }

        int Mandelbrot(double[] cons)
        {
            int n = 0;
            double[] z = { 0, 0 };
            while (Math.Abs(z[0]) <= 2 && Math.Abs(z[1]) <= 2 && n < MAX_ITER)
            {
                z = SquareComplex(z);
                z = AddComplex(z, cons);
                n++;

            }
            return n;

        }
        #endregion

        #region Complex Arithmetic
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
        #endregion

        /* End Functions */
    }
}
