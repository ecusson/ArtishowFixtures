using System;
using Billetterie.Model.Common;
using Billetterie.Model.Common.Services;
using Billetterie.Model.Inventory.Services;
using Billetterie.Model.Inventory;
using SharpRepository.Repository;
using Billetterie.Model.Reservations.Services;
using Billetterie.Model.Reservations;
using System.Collections.Generic;

namespace artishowFixture
{
	public class ReservationValide : ReservationFixtureBase
	{
	
		public ReservationValide () : base ()
		{

		}

		public void AjouterFraisAuMontantDeDansReservation(string nomFrais, decimal Prix, string noReservation)
		{
		
		}
		 
		public void ReserverMarchandisePourClientEtSpectacleEtNoReservationAuPrixDe(string nomClient, string spectacle,string noReservation, decimal prix)
		{

		}

		public void ReserverAvecFraisUniquementAuMontantDePourClientEtNoReservation(string nomFrais, decimal prix, string nomClient, string noReservation)
		{
		}

	}
}

