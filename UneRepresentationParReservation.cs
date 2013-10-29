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
	public class UneRepresentationParReservation : ReservationFixtureBase
	{

	
		public UneRepresentationParReservation () : base()
		{
		}


		public void GenererInventairePourSpectacle(string siege, string spectacle)
		{
			inventory.Add (new SeatInventoryItem (new Billetterie.Model.Common.Seat (siege), new Show (new Venue(spectacle),SHOW_DATE)));
		}

		public bool ReserverBilletPourClientEtSpectacle(string siege, string nomClient, string spectacle)
		{
			try{
				CreateNewOrAddToReservation (siege, nomClient, spectacle,new ReservationNumber( "any"));
				return true;
			}
			catch{return false;}

		}



	}
}

