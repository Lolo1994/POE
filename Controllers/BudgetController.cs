using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_2.Data;
using Task_2.Models;

namespace Task_2.Controllers
{
    public class BudgetController : Controller
    {
        private readonly ApplicationDbContext _context;

        List<GoodsAllocation> goodsAlllo = new List<GoodsAllocation>();
        List<DiasterAllocation> disasterAllo = new List<DiasterAllocation>();
        List<DisasterType> disasterTypes = new List<DisasterType>();
        BudgetAllocation budgets = new BudgetAllocation();
        List<BudgetAllocation> budgetsList; 
        List<double> disasterTypesTotal = new List<double>();
        List<double> goodsTotalAllocation = new List<double>();
        List<double> remainingBudget = new List<double>();

        public BudgetController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {

            budgetsList = new List<BudgetAllocation>();
            disasterAllo = _context.DiasterAllocation.ToList();
            goodsAlllo = _context.GoodsAllocation.ToList();
            disasterTypes = _context.DisasterType.ToList();

            double allotedMoney = 0;
            double allotedGoodsMoney = 0;
            double budgetRemaining = 0;

            for (int x = 0; x <= disasterTypes.Count-1; x++)
            {
                string disaster = disasterTypes[x].disasterType;
                

                for (int y = 0; y <= disasterAllo.Count-1; y++)
                {
                    if (disasterAllo[y].disasterType.Equals(disaster))
                    {
                        allotedMoney += disasterAllo[y].amountAllotted;
                    }
                }
          
                for (int y = 0; y <= goodsAlllo.Count-1; y++)
                {
                    if (goodsAlllo[y].disasterType.Equals(disaster))
                    {
                        allotedGoodsMoney += (goodsAlllo[y].pricePerItem * goodsAlllo[y].quantity);
                    }
                }

                budgets = new BudgetAllocation();
                budgetRemaining = allotedMoney - allotedGoodsMoney;
                budgets.ID = x;
                budgets.disaterType = disaster;
                budgets.disasterBudget = allotedMoney;
                budgets.totalGoodsPurchase = allotedGoodsMoney;
                budgets.budgetRemaining = budgetRemaining;

                budgetsList.Add(budgets);


                
                allotedMoney = 0;
                allotedGoodsMoney = 0;
                budgetRemaining = 0;
                disaster = "";

            }

            return View(budgetsList);
        }
    }
}
