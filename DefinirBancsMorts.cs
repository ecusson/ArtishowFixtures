using System;
using Billetterie.Model.Common;
using Billetterie.Model.Common.Services;
using Billetterie.Model.Inventory;
using Billetterie.Model.Inventory.Services;
using SharpRepository.Repository;
using Billetterie.Model.Reservations.Services;
using Billetterie.Model.Reservations;
using System.Collections.Generic;

namespace artishowFixture
{
	public class DefinirBancsMorts : ReservationFixtureBase

	{
		public DefinirBancsMorts () : base()
		{

		}

		public void GenererInventaire(string siege)
		{
			inventory.Add (new SeatInventoryItem (new Billetterie.Model.Common.Seat (siege), new Show ()));
		}

		public void IdentifierBancMort(string siege)
		{
		
		}

		public bool InventaireNeContientPas(string siege)
		{
			if (inventory.Find (s => s.Seat.Number == siege) != null) {
				return false;
			} else {
				return true;}
		}

	}
}

