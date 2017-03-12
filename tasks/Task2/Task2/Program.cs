using System;
using System.Net;
using System.Collections.Generic;

namespace Task2
{
	
		class Laufen
		{
			private decimal km_total = 0;
			public decimal Km_gesamt
			{
				get { return km_total; }
			}

			private decimal kalorien_total = 0;
			public decimal Kalorien_gesamt
			{
				get { return kalorien_total; }
			}

			private decimal time_total = 0; //in Minuten
			public decimal Zeit_gesamt
			{
				get { return time_total; }
			}

		//constructor kann nur bei der Initialisierung (new) benutzt werden
			public Laufen(decimal km, decimal zeit_in_minuten, decimal koerpergewicht_in_kg)
			{
				if (km < 0) throw new Exception("km-Zahl muss positiv sein");
				if (zeit_in_minuten < 0) throw new Exception("Zeit muss positiv sein");

				kalorien_total += berechne_kalorien(km, koerpergewicht_in_kg);
				km_total = km_total + km;
				time_total = time_total + zeit_in_minuten;
			}
		public void updatetrack(decimal km, decimal zeit_in_minuten, decimal koerpergewicht_in_kg)
		{
			if (km < 0) throw new Exception("km-Zahl muss positiv sein");
			if (zeit_in_minuten < 0) throw new Exception("Zeit muss positiv sein");

			kalorien_total += berechne_kalorien(km, koerpergewicht_in_kg);
			km_total = km_total + km;
			time_total = time_total + zeit_in_minuten;
		}

			private void updatekm(decimal km)
			{
				km_total = km_total + km;
			}

			private decimal berechne_kalorien(decimal km, decimal gewicht)
			{
				//1 kcal pro kg pro km
				if (gewicht < 0) throw new Exception("Gewicht muss positiv sein");
				if (km < 0) throw new Exception("Wegstrecke muss positiv sein");

				decimal help = 0;

				help = gewicht * km;
				return help;

			}
		}


	class MainClass
	{
		
		public static void Main(string[] args)
		{

			Laufen year_2017 = new Laufen(10,60,90);

				Console.WriteLine("Gelaufene KM: {0}\nGelaufene Zeit: {1}\nVerbrannte kcal: {2}", year_2017.Km_gesamt, year_2017.Zeit_gesamt, year_2017.Kalorien_gesamt);

			year_2017.updatetrack(15, 90, 80);
		
			Console.WriteLine("Gelaufene KM: {0}\nGelaufene Zeit: {1}\nVerbrannte kcal: {2}\n", year_2017.Km_gesamt, year_2017.Zeit_gesamt, year_2017.Kalorien_gesamt);

		}
	}
}
