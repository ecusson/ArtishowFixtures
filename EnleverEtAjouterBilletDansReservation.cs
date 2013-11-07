using System;
using Billetterie.Model.Common;
using Billetterie.Model.Common.Services;
using Billetterie.Model.Inventory;
using SharpRepository.Repository;
using Billetterie.Model.Reservations.Services;
using Billetterie.Model.Reservations;

namespace artishowFixture
{
	public class EnleverEtAjouterBilletDansReservation : ReservationFixtureBase
	{
		public EnleverEtAjouterBilletDansReservation ():base()
		{

		}

		public void GenererInventaire(string siege)
		{

		}

		public void SelectionnerBillet(string siege)
		{

		}

		public void ReserverBilletsSelectionnesPourClientDansReservation(string nomClient, string noReservation) 
		{

		}

		public bool EnleverLeBilletDansReservation(string siege, string noReservation)
		{
			return true;
		}

		public bool AjouterBilletSelectionneDansReservation(string noReservation)
		{
			return true;
		}

	}

}




