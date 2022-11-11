using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task_2.Data;
using Task_2.Models;
using System.Dynamic;

namespace Task_2.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;
        List<Report> totalMoneyDonations = new List<Report>();
        List<MoneyDonations> moneyDonations = new List<MoneyDonations>();
        List<GoodsDonations> goodsDonations = new List<GoodsDonations>();
        List<ActiveDisasters> activeDisasters = new List<ActiveDisasters>();

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {

            moneyDonations = _context.MoneyDonations.ToList();
            goodsDonations = _context.GoodsDonations.ToList();
            activeDisasters = _context.ActiveDisasters.ToList();

          

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

            List<GoodsDonations> gd = new List<GoodsDonations>();
            List<MoneyDonations> md = new List<MoneyDonations>();

            for (int x = 0; x <= activeDisasters.Count - 1; x++)
            {
                string activeD = activeDisasters[x].DisasterType;

                for (int y = 0; y <= goodsDonations.Count - 1; y++)
                {
                    if (goodsDonations[y].disasteType.Equals(activeD))
                    {
                        GoodsDonations gdItem = new GoodsDonations();
                        gdItem = goodsDonations[y];
                        gd.Add(gdItem);
                    }
                }
                for (int z = 0; z <= moneyDonations.Count - 1; z++)
                {
                    if (moneyDonations[z].disasteType.Equals(activeD))
                    {
                        MoneyDonations mdItem = new MoneyDonations();
                        mdItem = moneyDonations[z];
                        md.Add(mdItem);
                    }
                }
            
            }


            dynamic mymodal = new ExpandoObject();
            mymodal.Report = totalMoneyDonations;
            mymodal.MoneyDonations = md;
            mymodal.GoodsDonations = gd;

            return View(mymodal);
        }

       
    }
}
