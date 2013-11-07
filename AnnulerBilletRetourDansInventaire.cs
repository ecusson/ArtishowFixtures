using System;
using Billetterie.Model.Common;
using Billetterie.Model.Common.Services;

using Billetterie.Model.Inventory;
using SharpRepository.Repository;
using Billetterie.Model.Reservations.Services;
using Billetterie.Model.Reservations;

namespace artishowFixture
{
	public class AnnulerBilletRetourDansInventaire : ReservationFixtureBase
	{

		public AnnulerBilletRetourDansInventaire () : base()
		{
		}

		public void GenererInventaire(string siege)
		{

		}

		public void offrirBilletPourClient(string siege, string client)
		{

		}

		public void confirmerBilletPourClientNoReservation(string siege, string client,string noReservation)
		{
		

		}

		public void AnnulerBilletDeClientDansReservation(string siege, string client, string noReservation)
		{

		}

		public bool BilletDansInventaire(string siege)
		{
			return false;
		}
	}
}

