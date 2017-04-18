using System;
using System.Windows.Forms;
using static System.Console;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reactive.Subjects;


namespace Task5
{
	

	class MainClass
	{
		//public event MouseEventHandler MouseMove;

		public static void Main(string[] args)
		{
			var producer = new Subject<int>();

			producer.Subscribe(x => Console.WriteLine($"received value {x}"));

			for (var i = 0; i < 100; i++)
			{
				System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(500));
				producer.OnNext(i);
			}







			/*var w = new Form() { Text = "Lesson 6", Width = 800, Height = 600};
			//w.MouseMove += (sender, eventArgs) => WriteLine($"[MouseMove event] ({eventArgs.X}, {eventArgs.Y})");

			IObservable<Point> moves = Observable.FromEventPattern<MouseEventArgs>(w, "MouseMove")
												 .Select(x => x.EventArgs.Location);
			

			var subscription = moves
				.Where(e => e.X > 50)
				.Subscribe(e => WriteLine($"[MouseMove] ({e.X}, {e.Y})"))
				;
			// unsubscribe if a key is pressed
			Observable.FromEventPattern<KeyEventArgs>(w, "KeyDown")
				.Take(1) // create new sequence containing only the first value
				.Subscribe(k => { subscription.Dispose(); WriteLine("unsubscribed"); })
				;

			Application.Run(w);*/
		}
	}
}
