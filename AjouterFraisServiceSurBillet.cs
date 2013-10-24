using System;

namespace artishowFixture
{
	public class AjouterFraisServiceSurBillet
	{
		decimal _prix;
		decimal _frais;
		public AjouterFraisServiceSurBillet ()
		{
		}

		public void CreerReservationAuNomDe(string noReservation, string nomClient)
		{

		}

		public void AjouterBilletAuPrixDeAvecFraisDeServiceDe(string siege, decimal prix, decimal frais) 
		{
			_prix = prix;
			_frais = frais;
		}

		public decimal totalReservation()
		{
			return (_prix+_frais)*2;
		}

		public decimal totalFrais()
		{
			return _frais*2;
		}

		public decimal totalBillets()
		{
			return _prix*2;
		}

	}
}

