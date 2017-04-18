using System;
using NUnit.Framework;
using Task6;


namespace Tests
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void ParameterIsSame()
		{
			var x = new Laufen(12, 60, 90);
			Assert.IsTrue(x.Km_gesamt == 12);
			Assert.IsTrue(x.Zeit_gesamt == 60);

			var a = new Radfahren(12, 60, 90);
			Assert.IsTrue(a.Km_gesamt == 12);
			Assert.IsTrue(a.Zeit_gesamt == 60);
		}

		[Test]
		public void growthcount()
		{
			var x = new Laufen(12, 60, 90);
			x.Updatetrack(12, 60, 90);
			Assert.IsTrue(x.Km_gesamt == 24);
			Assert.IsTrue(x.Zeit_gesamt == 120);

			var a = new Radfahren(12, 60, 90);
			a.Updatetrack(12, 60, 90);
			Assert.IsTrue(a.Km_gesamt == 24);
			Assert.IsTrue(a.Zeit_gesamt == 120);
		}

		[Test]
		public void CannotcreateTrackwithoutKM()
		{
			Assert.Catch(() =>
			{
				var x = new Laufen(0, 60, 90);
			});
			Assert.Catch(() =>
			{
				var a = new Radfahren(0, 60, 90);
			});
		}

		[Test]
		public void CannotcreateTrackwithoutTIME()
		{
			Assert.Catch(() =>
			{
				var x = new Laufen(12, 0, 90);
			});
			Assert.Catch(() =>
			{
				var a = new Radfahren(12, 0, 90);
			});
		}

		[Test]
		public void CannotcreateTrackwithoutWeight()
		{
			Assert.Catch(() =>
			{
				var x = new Laufen(12, 60, 0);
			});
			Assert.Catch(() =>
			{
				var a = new Radfahren(12, 60, 0);
			});
		}

		[Test]
		public void CannotcreateTrackwithNEGKm()
		{
			Assert.Catch(() =>
			{
				var x = new Laufen(-12, 60, 90);
			});
			Assert.Catch(() =>
			{
				var a = new Radfahren(-12, 60, 90);
			});
		}

		[Test]
		public void CannotcreateTrackwithNEGTime()
		{
			Assert.Catch(() =>
			{
				var x = new Laufen(12, -60, 90);
			});
			Assert.Catch(() =>
			{
				var a = new Radfahren(12, -60, 90);
			});
		}

		[Test]
		public void CannotcreateTrackwithNEGWeight()
		{
			Assert.Catch(() =>
			{
				var x = new Laufen(12, 60, -90);
			});
			Assert.Catch(() =>
			{
				var a = new Radfahren(12, 60, -90);
			});
		}


	}
}
