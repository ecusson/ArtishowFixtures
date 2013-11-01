using System;
using Billetterie.Model.Common;
using Billetterie.Model.Common.Services;
using Billetterie.Model.Inventory;
using Billetterie.Model.Inventory.Services;
using SharpRepository.Repository;
using Billetterie.Model.Reservations.Services;
using Billetterie.Model.Reservations;
using System.Collections.Generic;
using Billetterie.Model.Common.Events;



namespace artishowFixture
{
	public abstract class ReservationFixtureBase
	{

		protected SharpRepository.InMemoryRepository.InMemoryRepository<SeatInventoryItem,String> inventory = new SharpRepository.InMemoryRepository.InMemoryRepository<SeatInventoryItem,string>();
		protected SharpRepository.InMemoryRepository.InMemoryRepository<ShowReservations,string> reservationRepository = new SharpRepository.InMemoryRepository.InMemoryRepository<ShowReservations,string>();
		protected SharpRepository.InMemoryRepository.InMemoryRepository<InventorySeatLock,string> lockinventory = new SharpRepository.InMemoryRepository.InMemoryRepository<InventorySeatLock,string>();
		protected IInventoryControlService inventoryservices;
		protected IDateTimeService dateTimeService = new SystemDateTimeService();
		protected DateTime SHOW_DATE;

	
		protected string CurrentShowMnemonic;

		protected void SetActiveShow (string mnemonic)
		{
            CurrentShowMnemonic = mnemonic;
            if (reservationRepository.Find(sr=>sr.Show.Name==mnemonic)==null)
            {
				var showReservations = new ShowReservations (new Show (mnemonic, new Venue (Guid.NewGuid().ToString()), SHOW_DATE));
				reservationRepository.Add (showReservations);
			}
			
			
		}

		protected void AddSeatToInventory(string mnemonic)
		{
			inventory.Add(new SeatInventoryItem(new Seat(mnemonic),GetActiveShow()));
		}

		protected SeatInventoryItem GetSeatFromInventory(string mnemonic)
		{
		  return 	inventory.Find(s=>(s.Seat.Number==mnemonic) && (s.Show.Name==GetActiveShow().Name));
		}

		protected Show GetActiveShow()
		{
            return reservationRepository.Find(sr => sr.Show.Name == CurrentShowMnemonic).Show;
		}


		public ReservationFixtureBase ()
		{
			DomainEventsPublisher.GetInstance ().Reset ();
			SHOW_DATE=dateTimeService.GetDateTime();
			inventory.Dispose ();
			lockinventory.Dispose ();
			reservationRepository.Dispose ();
			InitializeInventoryServices (10000);

		}



		protected virtual void InitializeInventoryServices(int timeout)
		{

			inventoryservices = new InventoryService(lockinventory,inventory, dateTimeService,timeout);
		}

		protected	void ReserveSeat (string siege, string nomClient,  ReservationNumber NoReservation)
		{

	
			var serviceDeReservation = new ReservationService (reservationRepository, inventoryservices, new SystemDateTimeService ());
			serviceDeReservation.ReserveSeats (new [] { new Seat (siege) }, GetActiveShow(), new Customer (nomClient)); 

		}
	}
}
