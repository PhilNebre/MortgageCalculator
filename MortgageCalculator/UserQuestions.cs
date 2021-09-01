using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator
{
    class UserQuestions : UserInput
    {
        public void UserPrompt()
        {
            
            Console.Clear();

            //Prompts for Owner information
            Console.Write("Enter the following information for loan approval: \n");

            Console.Write("\nEnter Purchase Price: ");
            PurchasePrice = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nEnter Down Payment: ");
            DownPayment = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nEnter Taxes and Fees: ");
            TaxesFees = Convert.ToDouble(Console.ReadLine());

            //Info for Debt to Income
            Console.Write("\nEnter Annual Income: ");
            AnnualIncome = Convert.ToDouble(Console.ReadLine());

            CreditScore:
            Console.Write("\nA- 760-800 \nB- 700-759 \nC- 680-699 \nD- 660-679 \nE- 640-659 \nF- 620-639 \nG- 619 or Below \n\nEnter number corresponding to credit score: ");
            CreditScore = Console.ReadLine().ToUpper();

            switch (CreditScore)
            {
                case "A":
                    APR = 0.02505d;
                    break;
                case "B":
                    APR = .02727d;
                    break;
                case "C":
                    APR = .02904d;
                    break;
                case "D":
                    APR = .03118d;
                    break;
                case "E":
                    APR = .03548d;
                    break;
                case "F":
                    APR = .04094d;
                    break;
                case "G":
                    DoesNotQualify();
                    break;
                default:
                    goto CreditScore;

            }

            LoanType:
            Console.Write("\nA- 30-year fixed \nB- 15-year fixed \n\nType of loan: ");
            string inputType = Console.ReadLine().ToUpper();

            switch (inputType)
            {
                case "A":
                    Term = 30d;
                    break;
                case "B":
                    Term = 15d;
                    break;
                default:
                    goto LoanType;
            }

            Console.Write("\nHow many payments per year: ");
            NumOfPayPerYr = Convert.ToDouble(Console.ReadLine());

        }
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
