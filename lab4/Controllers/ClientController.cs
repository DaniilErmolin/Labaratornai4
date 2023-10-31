using lab4.Data;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers
{
    public class ClientController : Controller
    {
        private TouristAgency1Context db;

        public ClientController(TouristAgency1Context context)
        {
            db = context;
        }

        [ResponseCache(CacheProfileName = "ModelCache")]
        public IActionResult ShowTable()
        {
            var clients = db.Clients.ToList();
            return View(clients);
        }
    }
}
