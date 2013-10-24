using System;
using Billetterie.Model.Common;


namespace artishowFixture
{
	public class ExtraireTaxes
	{
		string _tpsTaux;
		string _tvqTaux;
		string _tps;
		string _tvq;
		string _net;



		public ExtraireTaxes (string TpsTaux, string TvqTaux)
		{
		
			this._tpsTaux = TpsTaux;
			this._tvqTaux = TvqTaux;
		}

		public void ExtraireTaxesPour(string montantBrut)
		{
			
			var processor = new Billetterie.Model.Common.NetTotalCalculationStrategy (new Billetterie.Model.Common.Rate[] {
				new Billetterie.Model.Common.Rate ("tps", Decimal.Parse (_tpsTaux)), new Billetterie.Model.Common.Rate ("tvq", Decimal.Parse (_tvqTaux))
			});
			var total= processor.Process (new PriceTag(Decimal.Parse (montantBrut)));
			_tps = total.Taxes [0].Amount.ToString ();
			_tvq = total.Taxes [1].Amount.ToString ();
			_net = total.NetTotal.ToString ();

		}

		public string tps()
		{
			return _tps;
		}

		public string tvq()
		{
			return _tvq;
		}
		public string net()
		{
			return _net;
		}
	}
}

