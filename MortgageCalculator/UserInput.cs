using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator
{
    class UserInput
    {

        //private double _purchasePrice;
        //private double _downPayment;
        //private double _taxesFees;
        //private double _annualIncome;
        //private string _creditScore;
        //private double _principle;

        ////Total Asset:
        //private double _checking;
        //private double _saving;

        ////Terms of the loan
        //private double _numOfPayPerYr;
        //private double _term;
        //private double _aPR;
        //private double _loanToValue;
        //private double _pMI;
        //private double _mortgage;
        //private double _monthlyPay;

        public double PurchasePrice { get; set; }
        //{
        //    get { return this._purchasePrice; }
        //    set { this._purchasePrice = value; }
        //}

        public double DownPayment { get; set; }
        //{
        //    get { return this._downPayment; }
        //    set { this._downPayment = value; }
        //}

        public double AnnualIncome { get; set; }
        //{
        //    get { return this._annualIncome; }
        //    set { this._annualIncome = value; }
        //}

        public string CreditScore { get; set; }
        //{
        //    get { return this._creditScore; }
        //    set { this._creditScore = value; }
        //}



        public double TaxesFees { get; set; }
        //{
        //    get { return this._taxesFees; }
        //    set { this._taxesFees = value; }
        //}

        public double Principle { get; set; }
        //{
        //    get { return this._principle; }
        //    set { this._principle = value; }
        //}

        public double NumOfPayPerYr { get; set; }
        //{
        //    get { return this._numOfPayPerYr; }
        //    set { this._numOfPayPerYr = value; }
        //}

        public double Term { get; set; }
        //{
        //    get { return this._term; }
        //    set { this._term = value; }
        //}

        
        public double APR { get; set; }
        //{
        //    get { return this._aPR; }
        //    set { this._aPR = value; }
        //}

        public double LoanToValue { get; set; } 
        //{
        //    get { return this._loanToValue; }
        //    set { this._loanToValue=value; }
        //}

        public double Mortgage { get; set; }
        //{
        //    get { return this._mortgage; }
        //    set { this._mortgage = value; }
        //}

        public double PMI { get; set; }
        //{
        //    get { return this._pMI; }
        //    set { this._pMI=value; }
        //}

        public double MonthlyPay { get; set; }
        //{
        //    get { return this._monthlyPay; }
        //    set { this._monthlyPay = value; }
        //}
        public void DoesNotQualify()
        {
            Console.WriteLine("A credit score of {0} is too low. Applicant does not qualify.", CreditScore);
        }
    }
}
