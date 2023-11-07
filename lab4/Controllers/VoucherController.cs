using lab4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab4.Controllers
{
    public class VoucherController : Controller
    {
        private TouristAgency1Context db;

        public VoucherController(TouristAgency1Context context)
        {
            db = context;
        }

        [ResponseCache(CacheProfileName = "ModelCache")]
        public IActionResult ShowTable()
        {
            var vouchers = db.Vouchers
                .Include(ia => ia.Client)
                .Include(ia => ia.TypeOfRecreation)
                .ToList();
            return View(vouchers);
        }
    }
}
