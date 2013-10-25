using System;

namespace artishowFixture
{
	public class PayerPlusieursReservations
	{
		public PayerPlusieursReservations ()
		{
		}

		public void CreerReservationAuNomDeAvecTotalDe(string noReservation, string nomClient, decimal total)
		{

		} 
		public void CreerCompteDeAvecSoldeDe(string nomClient, decimal solde)
		{

		}
		public void SoustrairePaiementDeDuCompteClientDe(decimal montantPaiement, string nomClient)
		{

		}

		public void AjouterPaiementDeDansReservation(decimal montantPaiement, string noReservation)
		{

		}

		public string ReservationSolde(string noReservation)
		{
			return "75";
		}

		public string CompteClientDeSolde(string nomClient)
		{
			return string.Empty;
		}



	}
}

