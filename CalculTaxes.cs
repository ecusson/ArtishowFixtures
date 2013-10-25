using System;
using Billetterie.Model.Common;



namespace artishowFixture
{
	public class CalculTaxes
	{
		decimal _tpsTaux;
		decimal _tvqTaux;
		decimal _tps;
		decimal _tvq;
		decimal _montantBrut;

		public CalculTaxes (decimal  TpsTaux, decimal TvqTaux)
		{
			this._tpsTaux = TpsTaux;
			this._tvqTaux = TvqTaux;
		}

		public void CalculerTaxesPour(decimal montantNet)
		{
			_tps = Math.Round(montantNet * _tpsTaux,2);
			_tvq = Math.Round(montantNet * _tvqTaux,2);
			_montantBrut = montantNet + _tps + _tvq;

		}


		public decimal tps()
		{
			return _tps;
		}

		public decimal tvq()
		{
			return _tvq;
		}

		public decimal montantbrut()
		{
			return _montantBrut;
		}

	}
}

