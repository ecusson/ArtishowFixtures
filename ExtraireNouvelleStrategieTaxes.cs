using System;
using Billetterie.Model.Common;


namespace artishowFixture
{
	public class ExtraireNouvelleStrategieTaxes
	{
		decimal _tpsTaux;
		decimal _tvqTaux;
		decimal _amusementTaux;
		decimal _tps;
		decimal _tvq;
		decimal _amusement;
		decimal _net;



		public ExtraireNouvelleStrategieTaxes (decimal tpsTaux, decimal tvqTaux, decimal amusementTaux)
		{

			this._tpsTaux = tpsTaux;
			this._tvqTaux = tvqTaux;
			this._amusementTaux = amusementTaux;
		}

		public void ExtraireTaxesPour(decimal montantBrut)
		{

			var processor = new Billetterie.Model.Common.NetTotalCalculationStrategy (new Billetterie.Model.Common.Rate[] {
				new Billetterie.Model.Common.Rate ("tps", _tpsTaux), new Billetterie.Model.Common.Rate ("tvq", _tvqTaux), new Billetterie.Model.Common.Rate("amusement",_amusementTaux)
			});
			var total= processor.Process (new PriceTag(montantBrut));
			_tps = total.Taxes [0].Amount;
			_tvq = total.Taxes [1].Amount;
			_amusement = total.Taxes [2].Amount;
			_net = total.NetTotal;

		}

		public decimal tps()
		{
			return _tps; 
		}

		public decimal tvq()
		{
			return _tvq;
		}
		public decimal net()
		{
			return _net;
		}

		public decimal TaxeAmusement()
		{
			return _amusement;
		}
	}
}

