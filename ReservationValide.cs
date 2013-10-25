using System;

namespace artishowFixture
{
	public class ReservationValide
	{
		private int nbsieges;
  		private int frais;
  		private int marchandise;
		private int client;
		
		public void reservationValide()
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

			if (client>0&&(frais>0||marchandise>0||nbsieges>0))
			{
				 return "1";	
				
			}
			else
			{
				return "0";
			}
				 
		}
		
	}
}

