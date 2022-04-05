using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SavingBankAccount : BankAccount
    {
        public static new int Total = 0;
        public SavingBankAccount(decimal openingBalance = 500)
            : base(AccountType.Saving, openingBalance)
        {
            Total = Total + 1;
        }

        public override bool WithDraw(decimal amount)
        {
            //TODO: Add your code here
            decimal tax = 0;
            if (amount > 50000)
            {
                tax = 0.06M * amount;
            }

            amount = amount - tax;

            return base.WithDraw(amount);
        }
    }
}
