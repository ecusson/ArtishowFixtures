using System;
using Billetterie.Model.Common;
using Billetterie.Model.Common.Services;
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


		public bool ReserverBilletPourClientEtSpectacle(string siege, string nomClient, string spectacle)
		{
			try{
				this.ReserveSeat (siege, nomClient);
				return true;
			}
			catch{return false;}

		}



	}
}

