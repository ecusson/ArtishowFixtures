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
	public class AjouterPlusieursSiegesDansReservation
	{

		SharpRepository.InMemoryRepository.InMemoryRepository<SeatInventoryItem,String> inventory = new SharpRepository.InMemoryRepository.InMemoryRepository<SeatInventoryItem,string>();
		SharpRepository.InMemoryRepository.InMemoryRepository<Reservation,string> reservationRepository = new SharpRepository.InMemoryRepository.InMemoryRepository<Reservation,string>();
		SharpRepository.InMemoryRepository.InMemoryRepository<InventorySeatLock,string> lockinventory = new SharpRepository.InMemoryRepository.InMemoryRepository<InventorySeatLock,string>();
		IInventoryControlService inventoryservices;
		ReservationId currentReservation = null;

		public AjouterPlusieursSiegesDansReservation ()
		{
			inventoryservices = new InventoryService(lockinventory,inventory, new SystemDateTimeService (),10000);
		}

		public void GenererInventaire(string siege)
		{
			inventory.Add (new SeatInventoryItem (new Billetterie.Model.Common.Seat (siege), new Show ()));
		}

		public void ReserverBilletPourClient(string siege, string nomClient)
		{

			var serviceDeReservation = new ReservationService (reservationRepository, inventoryservices, new SystemDateTimeService ());
			if (currentReservation == null) {
			
				currentReservation = serviceDeReservation.ReserveSeatsForVenue (new Billetterie.Model.Common.Seat[] { new Billetterie.Model.Common.Seat (siege) }, 
				                                                                new Show (), new Customer (nomClient));
			} else {

				serviceDeReservation.AddSeatsToReservation (currentReservation, new Billetterie.Model.Common.Seat[] { new Billetterie.Model.Common.Seat (siege) });
			}

		}


		public bool ReservationPourContientBillet(string nomClient, string siege)
		{
			var reservation= reservationRepository.Get (currentReservation.Id);

			if (reservation.Customer.Id != nomClient) {
				return false;
			}
			if (reservation.Seats.Contains(new Billetterie.Model.Reservations.Seat(siege)))
			    {
				return true;
			}

			return false;
		}

		public long InventaireCount()
		{
			return inventory.LongCount ();
		}

		public bool inventaireContientPas(string siege)
		{
			if (inventory.Find (s => s.Seat.Number == siege) != null) {
					return false;
			} else {
				return true;}

		}

	}
}

