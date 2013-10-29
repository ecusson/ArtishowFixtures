using System;
using Billetterie.Model.Common;
using Billetterie.Model.Common.Services;
using Billetterie.Model.Inventory.Services;
using Billetterie.Model.Inventory;
using SharpRepository.Repository;
using Billetterie.Model.Reservations.Services;
using Billetterie.Model.Reservations;

namespace artishowFixture
{
	public class EnleverBilletDansReservation : ReservationFixtureBase
	{
		public EnleverBilletDansReservation ():base()
		{

		}

		public void GenererInventaire(string siege)
		{
			inventory.Add (new SeatInventoryItem (new Billetterie.Model.Common.Seat (siege), new Show ()));
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

	}

}

