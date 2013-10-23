using System;

namespace artishowFixture
{
	public class CalculTaxes
	{
		string _tpsTaux;
		string _tvqTaux;
		string _tps;
		string _tvq;

		public CalculTaxes (string  TpsTaux, string TvqTaux)
		{
			this._tpsTaux = TpsTaux;
			this._tvqTaux = TvqTaux;
		}

		public void CalculerTaxesPour(string montantNet)
		{
		
			_tps = Convert.ToString(Convert.ToDecimal(montantNet)*Convert.ToDecimal(_tpsTaux));
			_tvq = Convert.ToString(Convert.ToDecimal(montantNet) *Convert.ToDecimal( _tvqTaux));
		}

		public string tps()
		{
			return _tps;
		}

		public string tvq()
		{
			return _tvq;
		}

	}
}

