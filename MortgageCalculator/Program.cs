using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            UserQuestions one = new UserQuestions();
            one.UserPrompt();
            one.Payment();
            one.LoanValidation();

            //PaymentCalc two = new PaymentCalc();
            //two.Payment();
            //two.LoanValidation();

            Console.ReadLine();

        }




        
        
        
    }
}
