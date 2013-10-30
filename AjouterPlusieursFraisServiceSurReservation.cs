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
	public class AjouterPlusieursFraisServiceSurReservation : ReservationFixtureBase
	{

		public AjouterPlusieursFraisServiceSurReservation () :base()
		{
			this.SetActiveShow ("SHOW");
		}

		public void CreerReservationAuNomDeAvecTotalDe(string noReservation, string nomClient, decimal total)
		{

		}

		public void AjouterFraisSurReservation(decimal frais, string noReservation)
		{

		}

		public decimal TotalReservation(string noReservation)
		{
			return 0.0m;
		}
	}
}

