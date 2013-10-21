using System;

namespace artishowFixture
{
	public class CalculTaxes
	{
		string _tps;
		string _tvq;

		public CalculTaxes (string  TpsTaux, string TvqTaux)
		{
		}

		public void calculTaxes(int montantNet)
		{
		
			_tps = "50";
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

