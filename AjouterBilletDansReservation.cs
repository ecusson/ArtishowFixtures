using System;
using Billetterie.Model.Common;
using Billetterie.Model.Common.Services;
using Billetterie.Model.Inventory;
using SharpRepository.Repository;
using Billetterie.Model.Reservations.Services;
using Billetterie.Model.Reservations;

namespace artishowFixture
{
	public class AjouterBilletDansReservation : ReservationFixtureBase
	{
		public AjouterBilletDansReservation ():base()
		{

		}

		public void GenererInventaire(string siege)
		{

		}

		public void SelectionnerBillet(string siege)
		{

		}

		public void ReserverBilletsSelectionnesPourClientDansReservation(string nomClient, String noReservation) 
		{

		}

		public bool AjouterBilletSelectionneDansReservation(string noReservation)
		{
			return true;
		}
	}

}

