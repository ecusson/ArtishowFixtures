using System;
using Billetterie.Model.Common;
using Billetterie.Model.Common.Services;
using Billetterie.Model.Inventory;
using SharpRepository.Repository;
using Billetterie.Model.Reservations.Services;
using Billetterie.Model.Reservation.Services;
using Billetterie.Model.Reservations;
using System.Collections.Generic;
using Billetterie.Model.Common.Events;
using SharpRepository.InMemoryRepository;
using Billetterie.Model.Invoincing;



namespace artishowFixture
{


	public abstract class ReservationFixtureBase
	{
		protected IRepository<SeatReservation, String> seatReservationsRepository = new InMemoryRepository<SeatReservation, String>();
		protected	IRepository<InventorySeat, String> seatRepository = new InMemoryRepository<InventorySeat, String>();
		protected IRepository<ReservationNumber, String> reservationNumbersRepository = new InMemoryRepository<ReservationNumber, String>();
		protected IRepository<ShowPricingPolicy, String> showPricingPolicyRepository = new InMemoryRepository<ShowPricingPolicy, String>();
		protected IRepository<ReservationFee, String> reservationFeesRepository = new InMemoryRepository<ReservationFee, String>();
		protected IRepository<Invoice, String> invoiceRepository = new InMemoryRepository<Invoice, String>();



		protected IDateTimeService dateTimeService = new SystemDateTimeService();
		protected DateTime SHOW_DATE;

		protected InvoicingService invoicingService;
		protected ReservationService reservationService;
	
		protected Dictionary<string, Show> shows = new Dictionary<string, Show>();
		protected string CurrentShowMnemonic;
		protected string CurrentCustomer;
		protected string currentShowReservationNumber=null;

		private const string DEFAULT_CATEGORY = "regulier";
		protected const string DEFAULT_RESERVATIONNUMBER = "123456";

	 protected	ITotalCalculationStrategy netCalculationStrategy = new NetTotalCalculationStrategy(new Rate[] { new Rate("TPS",  0.05m), 
			new Rate("TVQ", 0.09975m) });

		protected void SetActiveShow (string mnemonic)
		{
			this.SetActiveShow (mnemonic, dateTimeService.GetDateTime ().Date.ToString ("s"), "VENUE123");
		}

		protected void SetActiveShow (string mnemonic, string date, string venue)
		{
			currentShowReservationNumber = null;
			CurrentShowMnemonic = mnemonic;
			if (shows.ContainsKey (mnemonic)) {

			} else {
				shows.Add (mnemonic, new Show (mnemonic, new Venue (venue), DateTime.Parse(date)));
			}


		}

