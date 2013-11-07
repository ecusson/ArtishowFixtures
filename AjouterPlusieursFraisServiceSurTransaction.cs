using System;
using Billetterie.Model.Common;
using Billetterie.Model.Common.Services;

using Billetterie.Model.Inventory;
using SharpRepository.Repository;
using Billetterie.Model.Reservations.Services;
using Billetterie.Model.Reservations;
namespace artishowFixture
{
	public class AjouterPlusieursFraisServiceSurTransaction : ReservationFixtureBase
	{

		public AjouterPlusieursFraisServiceSurTransaction () :base()
		{
	
		}


		public void CreerReservationAuNomDeAvecTotalDe(string noReservation, string nomClient, decimal total)
		{
		

		}

		public void AjouterFraisSurTransaction(decimal frais, string noTransaction)
		{

		}

		public decimal TotalTransaction(string noTransaction)
		{
			return 0.00m;
		}
	}
	}

