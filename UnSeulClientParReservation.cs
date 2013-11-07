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

				return true;
			} catch {

				return false;
			}
		}
	}
}

