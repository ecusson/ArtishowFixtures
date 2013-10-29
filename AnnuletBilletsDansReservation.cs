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
	public class AnnuletBilletsDansReservation : ReservationFixtureBase
	{
		public AnnuletBilletsDansReservation ():base()
		{

		}

		public void GenererInventaire(string siege)
		{
			inventory.Add (new SeatInventoryItem (new Billetterie.Model.Common.Seat (siege), new Show ()));
		}

		public void SelectionnerBillet(string siege)
		{

		}

		public void ReserverBilletsSelectionnesPourClientDansReservation(string nomClient, String noReservation) 
		{

		}

		public bool AnnulerReservation(string noReservation)
		{
			return true;
		}

		public bool inventaireContient(string siege)
		{
			if (inventory.Find (s => s.Seat.Number == siege) == null) {
				return false;
			} else {
				return true;}

		}

	}

}