		public decimal GetTotalGrossAmountDueForCustomer()
		{
			return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer ())).Total.GrossTotal;
		}
		public decimal GetTotalNetAmountDueForCustomer()
		{
			return invoicingService.GetInvoiceTotals (new Customer(this.GetCurrentCustomer ())).Total.NetTotal;
		}

		protected void SetActiveCustomer (string mnemonic)
		{
			CurrentCustomer = mnemonic;


		}

		protected string GetCurrentCustomer()
		{
			return  CurrentCustomer;
		}


		protected void InvoiceFee(decimal amount)
		{
			invoicingService.InvoiceShippinFee (new Customer (GetCurrentCustomer ()), amount);
		}



		protected void AddSeatToInventory(string siege, decimal prix=0.00m)
		{
			seatRepository.Add(new InventorySeat(this.GetActiveShow(), siege,prix));

		}

		protected void AddSeatToInventory(string siege,decimal rabais, string categorieRabais, decimal prix=0.00m)
		{
            ShowPricingPolicy showPolicy;

            if (!showPricingPolicyRepository.TryGet(GetActiveShow().Id, out showPolicy))
            {
                showPolicy  = new ShowPricingPolicy(new Dictionary<string,decimal>(), new Dictionary<string,decimal>(),GetActiveShow());
                showPricingPolicyRepository.Add(showPolicy);
            }
            if(!  showPolicy.ApplicableDiscounts.ContainsKey(categorieRabais))
            {
                showPolicy.ApplicableDiscounts.Add(categorieRabais, rabais);
                showPricingPolicyRepository.Update(showPolicy); 
            }

            


			seatRepository.Add(new InventorySeat(this.GetActiveShow(), siege,prix));
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



		public virtual bool AjouterBilletDansReservationAuPrixDe(string siege, string noReservation, decimal prix)
		{
			try
			{
            //if (currentShowReservationNumber == null)
            //    this.ReserveSeat (siege, GetCurrentCustomer (), prix);
            //else
				this.ReserveSeat (siege, GetCurrentCustomer (), noReservation);
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}
	



		public virtual bool ReserverBilletPourClientEtSpectacleEtNoReservation( string siege, string nomClient, string spectacle, string noReservation)
		{
			try
			{

			this.SetActiveShow (spectacle);
				this.CreerReservationPourClientEtSpectacle(noReservation,nomClient,spectacle);
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
			this.AddSeatsToReservation (siege, nomClient, noReservation, prix);
		}



		protected InventorySeat GetSeatFromInventory(string mnemonic)
		{
			return 	seatRepository.Find(s=>(s.SeatNumber==mnemonic && s.Show.Name== GetActiveShow().Name));
		}

		protected Show GetActiveShow()
		{
			return shows [CurrentShowMnemonic];
		}


		public ReservationFixtureBase ()
		{
			DomainEventsPublisher.GetInstance ().Reset ();
			SHOW_DATE = dateTimeService.GetDateTime ();
		 	invoicingService = new InvoicingService (invoiceRepository,netCalculationStrategy,dateTimeService);
			reservationService = new ReservationService (seatReservationsRepository, seatRepository, reservationNumbersRepository, showPricingPolicyRepository, reservationFeesRepository, invoiceRepository, dateTimeService);


		}

		
		protected	void ReserveSeat (string siege, string nomClient)
		{
			this.ReserveSeat (siege, nomClient, 0.00m);
		}

		protected	void ReserveSeat (string siege, string nomClient, decimal prix)
		{


			this.ReserveSeat (siege, nomClient, DEFAULT_RESERVATIONNUMBER,prix,DEFAULT_CATEGORY);



		}

		protected	void AddSeatsToReservation (string siege, string nomClient,  string reservationNumber, decimal prix)
		{


			AddSeatsToReservation (siege, nomClient, reservationNumber, prix, DEFAULT_CATEGORY);
			                                         

		}

		protected	void AddSeatsToReservation (string siege, string nomClient,  string reservationNumber, decimal prix, string category)
		{


			this.currentShowReservationNumber = reservationNumber;
			var seat =	new InventorySeat (GetActiveShow (), siege, prix);
			reservationService.AddSeatsToReservation (reservationNumber, new Customer (nomClient), new []{ seat }, category);


		}


		protected	void ReserveSeat (string siege, string nomClient,  string reservationNumber)
		{

			this.ReserveSeat (siege, nomClient, reservationNumber, 0.00m, DEFAULT_CATEGORY);


		}
		protected	void ReserveSeat (string siege, string nomClient,  string reservationNumber, decimal prix)
		{

			this.ReserveSeat (siege, nomClient, reservationNumber, prix, DEFAULT_CATEGORY);
		

		}

		protected	void ReserveSeat (string siege, string nomClient,  string reservationNumber, decimal prix, string category)
		{

		

			reservationService.AddSeatsToReservation (reservationNumber, new Customer (nomClient), new [] { new InventorySeat (GetActiveShow (), siege, prix) }, category); 


		}


        protected void ReserveSeatWithCategory(string siege, string nomClient, string categorie)
        {
			this.ReserveSeat (siege, nomClient, DEFAULT_RESERVATIONNUMBER, 0.00m, categorie);
        }

		public virtual bool CreerReservationPourClientEtSpectacle(string noReservation, string nomClient, string spectacle)
		{
			try
			{
			
				this.SetActiveShow (spectacle);
				this.SetActiveCustomer (nomClient);
				this.currentShowReservationNumber= reservationService.CreateReservation(noReservation,new Customer(nomClient),GetActiveShow());
				return true;
			}
			catch
			{
				return false;
			}


		}

	}
}
