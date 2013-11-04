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
	public class UnSeulClientParReservation : ReservationFixtureBase
	{
		public UnSeulClientParReservation () :base()
		{
		}

		public void GenererInventairePourSpectacle(string siege, string spectacle)
		{
			this.SetActiveShow (spectacle);
			this.AddSeatToInventory (siege);
		}

		public void ReserverBilletPourClientEtSpectacleEtNoReservation( string siege, string nomClient, string spectacle, string noReservation)
		{
			this.SetActiveShow (spectacle);
			this.ReserveSeat (siege, nomClient, new ReservationNumber (noReservation));
		}

		public bool AjouterNomDansReservation(string client, string noReservation)
		{
			try {

				return true;
			} catch {

				return false;
			}
		}
	}
}

