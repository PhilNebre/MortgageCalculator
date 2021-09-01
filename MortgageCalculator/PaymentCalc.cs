using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator
{
    class PaymentCalc : UserQuestions
    {


        public void Payment()
        {

            //Principle of Loan
            Principle = PurchasePrice + TaxesFees - DownPayment;

            //Origination Fee
            double originationFee = Principle * .01d;
            //Loan To Value
            LoanToValue = Principle + originationFee;


            //Mortgage Calculator
            double n = NumOfPayPerYr;
            double t = Term;
            double r = APR;

            double x = 1d + (r / n);
            double y = n * t;

            Mortgage = (LoanToValue * (r / n) * Math.Pow(x, y)) / (Math.Pow(x, y) - 1d);

            //Loan Insurance
            double DownPayPerc = DownPayment / LoanToValue * 100d;
            if (DownPayPerc <= 10)
                PMI = LoanToValue * .01d / 12d;


            //Escrow
            double propTax = PurchasePrice * 0.0125d;
            double homeownersIns = PurchasePrice * .0075d;
            double escrowYear = (propTax) + (homeownersIns);
            double escrowMonth = escrowYear / 12d;
            //Interest Rate

            double interest = APR * 100d;
            MonthlyPay = Mortgage + escrowMonth + PMI;

            //Monthly Mortgage Statement
            Console.WriteLine("Base Amount for the loan: ${0} at {1}% interest", Math.Round(LoanToValue, 2), interest);
            Console.WriteLine("Escrow Amount: ${0} \n   Homeowner's Insurance: ${1}/month\n   Property Tax: ${2}/Month", Math.Round(escrowMonth, 2), homeownersIns / 12d, Math.Round(propTax / 12d, 2));
            Console.WriteLine("Loan Insurance: ${0}/year\n\n", Math.Round(PMI, 2));
            Console.WriteLine("Monthly Payment Due: {0}", Math.Round(MonthlyPay, 2));
        }
        public void LoanValidation()
        {
            double monthlyIncome = AnnualIncome / 12d;

            double debtToIncome;
            debtToIncome = MonthlyPay / monthlyIncome;
            if (debtToIncome >= .25d)
            {
                Console.Write("The loan is not approved.  Monthly payment of ${0} is greater than or equal to 25% of the applicant's monthly income of ${1}.", Math.Round(MonthlyPay, 2), Math.Round(monthlyIncome, 2));
            }
            else
            {
                Console.Write("The loan is approved.");
            }
        }
    }
}
