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
	public class RetirerBilletInventaire : ReservationFixtureBase
	{


		public RetirerBilletInventaire ():base()
		{
		}

		public void GenererInventaire(string siege)
		{
			inventory.Add (new SeatInventoryItem (new Billetterie.Model.Common.Seat (siege), new Show ()));
		}

		public void confirmerbilletPourClient(string siege, string nomClient)
		{
			CreateNewOrAddToReservation (siege, nomClient, "Anyspectacle", "AnyNoReservation");

			/*var serviceDeReservation = new ReservationService (reservationRepository, inventoryservices, new SystemDateTimeService ());
			serviceDeReservation.ReserveSeatsForVenue (new Billetterie.Model.Common.Seat[] { new Billetterie.Model.Common.Seat (siege) }, 
			new Show (), new Customer (client));*/


		}

		public bool BilletDansInventaire(string siege)
		{
			return true;
		}
	}
}

