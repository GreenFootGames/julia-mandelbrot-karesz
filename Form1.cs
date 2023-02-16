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
                Jobbra(90);
				Koch(120, 3);
            }
			
		}


		void Koch(double size, int year, int left = 1)
		{
			if (year == 1)
			{
				Előre(size);
			} else
			{
				double smallSize = size / 3;

                Koch(smallSize, year-1);
                Balra(90*left);

                Koch(smallSize, year - 1, -1);
                Jobbra(90*left);

                Koch(smallSize, year - 1);
                Jobbra(90 * left);

                Koch(smallSize, year - 1, -1);
                Balra(90 * left);

                Koch(smallSize, year - 1);

            }

        }

		void KochRect(double size, int year)
		{
            double angle = 360 / 8;
            for (int i = 0; i < 8; i++)
			{
				
				Koch(size, year);
				Jobbra(angle);
			}
		}
	}
}
