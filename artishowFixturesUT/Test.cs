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
	}
}

