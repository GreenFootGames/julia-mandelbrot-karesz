using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */


		/* Függvények vége */
		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			using (new Frissítés(false))
			{
                DenseningFlower(300, 5, 9);
            }
			
		}

        void DenseningFlower(double size, int year, int startCount)
		{
            if(year > 0)
            {
                double count = 360 / startCount;
                for ( double i = 0; i < 360; i+=count)
                {
                    Bezier_3_pontos(
                        new Pont(size * 0.66, size),
                        new Pont(-size * 0.66, size),
                        new Pont(0, 0),
                        false,
                        false
                    );

                    Jobbra(count);
                }

                DenseningFlower(size / 2, year-1, startCount+1);

            }

        }
	}
}
