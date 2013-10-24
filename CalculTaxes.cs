using System;
using Billetterie.Model.Common;



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

