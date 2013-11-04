using System;

namespace artishowFixture
{
	public class PaiementMultipleReservation :ReservationFixtureBase
	{
		public PaiementMultipleReservation ()  :base()
		{
		}

		public override decimal TotalReservation(string noReservation)
		{
			return 0.00m;
		}

		public void AjouterPaiementDeDansReservation(decimal montantPaiement, string noReservation)
		{

		}

		public decimal ReservationSolde(string noReservation)
		{
			return 0.00m;
		}


	

	}
}

