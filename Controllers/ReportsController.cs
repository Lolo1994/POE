using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task_2.Data;
using Task_2.Models;

namespace Task_2.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;
        List<Report> totalMoneyDonations = new List<Report>();
        List<MoneyDonations> moneyDonations = new List<MoneyDonations>();
        List<GoodsDonations> goodsDonations = new List<GoodsDonations>();

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {

            moneyDonations = _context.MoneyDonations.ToList();
            goodsDonations = _context.GoodsDonations.ToList();

            Report rep;
            double donation = 0;
            int numGoods = 0;
            for (int x = 0; x <= moneyDonations.Count - 1; x++)
            {

                donation += moneyDonations[x].donationAmount;
            }

            for (int y = 0; y <= goodsDonations.Count - 1; y++)
            {
                numGoods += goodsDonations[y].itemNumber;
            }

            rep = new Report();
            rep.id = 1;
            rep.totalMonetaryDonationsReceived = donation;
            rep.totalNumberOfGoodsReceived = numGoods;
            totalMoneyDonations.Add(rep);

            return View(totalMoneyDonations);
        }

       
    }
}
