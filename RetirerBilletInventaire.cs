using System;
using Billetterie.Model.Common;
using Billetterie.Model.Inventory;
using SharpRepository.Repository;


namespace artishowFixture
{
	public class RetirerBilletInventaire
	{
		SharpRepository.InMemoryRepository<SeatInventoryItem,String> inventory = new SharpRepository.InMemoryRepository<SeatInventoryItem,String>();



		public RetirerBilletInventaire ()
		{
		}

		public void GenererInventaire(string siege)
		{

		}

		public void confirmerbilletPourClient(string siege, string Client)
		{

		}

		public bool BilletDansInventaire(string siege)
		{
			return true;
		}
	}
}

