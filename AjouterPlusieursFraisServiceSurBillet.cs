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
	public class AjouterPlusieursFraisServiceSurBillet
	{
		SharpRepository.InMemoryRepository.InMemoryRepository<SeatInventoryItem,String> inventory = new SharpRepository.InMemoryRepository.InMemoryRepository<SeatInventoryItem,string>();
		SharpRepository.InMemoryRepository.InMemoryRepository<Reservation,string> reservationRepository = new SharpRepository.InMemoryRepository.InMemoryRepository<Reservation,string>();
		SharpRepository.InMemoryRepository.InMemoryRepository<InventorySeatLock,string> lockinventory = new SharpRepository.InMemoryRepository.InMemoryRepository<InventorySeatLock,string>();
		IInventoryControlService inventoryservices;


		public AjouterPlusieursFraisServiceSurBillet ()

		{
			inventoryservices = new InventoryService(lockinventory,inventory, new SystemDateTimeService (),10000);
		}

		public void CreerReservationAuNomDe(string noReservation, string nomClient)
		{
			var serviceDeReservation = new ReservationService (reservationRepository, inventoryservices, new SystemDateTimeService ());
			serviceDeReservation.ReserveSeatsForVenue (new Billetterie.Model.Common.Seat[] { new Billetterie.Model.Common.Seat ("any") }, 
			new Show (), new Customer (nomClient));

		}

		public void AjouterBilletAuPrixDeAvecFraisDeServiceDe(string siege, decimal prix, decimal frais) 
		{

		}

		public void  AjouterFraisDeSurBilletDeReservation(decimal frais, string siege, string noReservation)
		{

		}

		public decimal totalReservation()
		{
			return 0.00m;
		}

		public decimal totalFrais()
		{
			return 0.00m;
		}

		public decimal totalBillets()
		{
			return 0.00m;
		}
	}
}
