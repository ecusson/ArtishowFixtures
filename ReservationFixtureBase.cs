using System;
using Billetterie.Model.Inventory;
using Billetterie.Model.Reservations;
using Billetterie.Model.Inventory.Services;
using System.Collections.Generic;
using Billetterie.Model.Common;
using Billetterie.Model.Reservations.Services;
using Billetterie.Model.Common.Services;

namespace artishowFixture
{
	public abstract class ReservationFixtureBase
	{

		protected SharpRepository.InMemoryRepository.InMemoryRepository<SeatInventoryItem,String> inventory = new SharpRepository.InMemoryRepository.InMemoryRepository<SeatInventoryItem,string>();
		protected SharpRepository.InMemoryRepository.InMemoryRepository<Reservation,string> reservationRepository = new SharpRepository.InMemoryRepository.InMemoryRepository<Reservation,string>();
		protected SharpRepository.InMemoryRepository.InMemoryRepository<InventorySeatLock,string> lockinventory = new SharpRepository.InMemoryRepository.InMemoryRepository<InventorySeatLock,string>();
		protected IInventoryControlService inventoryservices;
		protected Dictionary<string,ReservationId> currentReservations = new Dictionary<string, ReservationId>();
		protected DateTime SHOW_DATE=DateTime.Now;

		public ReservationFixtureBase ()
		{


			InitializeInventoryServices (10000);

		}

		protected virtual void InitializeInventoryServices(int timeout)
		{

			inventoryservices = new InventoryService(lockinventory,inventory, new SystemDateTimeService (),timeout);
		}

		protected	void CreateNewOrAddToReservation (string siege, string nomClient, string spectacle, string NoReservation)
		{
			var serviceDeReservation = new ReservationService (reservationRepository, inventoryservices, new SystemDateTimeService ());

			if (!currentReservations.ContainsKey (nomClient)) {
				currentReservations.Add (nomClient, serviceDeReservation.ReserveSeatsForVenue (new Billetterie.Model.Common.Seat[] {
					new Billetterie.Model.Common.Seat (siege)
				}, new Show (new Venue (spectacle), SHOW_DATE), new Customer (nomClient)));
			}
			else {
				serviceDeReservation.AddSeatsToReservation (currentReservations [nomClient], new Billetterie.Model.Common.Seat[] {
					new Billetterie.Model.Common.Seat (siege)
				});
			}
		}
	}
}

