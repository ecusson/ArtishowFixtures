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
	public class RetirerBilletInventaire
	{
		SharpRepository.InMemoryRepository.InMemoryRepository<SeatInventoryItem,String> inventory = new SharpRepository.InMemoryRepository.InMemoryRepository<SeatInventoryItem,string>();
		SharpRepository.InMemoryRepository.InMemoryRepository<Reservation,string> reservationRepository = new SharpRepository.InMemoryRepository.InMemoryRepository<Reservation,string>();
		SharpRepository.InMemoryRepository.InMemoryRepository<InventorySeatLock,string> lockinventory = new SharpRepository.InMemoryRepository.InMemoryRepository<InventorySeatLock,string>();
		IInventoryControlService inventoryservices;


		public RetirerBilletInventaire ()
		{
			inventoryservices = new InventoryService(lockinventory,inventory, new SystemDateTimeService (),10000);

		}

		public void GenererInventaire(string siege)
		{
			inventory.Add (new SeatInventoryItem (new Billetterie.Model.Common.Seat (siege), new Show ()));
		}

		public void confirmerbilletPourClient(string siege, string client)
		{
			var serviceDeReservation = new ReservationService (reservationRepository, inventoryservices, new SystemDateTimeService ());
			serviceDeReservation.ReserveSeatsForVenue (new Billetterie.Model.Common.Seat[] { new Billetterie.Model.Common.Seat (siege) }, 
			new Show (), new Customer (client));

		}

		public bool BilletDansInventaire(string siege)
		{
			return true;
		}
	}
}

