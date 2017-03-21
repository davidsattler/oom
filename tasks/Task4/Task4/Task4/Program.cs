using System;
using System.Net;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Task4
{
	public interface Daddy
	{
		void updatetrack(decimal km, decimal zeit_in_minuten, decimal koerpergewicht_in_kg);
		/*void updatekm(decimal km);
		decimal berechne_kalorien(decimal km, decimal gewicht);*/ //kann ich nicht benützen, da private in den Klassen
		void print_data();


	}

	class Radfahren : Daddy
	{
		public void print_data()
		{
			Console.WriteLine("Kilometer Gesamt: {0}\nInvestierte Zeit Gesamt: {1}\nVerbrauchte Kalorien Gesamt {2}\n",
			Km_gesamt, time_total, kalorien_total);
		}
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
		public Radfahren(decimal km, decimal zeit_in_minuten, decimal koerpergewicht_in_kg)
		{
			updatetrack(km, zeit_in_minuten, koerpergewicht_in_kg);
		}

		public void updatetrack(decimal km, decimal zeit_in_minuten, decimal koerpergewicht_in_kg)
		{
			if (km <= 0) throw new Exception("km-Zahl muss positiv sein");
			if (zeit_in_minuten <= 0) throw new Exception("Zeit muss positiv sein");
			if (koerpergewicht_in_kg <= 0) throw new Exception("Gewicht muss positiv sein");

			kalorien_total += berechne_kalorien(koerpergewicht_in_kg, zeit_in_minuten);
			km_total = km_total + km;
			time_total = time_total + zeit_in_minuten;
		}

		private void updatekm(decimal km)
		{
			km_total = km_total + km;
		}

		private decimal berechne_kalorien(decimal gewicht_in_kg, decimal zeit)
		{
			//8 kcal pro kg pro Stunde
			if (zeit <= 0) throw new Exception("Zeit muss positiv sein");
			if (gewicht_in_kg <= 0) throw new Exception("Wegstrecke muss positiv sein");

			decimal help = 0;

			help = zeit / 60 * 8 * gewicht_in_kg;
			return help;

		}
	}
	class Laufen : Daddy
	{
		public void print_data()
		{
			Console.WriteLine("Kilometer Gesamt: {0}\nInvestierte Zeit Gesamt: {1}\nVerbrauchte Kalorien Gesamt {2}\n",
			Km_gesamt, time_total, kalorien_total);
		}
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
			updatetrack(km, zeit_in_minuten, koerpergewicht_in_kg);
		}

		public void updatetrack(decimal km, decimal zeit_in_minuten, decimal koerpergewicht_in_kg)
		{
			if (km <= 0) throw new Exception("km-Zahl muss positiv sein");
			if (zeit_in_minuten <= 0) throw new Exception("Zeit muss positiv sein");

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
			if (gewicht <= 0) throw new Exception("Gewicht muss positiv sein");
			if (km <= 0) throw new Exception("Wegstrecke muss positiv sein");

			decimal help = 0;

			help = gewicht * km;
			return help;

		}
	}


	class MainClass
	{

		public static void Main(string[] args)
		{

			var data = new Daddy[] { new Radfahren(1, 2, 3), new Laufen(3, 2, 1) };
			int i = 0;
			int a = 1;
			int b = 2;
			int c = 3;


			for (i = 0; i < data.Length; i++)
			{
				data[0].updatetrack(a, b, c);
				data[1].updatetrack(a, b, c);

				a++;
				b++;
				c++;
			}
			data[0].print_data();
			data[1].print_data();

			//Task4

			var laufen = new Laufen(12, 60, 90);

			string s = JsonConvert.SerializeObject(laufen);
			Console.WriteLine(s);
			//Laufen y = JsonConvert.DeserializeObject<Laufen>(s);

			var json = new string[5];
			var arr = new Laufen[5];
			var example = new Laufen[5];

			for (i = 0; i < 5; i++)
			{
				arr[i] = new Laufen(12 + i, 60 + i * 10, 95 - i);
			}
			for (i = 0; i < 5; i++)
			{
				json[i] = JsonConvert.SerializeObject(arr[i]);
				Console.WriteLine(json[i]);
			}
			Console.WriteLine("\n");
			/*for (i = 0; i < 5; i++)
			{
				example[i] = JsonConvert.DeserializeObject<Laufen>(json[i]);
				Console.WriteLine(json[i]);
			}*/









			return;




		}
	}
}
