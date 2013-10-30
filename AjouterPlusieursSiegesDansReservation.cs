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
	public class AjouterPlusieursSiegesDansReservation : ReservationFixtureBase
	{



		public AjouterPlusieursSiegesDansReservation () :base()
		{
			this.SetActiveShow ("SHOW");
		}

		public void GenererInventaire(string siege)
		{
			this.AddSeatToInventory (siege);
		}

		public void ReserverBilletPourClient(string siege, string nomClient)
		{
			this.ReserveSeat (siege, nomClient, new ReservationNumber ("123456"));

		}


		public bool ReservationPourContientBillet(string nomClient, string siege)
		{
		
			return reservationRepository.Exists (sr=>sr.SeatReservations.Exists(seatR=>seatR.Customer.Id==nomClient && seatR.Seat.Number==siege));


		}

		public long InventaireCount()
		{
			return inventory.LongCount ();
		}

		public bool inventaireContientPas(string siege)
		{

			return  this.GetSeatFromInventory (siege)==null;


		}

	}
}

