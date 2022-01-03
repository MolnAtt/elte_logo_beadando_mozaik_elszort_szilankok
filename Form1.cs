using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{

		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			//Négyes(zöldháromszög, 50);
			//Négyes(zöldrombusz, 50);
			minta(3, 5, 20);
		}

		void Sor(int N, double méret, int b)
		{
			Ismétlés(N, delegate ()
			{
				if (b==1)
					Négyes(zöldrombusz, méret);
				else
					Négyes(zöldháromszög, méret);
				Lopva_oldalaz(3 * méret);
				b = 1-b;
			});
			Lopva_oldalaz(-N * 3 * méret);
		}
		void minta(int M , int N, double méret)
		{
			int melyik = 1;
			Ismétlés(M, delegate ()
			{
				Sor(N, méret, melyik);
				using (new Rajzol(false))
					Előre(3 * méret);
				melyik = 1 - melyik;
			});

			using (new Rajzol(false))
				Előre(-M *3* méret);
		}

		void Sor1(int N, double méret) => Sor(N, méret, 1);
		void Sor2(int N, double méret) => Sor(N, méret, 0);


		void Lopva_oldalaz(double méret)
		{
			using (new Rajzol(false))
			using (new Átmenetileg(Jobbra, 90))
				Előre(méret);
		}
		void Lopva_előre(double méret)
		{
			using (new Rajzol(false))
				Előre(méret);
		}


		void Négyes1(double méret)
		{
			Ismétlés(4, delegate ()
			{
				zöldháromszög(méret);
				using (new Rajzol(false))
				{
					EJ(méret / 2, 90);
					Előre(méret / 2);
				}
			});
		}
		void Négyes2(double méret)
		{
			Ismétlés(4, delegate ()
			{
				zöldrombusz(méret);
				using (new Rajzol(false))
				{
					EJ(méret / 2, 90);
					Előre(méret / 2);
				}
			});
		}

		void Négyes(Action<double> a, double méret)
		{
			Ismétlés(4, delegate ()
			{
				a(méret);
				using (new Rajzol(false))
				{
					EJ(méret / 2, 90);
					Előre(méret / 2);
				}
			});
		}

		void zöldháromszög(double méret)
		{
			Ismétlés(3, delegate () { EJ(méret, -120); });
			Odatölt(30, méret / 2, Color.Green);
		}
		void zöldrombusz(double méret)
		{
			zöldháromszög(méret);
			using (new Átmenetileg(Előre, méret))
			using (new Átmenetileg(Balra, 60))
				zöldháromszög(méret);
		}
		void Odatölt(double f, double d, Color sz)
		{
			using (new Rajzol(false))
			using (new Átmenetileg(Balra, f))
			using (new Átmenetileg(Előre, d))
				Tölt(sz);
		}
		void EJ(double d, double f) { Előre(d); Jobbra(f); }

	}
}
