﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Store
    {
        // member variables (HAS A)
        private double pricePerLemon;
        public double PricePerLemon
        {
            get { return pricePerLemon; }
        }
        private double pricePerSugarCube;
        public double PricePerSugarCube
        {
            get { return pricePerSugarCube; }
        }
        private double pricePerIceCube;
        public double PricePerIceCube
        {
            get { return pricePerIceCube; }
        }
        private double pricePerCup;
        public double PricePerCup
        {
            get { return pricePerCup; }
        }

        // constructor (SPAWNER)
        public Store()
        {
            pricePerLemon = .5;
            pricePerSugarCube = .1;
            pricePerIceCube = .01;
            pricePerCup = .25;
        }

        // member methods (CAN DO)
        public void SellLemons(Player player)
        {
            int lemonsToPurchase = UserInterface.GetNumberOfItems("lemons");
            double transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
            if(player.Wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.Wallet, transactionAmount);
                player.Inventory.AddLemonsToInventory(lemonsToPurchase);
            }
        }

        public void SellSugarCubes(Player player)
        {
            int sugarToPurchase = UserInterface.GetNumberOfItems("sugar");
            double transactionAmount = CalculateTransactionAmount(sugarToPurchase, pricePerSugarCube);
            if(player.Wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.Wallet, transactionAmount);
                player.Inventory.AddSugarCubesToInventory(sugarToPurchase);
            }
        }

        public void SellIceCubes(Player player)
        {
            int iceCubesToPurchase = UserInterface.GetNumberOfItems("ice cubes");
            double transactionAmount = CalculateTransactionAmount(iceCubesToPurchase, pricePerIceCube);
            if(player.Wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.Wallet, transactionAmount);
                player.Inventory.AddIceCubesToInventory(iceCubesToPurchase);
            }
        }

        public void SellCups(Player player)
        {
            int cupsToPurchase = UserInterface.GetNumberOfItems("cups");
            double transactionAmount = CalculateTransactionAmount(cupsToPurchase, pricePerCup);
            if(player.Wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.Wallet, transactionAmount);
                player.Inventory.AddCupsToInventory(cupsToPurchase);
            }
        }

        private double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            return transactionAmount;
        }

        private void PerformTransaction(Wallet wallet, double transactionAmount)
        {
            wallet.PayMoneyForItems(transactionAmount);
        }
    }
}
