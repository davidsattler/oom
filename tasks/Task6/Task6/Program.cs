﻿using System;
using System.Net;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;


namespace Task6
{
	public interface Daddy
	{
		void Updatetrack(decimal km, decimal zeit_in_minuten, decimal koerpergewicht_in_kg);
		/*void updatekm(decimal km);
		decimal berechne_kalorien(decimal km, decimal gewicht);*/ //kann ich nicht benützen, da private in den Klassen
		void Print_data();


	}

	class Radfahren : Daddy
	{
		public void Print_data()
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
			Updatetrack(km, zeit_in_minuten, koerpergewicht_in_kg);
		}

		public void Updatetrack(decimal km, decimal zeit_in_minuten, decimal koerpergewicht_in_kg)
		{
			if (km <= 0) throw new Exception("km-Zahl muss positiv sein");
			if (zeit_in_minuten <= 0) throw new Exception("Zeit muss positiv sein");
			if (koerpergewicht_in_kg <= 0) throw new Exception("Gewicht muss positiv sein");

			kalorien_total += Berechne_kalorien(koerpergewicht_in_kg, zeit_in_minuten);
			km_total = km_total + km;
			time_total = time_total + zeit_in_minuten;
		}

		private void Updatekm(decimal km)
		{
			km_total = km_total + km;
		}

		private decimal Berechne_kalorien(decimal gewicht_in_kg, decimal zeit)
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
		public void Print_data()
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
		private decimal gewicht_total = 0; //total is just for the conformity
		public decimal Gewicht_gesamt
		{
			get { return gewicht_total; }
		}

		//constructor kann nur bei der Initialisierung (new) benutzt werden
		public Laufen(decimal km_gesamt, decimal zeit_gesamt, decimal gewicht_gesamt)
		{
			Updatetrack(km_gesamt, zeit_gesamt, gewicht_gesamt);
		}

		public void Updatetrack(decimal km, decimal zeit_in_minuten, decimal koerpergewicht_in_kg)
		{
			if (km <= 0) throw new Exception("km-Zahl muss positiv sein");
			if (zeit_in_minuten <= 0) throw new Exception("Zeit muss positiv sein");
			if (koerpergewicht_in_kg <= 0) throw new Exception("Gewicht muss positiv sein");
			kalorien_total += berechne_kalorien(km, koerpergewicht_in_kg);
			km_total = km_total + km;
			time_total = time_total + zeit_in_minuten;
			gewicht_total = koerpergewicht_in_kg;
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
		public static double rechnung() { return 1 + 1; }

		public static void Main(string[] args)
		{
			/*var data = new Daddy[] { new Radfahren(1, 2, 3), new Laufen(3, 2, 1) };
			int i = 0;
			int a = 1;
			int b = 2;
			int c = 3;


			for (i = 0; i < data.Length; i++)
			{
				data[0].Updatetrack(a, b, c);
				data[1].Updatetrack(a, b, c);

				a++;
				b++;
				c++;
			}
			data[0].Print_data();
			data[1].Print_data();

			//Task4

			var laufen = new Laufen(12, 60, 90);

			string s = JsonConvert.SerializeObject(laufen,Formatting.Indented);
			Console.WriteLine(s);


			//Problem beim Serialisieren, da Gewicht nicht übergeben da es im Grunde weggeworfen und nicht gespeichert wird
			Laufen y = JsonConvert.DeserializeObject<Laufen>(s);
			//y testen
			y.Print_data();
			y.Updatetrack(1, 1, 80);
			y.Print_data();

			//neuer Test mit Array

			var json = new string[5];
			var arr = new Laufen[5];
			var example = new Laufen[5];
			int i;

			for (i = 0; i < 5; i++)
			{
				arr[i] = new Laufen(12 + i, 60 + i * 10, 95 - i);
			}
			for (i = 0; i < 5; i++)
			{
				json[i] = JsonConvert.SerializeObject(arr[i], Formatting.Indented);
				Console.WriteLine(json[i]);
			}
			Console.WriteLine("\n--------\n");


			for (i = 0; i < 5; i++)
			{
				example[i] = JsonConvert.DeserializeObject<Laufen>(json[i]);
				Console.WriteLine(json[i]);

			}*/



			//var producer = new Subject<Laufen>();
			////producer.Subscribe(x => x.Print_data());

			//var throttle = producer.Throttle(TimeSpan.FromMilliseconds(750));
			//throttle.Subscribe(x => x.Print_data());

			//      for (var i = 0; i < 100; i++)
			//{
			//	if (i % 10 > 4) System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(500));
			//	else System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(1000));
			//	var help = new Laufen(1 + i, 2 + i, 3 + i);
			//	producer.OnNext(help);
			//}

			Task<int> erg = computation();
			erg.ContinueWith(t => Console.WriteLine(t.Result));



			//var x = 2;
			//var random = new Random();

			////create working thread
			//var task = Task.Run(() =>
			//	{
			//		WriteLine($"computing result for {x}");
			//		Task.Delay(TimeSpan.FromSeconds(5.0 + random.Next(10))).Wait();
			//		WriteLine($"done computing result for {x}");
			//		return x * x;
			//	});
			//task.ContinueWith(t => Console.WriteLine("Job Done! Ergebnis: {0}\n", t.Result));


			//Console.WriteLine("in the mean time this thread is working on other important stuff\n");

			//string data = await new WebClient().DownloadStringAsync(@"api.openweathermap.org/data/2.5/forecast?id=4228440&APPID=5a25822b84dd4a99085d04091d4e847b");
			//Console.WriteLine(data);

			//Task<string> datax = new WebClient().DownloadStringAsync("api.openweathermap.org/data/2.5/forecast?id=4228440&APPID=5a25822b84dd4a99085d04091d4e847b");
			//Console.WriteLine(data);

			//give every process the time to finish
			for (var y = 1; y < int.MaxValue; y++)
			{
				System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
				if (y % 5 == 0) Console.WriteLine("{0} seconds past\n", y);
			}
			return;

		}


		

	public static Task<int> computation()
	{
			return Task.Run(() =>
			{
				System.Threading.Thread.Sleep(TimeSpan.FromSeconds(11));
				return 1 + 1; });
	}

		//public static Task<bool> IsPrime(int x, CancellationToken ct)
		//{
		//	return Task.Run(() =>
		//	{
		//		for (var i = 2; i < x - 1; i++)
		//		{
		//			ct.ThrowIfCancellationRequested();
		//			if (x % i == 0) return false;
		//		}
		//		return true;
		//	}, ct);
		//}

		//public static async Task ComputePrimes(CancellationToken ct)
		//{
		//	for (var i = 100000000; i < 100000500; i++)
		//	{
		//		ct.ThrowIfCancellationRequested();
		//		if (await IsPrime(i, ct)) WriteLine($"prime number: {i}");
		//	}
		//}

	}
}
