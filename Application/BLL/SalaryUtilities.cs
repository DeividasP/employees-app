using System;

namespace Application.BLL
{

    public static class SalaryUtilities
    {

        private const int DefaultPrecision = 2;

        private const int MinimumSalary = 380;
        private const int TaxExemptIncomeBase = 310;

        private const decimal IncomeTax = 0.15m;
        private const decimal SocialSecurityTax = 0.03m;
        private const decimal HealthInsuranceTax = 0.06m;

        public static decimal ToGrossSalary(decimal netSalary)
        {
            decimal grossSalary = (netSalary <= DeductTaxes(MinimumSalary) + IncomeTax * TaxExemptIncomeBase)
                    ? (netSalary <= DeductInsuranceTaxes(TaxExemptIncomeBase))
                    ? netSalary / DeductInsuranceTaxes(1)
                    : (netSalary - IncomeTax * TaxExemptIncomeBase) / DeductTaxes(1)
                    : (netSalary <= (DeductInsuranceTaxes(1) - IncomeTax * 1.5m) * (1 / 0.5m * TaxExemptIncomeBase + MinimumSalary) + IncomeTax * (TaxExemptIncomeBase + 0.5m * MinimumSalary))
                    ? (1.5m * netSalary / DeductInsuranceTaxes(1) - TaxExemptIncomeBase - 0.5m * MinimumSalary <= 0)
                    ? netSalary / DeductInsuranceTaxes(1)
                    : (netSalary - IncomeTax * TaxExemptIncomeBase - IncomeTax * 0.5m * MinimumSalary) / (DeductInsuranceTaxes(1) - IncomeTax * 1.5m)
                    : (netSalary <= 0)
                    ? netSalary / DeductInsuranceTaxes(1)
                    : netSalary / DeductTaxes(1);

            return Math.Round(grossSalary, DefaultPrecision);
        }

        private static decimal DeductTaxes(decimal value)
        {
            return value * (1 - IncomeTax - SocialSecurityTax - HealthInsuranceTax);
        }

        private static decimal DeductInsuranceTaxes(decimal value)
        {
            return value * (1 - SocialSecurityTax - HealthInsuranceTax);
        }

    }

}