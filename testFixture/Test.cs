using NUnit.Framework;
using System;
using artishowFixture;

namespace testFixture
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{

			var ajouterppp = new AjouterPlusieursSiegesDansReservation ();
			ajouterppp.GenererInventaire ("S1");
			ajouterppp.ReserverBilletPourClient ("S1", "C1");

		}
	}
}

