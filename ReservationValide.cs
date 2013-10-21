using System;

namespace artishowFixture
{
	public class ReservationValide
	{
		private int nbsieges;
  		private bool frais;
  		private bool marchandise;
		private bool client;
		
		public void reservationValide()
		{
			
		}
		
		public void setNombreDeSieges(int nbsieges)
		{
			this.nbsieges=nbsieges;
		}
		
		public void setfrais(Boolean frais)
		{
			this.frais=frais;
		}
		
		public void setmarchandise(Boolean marchandise)
		{
			this.marchandise = marchandise;
		}
		
		public void setClient (Boolean client)
		{
			this.client=client;
		}
		
		public string valide()
		{

			if (client&&(frais||marchandise||nbsieges>0))
			{
				 return "Y";	
				
			}
			else
			{
				return "N";
			}
				 
		}
		
	}
}

