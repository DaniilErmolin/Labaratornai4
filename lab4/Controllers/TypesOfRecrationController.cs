using lab4.Data;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers
{
    public class TypesOfRecrationController : Controller
    {
        private TouristAgency1Context db;

        public TypesOfRecrationController(TouristAgency1Context context)
        {
            db = context;
        }

        [ResponseCache(CacheProfileName = "ModelCache")]
        public IActionResult ShowTable()
        {
            var additionalServices = db.TypesOfRecreations.ToList();
            return View(additionalServices);
        }
    }
}
