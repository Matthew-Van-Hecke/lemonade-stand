using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Wallet
    {
        private double money;
        public double Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }
        private double totalExpenses;
        public double TotalExpenses
        {
            get { return totalExpenses; }
        }
        private double totalIncome;
        public double TotalIncome
        {
            get { return totalIncome; }
        }

        public Wallet()
        {
            money = 20.00;
        }

        public void PayMoneyForItems(double transactionAmount)
        {
            money -= transactionAmount;
        }
        public void UpdateTotalExpenses(double expenses)
        {
            totalExpenses -= expenses;
        }
        public void UpdateTotalIncome(double income)
        {
            totalIncome += income;
        }
    }
}
