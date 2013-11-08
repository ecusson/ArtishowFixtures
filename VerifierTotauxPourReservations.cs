using System;
using Billetterie.Model.Common;
using System.Collections.Generic;

namespace artishowFixture
{
	public class VerifierTotauxPourRéservation : ReservationFixtureBase
	{
		public VerifierTotauxPourRéservation () : base()
		{

			

		}
		public void DéfinirLesTauxDeTaxesAvecTPSEtTVQ(decimal tps,decimal TVQ)
		{
			netCalculationStrategy = new NetTotalCalculationStrategy(new[] { new Rate("TPS",tps), new Rate("TVQ", TVQ) });
		}
		public void AjouterRepresentationPourLaDateEtLaSalle(string spectacle, string date, string salle)
		{
			this.SetActiveShow (spectacle, date, salle);

            ShowPricingPolicy showPolicy;

            if (!showPricingPolicyRepository.TryGet(GetActiveShow().Id, out showPolicy))
            {
                showPolicy = new ShowPricingPolicy(new Dictionary<string, decimal>(), new Dictionary<string, decimal>(), GetActiveShow());
                showPricingPolicyRepository.Add(showPolicy);
            }
            if (!showPolicy.ApplicableFees.ContainsKey("Service"))
            {
                showPolicy.ApplicableFees.Add("Service", 4.00m);
                showPricingPolicyRepository.Update(showPolicy);
            }
		}

		public void AjouterClient(string any)
		{
			this.SetActiveCustomer (any);
		}
         public void AjouterSiegesAuPrixBrutDeEtAvecRabaisDePourLaCategorie(int nombre,decimal prix, decimal rabais, string categorie)
		{


			for (int i=1; i<=nombre; i++) {
				this.AddSeatToInventory (categorie+i.ToString (),rabais,categorie,prix);
				this.ReserveSeatWithCategory(categorie+i.ToString (), this.GetCurrentCustomer(), categorie);
			
			
			}
		}

       
		public void AjouterSiegesAuPrixBrutDePourLaCategorie(decimal nombre,decimal prix, string categorie)
		{

			for (int i=1; i<=nombre; i++) {
				this.AddSeatToInventory (categorie+i.ToString (),0.00m,categorie,prix);
				this.ReserveSeatWithCategory(categorie+i.ToString (), this.GetCurrentCustomer(), categorie);


			}
		}

		public void AjouterFraisAuPrixBrutDeTypeDeFrais(int nombre, decimal prix, string type)
		{
			if (type == "Service") {
                for (int i = 1; i <= nombre; i++)
                {
                    this.AddSeatToInventory(type + i.ToString(),0.00m, type, 0.00m);
                    this.ReserveSeatWithCategory(type + i.ToString(), this.GetCurrentCustomer(), type);
				}
			}
			else{
			for (int i = 1; i<=nombre; i++)
				this.InvoiceFee (prix);
			}
		}

		public decimal RecettesNettesBillets()
		{
			return invoicingService.GetInvoiceTotals (new Customer (this.GetCurrentCustomer ())).SeatReservationTotal.NetTotal;
		}

		public decimal RecettesBrutesBillets()
		{
			return	invoicingService.GetInvoiceTotals (new Customer (this.GetCurrentCustomer ())).SeatReservationTotal.GrossTotal;

			

		}

		public decimal TPSBillets()
		{
            return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer())).SeatReservationTotal.Taxes[0].Amount;
		}	

		public decimal TVQBillets()
		{
            return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer())).SeatReservationTotal.Taxes[1].Amount;
		}

		public decimal RecettesNettesAbonnes()
		{
            return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer()),"Abonnes").SeatReservationTotal.NetTotal;
		}
		public decimal RecettesBrutesAbonnes()
		{
            return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer()), "Abonnes").SeatReservationTotal.GrossTotal;
		}
		public decimal TPSAbonnes()
		{
            return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer()), "Abonnes").SeatReservationTotal.Taxes[0].Amount;
		}
		public decimal TVQAbonnes()
		{
            return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer()), "Abonnes").SeatReservationTotal.Taxes[1].Amount;
		}
		public decimal RecettesNettesReg()
		{
            return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer()), "Regulier").SeatReservationTotal.NetTotal;
		}
		public decimal RecettesBrutesReg()
		{
            return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer()), "Regulier").SeatReservationTotal.GrossTotal;
		}
		public decimal TPSReg()
		{
            return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer()), "Regulier").SeatReservationTotal.Taxes[0].Amount;
		}
		public decimal TVQReg()
		{
            return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer()), "Regulier").SeatReservationTotal.Taxes[1].Amount;
		}

		public decimal RecettesBrutesGratuit()
		{
			return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer()), "Gratuit").SeatReservationTotal.GrossTotal;
		}

		public decimal RecettesBrutesBancMort()
		{
			return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer()), "Banc Morts").SeatReservationTotal.GrossTotal;
		}

		public decimal RecettesNettesFraisService()
		{
            return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer()), "Service").SeatReservationFeesTotal.NetTotal;
		}
		public decimal RecettesBrutesFraisService()
		{
			return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer()),"Service").SeatReservationFeesTotal.GrossTotal;
		}
		public decimal TPSFraisService()
		{
            return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer()), "Service").SeatReservationFeesTotal.Taxes[0].Amount;
		}
		public decimal TVQFraisService()
		{
            return invoicingService.GetInvoiceTotals(new Customer(this.GetCurrentCustomer()), "Service").SeatReservationFeesTotal.Taxes[1].Amount;
		}
		public decimal RecettesNettesFraisPoste()
		{
			return invoicingService.GetInvoiceTotals (new Customer (this.GetCurrentCustomer ())).OtherFeesTotal.NetTotal;
		}
		public decimal RecettesBrutesFraisPoste()
		{
			return invoicingService.GetInvoiceTotals (new Customer (this.GetCurrentCustomer ())).OtherFeesTotal.GrossTotal;
		}
		public decimal TPSFraisPoste()
		{
			return invoicingService.GetInvoiceTotals (new Customer (this.GetCurrentCustomer ())).OtherFeesTotal.Taxes[0].Amount;
		}
		public decimal TVQFraisPoste()
		{
			return invoicingService.GetInvoiceTotals (new Customer (this.GetCurrentCustomer ())).OtherFeesTotal.Taxes[1].Amount;
		}

	}
}

