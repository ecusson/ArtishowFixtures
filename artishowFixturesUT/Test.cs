using NUnit.Framework;
using System;
using artishowFixture;

namespace artishowFixturesUT
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{

			var test = new AjouterPlusieursSiegesDansReservation ();
			test.GenererInventairePourSpectacle ("A1","show");
			test.GenererInventairePourSpectacle ("A2","show");
			test.GenererInventairePourSpectacle ("A3","show");
			test.ReserverBilletPourClientEtSpectacleEtNoReservation ("A1", "CLIENT1", "SHOW1","any");
			test.ReserverBilletPourClientEtSpectacleEtNoReservation ("A2", "CLIENT1", "SHOW1","any");
			Assert.IsFalse(test.inventaireContientPas ("A3"));
			test.ReserverBilletPourClientEtSpectacleEtNoReservation ("A3", "CLIENT1", "SHOW1","any");
			Assert.IsTrue(test.inventaireContientPas ("A3"));

		}
		[Test ()]
		public void TestCase2 ()
		{

			var test = new ReserverDifferentsBilletsDansRepresentation ();
			test.GenererInventairePourSpectacle("A1","SHOW1");
			test.GenererInventairePourSpectacle ("A2", "SHOW1");
			test.GenererInventairePourSpectacle ("A1", "SHOW2");
			test.ReserverBilletPourClientEtSpectacleEtNoReservation ("A1", "CLIENT1", "SHOW1","any");
			test.ReserverBilletPourClientEtSpectacleEtNoReservation ("A2", "CLIENT2", "SHOW1","any");
			Assert.AreEqual(0, test.InventaireCount ("SHOW1"));

		}
	}
}

