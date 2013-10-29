using System;
using Billetterie.Model.Common;


namespace artishowFixture
{
	public class ExtraireTaxes
	{
		decimal _tpsTaux;
		decimal _tvqTaux;
		decimal _tps;
		decimal _tvq;
		decimal _net;



		public ExtraireTaxes (decimal TpsTaux, decimal TvqTaux)
		{
		
			this._tpsTaux = TpsTaux;
			this._tvqTaux = TvqTaux;
		}

		public void ExtraireTaxesPour(decimal montantBrut)
		{
			
			var processor = new Billetterie.Model.Common.NetTotalCalculationStrategy (new Billetterie.Model.Common.Rate[] {
				new Billetterie.Model.Common.Rate ("tps", _tpsTaux), new Billetterie.Model.Common.Rate ("tvq", _tvqTaux)
			});
			var total= processor.Process (montantBrut);
			_tps = total.Taxes [0].Amount;
			_tvq = total.Taxes [1].Amount;

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
	}
}

