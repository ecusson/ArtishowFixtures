using System;
using Billetterie.Model.Common;
using Billetterie.Model.Common.Services;
using Billetterie.Model.Inventory.Services;
using Billetterie.Model.Inventory;
using SharpRepository.Repository;
using Billetterie.Model.Reservations.Services;
using Billetterie.Model.Reservations;
using System.Collections.Generic;


namespace artishowFixture


{
	public class ReserverDifferentsBilletsDansRepresentation : ReservationFixtureBase
	{


		public ReserverDifferentsBilletsDansRepresentation () : base()
		{

		}

		public void GenererInventairePourSpectacle(string siege, string spectacle)
		{
			inventory.Add (new SeatInventoryItem (new Billetterie.Model.Common.Seat (siege), new Show (new Venue(spectacle),SHOW_DATE)));
		}

		public bool ReserverBilletPourClientEtSpectacle(string siege, string nomClient, string spectacle)
		{
			try{
				CreateNewOrAddToReservation (siege, nomClient, spectacle, new ReservationNumber("Any"));
				return true;
			}
			catch{return false;}

		}

		public long InventaireCount(string spectacle)
		{
			return inventory.Count(s=>s.Show.Venue.Name==spectacle);
		}

		public bool inventaireContientPasPourSpectacle(string siege, string spectacle)
		{
			if (inventory.Find (s => s.Seat.Number == siege && s.Show.Venue.Name==spectacle) != null) {
				return false;
			} else {
				return true;}

		}





	}
}

