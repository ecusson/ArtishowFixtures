using System;
using Billetterie.Model.Common;
using Billetterie.Model.Common.Services;
using Billetterie.Model.Inventory;
using Billetterie.Model.Inventory.Services;
using SharpRepository.Repository;
using Billetterie.Model.Reservations.Services;
using Billetterie.Model.Reservation.Services;
using Billetterie.Model.Reservations;
using System.Collections.Generic;
using Billetterie.Model.Common.Events;



namespace artishowFixture
{
	public class StubReservationNumbersGenerator : IReservationNumbersGenerator
	{
		public Stack<String> ReservationNumbers = new Stack<string>();


		#region IReservationNumbersGenerator implementation

		public string GetNext ()
		{
			return ReservationNumbers.Pop ();
		}

		#endregion



	}

	public abstract class ReservationFixtureBase
	{

		protected SharpRepository.InMemoryRepository.InMemoryRepository<SeatInventoryItem,String> inventory = new SharpRepository.InMemoryRepository.InMemoryRepository<SeatInventoryItem,string>();
		protected SharpRepository.InMemoryRepository.InMemoryRepository<ShowReservations,string> reservationRepository = new SharpRepository.InMemoryRepository.InMemoryRepository<ShowReservations,string>();
		protected SharpRepository.InMemoryRepository.InMemoryRepository<InventorySeatLock,string> lockinventory = new SharpRepository.InMemoryRepository.InMemoryRepository<InventorySeatLock,string>();
		protected SharpRepository.InMemoryRepository.InMemoryRepository<VenueDefinition,String> venueRespository = new SharpRepository.InMemoryRepository.InMemoryRepository<VenueDefinition, string> ();
		protected StubReservationNumbersGenerator reservationNumbersGenerator = new StubReservationNumbersGenerator();
		protected IInventoryControlService inventoryservices;
		protected IDateTimeService dateTimeService = new SystemDateTimeService();
		protected DateTime SHOW_DATE;

	
		protected string CurrentShowMnemonic;
		protected string CurrentCustomer;
		protected ReservationNumber currentShowReservationNumber;

		protected void SetActiveShow (string mnemonic)
		{
            CurrentShowMnemonic = mnemonic;
            if (reservationRepository.Find(sr=>sr.Show.Name==mnemonic)==null)
            {
				var showReservations = new ShowReservations (new Show (mnemonic, new Venue (Guid.NewGuid().ToString()), SHOW_DATE));
				reservationRepository.Add (showReservations);
				currentShowReservationNumber = null;
			}
			
			
		}
		protected void SetActiveCustomer (string mnemonic)
		{
			CurrentCustomer = mnemonic;


		}

		protected string GetCurrentCustomer()
		{
			return  CurrentCustomer;
		}



		protected void AddSeatToInventory(string siege, decimal prix=0.00m)
		{
			inventory.Add(new SeatInventoryItem(new Seat(siege,new PriceTag(prix)),GetActiveShow()));
		}

		public virtual void GenererInventairePourSpectacle(string siege, string spectacle)
		{
					this.SetActiveShow (spectacle);
					this.AddSeatToInventory (siege);
		}
		public virtual void GenererInventairePourSpectacleEtPrix(string siege, string spectacle, decimal prix)
		{
			this.SetActiveShow (spectacle);
			this.AddSeatToInventory (siege,prix);
		}

		public virtual void CreerReservationPourClientEtSpectacle(string noReservation, string nomClient, string spectacle)
		{
			reservationNumbersGenerator.ReservationNumbers.Push (noReservation);
			this.SetActiveShow (spectacle);
			this.SetActiveCustomer (nomClient);



		}

		public virtual void AjouterBilletDansReservationAuPrixDe(string siege, string noReservation, decimal prix)
		{
			if (currentShowReservationNumber == null)
				this.ReserveSeat (siege, GetCurrentCustomer (), prix);
			else
				this.ReserveSeat (siege, GetCurrentCustomer (), noReservation);
		}
	



		public virtual bool ReserverBilletPourClientEtSpectacleEtNoReservation( string siege, string nomClient, string spectacle, string noReservation)
		{
			try
			{

			this.SetActiveShow (spectacle);
			this.ReserveSeat (siege, nomClient, noReservation);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public virtual void AjouterFraisAuMontantDe(string nomFrais, decimal prix)
		{

		}

		public virtual decimal TotalReservation(string noReservation)
		{
			return 0.00m;
		}

		public virtual void ReserverBilletPourClientEtSpectacleEtNoReservationAuPrixDe( string siege, string nomClient, string spectacle, string noReservation, decimal prix)
		{
			this.SetActiveShow (spectacle);
			this.ReserveSeat (siege, nomClient, noReservation, prix);
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

			inventoryservices = new InventoryService(lockinventory,inventory,venueRespository, dateTimeService,timeout);
		}

		protected	void ReserveSeat (string siege, string nomClient)
		{

	
			var serviceDeReservation = new ReservationService (reservationRepository, inventoryservices, new SystemDateTimeService (), reservationNumbersGenerator);
			this.currentShowReservationNumber =	serviceDeReservation.ReserveSeats (new [] { new Seat (siege) }, GetActiveShow(), new Customer (nomClient)); 

		}

		protected	void ReserveSeat (string siege, string nomClient, decimal prix)
		{


			var serviceDeReservation = new ReservationService (reservationRepository, inventoryservices, new SystemDateTimeService (), reservationNumbersGenerator);
			this.currentShowReservationNumber = serviceDeReservation.ReserveSeats (new [] { new Seat (siege) }, GetActiveShow(), new Customer (nomClient)); 

		}

		protected	void ReserveSeat (string siege, string nomClient,  string reservationNumber, decimal prix)
		{


			var serviceDeReservation = new ReservationService (reservationRepository, inventoryservices, new SystemDateTimeService (),reservationNumbersGenerator);
			serviceDeReservation.AddSeatsToReservation (new ReservationNumber (reservationNumber), GetActiveShow (), new Customer (nomClient), new [] { new Seat (siege, new PriceTag (prix)) });

		}

		protected	void ReserveSeat (string siege, string nomClient,  string reservationNumber)
		{


			this.ReserveSeat (siege, nomClient, reservationNumber,0.00m);


		}
	}
}
