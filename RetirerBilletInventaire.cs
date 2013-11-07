using System;
using Billetterie.Model.Common;
using Billetterie.Model.Common.Services;

using Billetterie.Model.Inventory;
using SharpRepository.Repository;
using Billetterie.Model.Reservations.Services;
using Billetterie.Model.Reservations;


namespace artishowFixture
{
	public class RetirerBilletInventaire : ReservationFixtureBase
	{


		public RetirerBilletInventaire ():base()
		{
			this.SetActiveShow ("SHOW1");
		}

		public void GenererInventaire(string siege)
		{
			this.AddSeatToInventory (siege);
		}

		public void confirmerbilletPourClient(string siege, string nomClient)
		{




		}

		public bool BilletDansInventaire(string siege)
		{
			var seat = this.GetSeatFromInventory (siege);
			return (seat != null);
		}
	}
}

