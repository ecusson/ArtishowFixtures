using NUnit.Framework;
using System;
using artishowFixture;

namespace Test
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			var fixture = new ReserverDifferentsBilletsDansRepresentation ();
			fixture.GenererInventairePourSpectacle ("A1", "S1");
			fixture.GenererInventairePourSpectacle ("A2", "S1");
			fixture.CreerReservationPourClientEtSpectacle ("No1", "C1", "S1");
			fixture.AjouterBilletDansReservationAuPrixDe ("A1", "No1", 10);
			fixture.AjouterBilletDansReservationAuPrixDe ("A2", "No1", 10);




		}
	}
}

