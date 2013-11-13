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
	public class UnSeulClientParReservation : ReservationFixtureBase
	{
		public UnSeulClientParReservation () :base()
		{
		}

		public bool AjouterNomDansReservation(string client, string noReservation)
		{
			try {
				//There is no API call to simply add a name in a reservation.
				//So we create a seat and try to make a reservation for it using the given customer name.
				string newSeat = Guid.NewGuid().ToString();
				this.AddSeatToInventory(newSeat);
				this.AddSeatsToReservation(newSeat,client,noReservation,0.00m);
				return false;

			} catch {

				return true;
			}
		}
	}
}

