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
	public class ReservationValide : ReservationFixtureBase
	{
		private int nbsieges;
  		private int frais;
  		private int marchandise;
		private int client;
		
		public ReservationValide () : base ()
		{

		}
		
		public void setNombreDeSieges(int nbsieges)
		{
			this.nbsieges=nbsieges;
		}

		public void setfrais(int frais)
		{
			this.frais=frais;
		}
		
		public void setmarchandise(int marchandise)
		{
			this.marchandise = marchandise;
		}
		
		public void setClient (int client)
		{
			this.client=client;
		}
		
		public string valide()
		{

		
				return null;
		
				 
		}
		
	}
}

