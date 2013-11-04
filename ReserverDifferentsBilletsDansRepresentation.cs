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


		public long InventaireCount(string spectacle)
		{
			return inventory.Count(s=>s.Show.Name==spectacle);
		}

		public bool inventaireContientPasPourSpectacle(string siege, string spectacle)
		{
			this.SetActiveShow (spectacle);
			return this.GetSeatFromInventory (siege)==null;

		}





	}
}

