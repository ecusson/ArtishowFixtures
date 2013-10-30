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
			test.GenererInventaire ("A1");
			test.GenererInventaire ("A2");
			test.GenererInventaire ("A3");
			test.ReserverBilletPourClient ("A1", "CLIENT1");
			test.ReserverBilletPourClient ("A2", "CLIENT1");
			Assert.IsTrue(test.inventaireContientPas ("A1"));
			Assert.IsFalse(test.inventaireContientPas ("A3"));
			test.ReserverBilletPourClient ("A3", "CLIENT1");
			Assert.IsTrue(test.inventaireContientPas ("A3"));

		}
		[Test ()]
		public void TestCase2 ()
		{

			var test = new ReserverDifferentsBilletsDansRepresentation ();
			test.GenererInventairePourSpectacle("A1","SHOW1");
			test.GenererInventairePourSpectacle ("A2", "SHOW1");
			test.GenererInventairePourSpectacle ("A1", "SHOW2");
			test.ReserverBilletPourClientEtSpectacle ("A1", "CLIENT1", "SHOW1");
			test.ReserverBilletPourClientEtSpectacle ("A2", "CLIENT2", "SHOW1");
			Assert.AreEqual(0, test.InventaireCount ("SHOW1"));

		}
	}
}

