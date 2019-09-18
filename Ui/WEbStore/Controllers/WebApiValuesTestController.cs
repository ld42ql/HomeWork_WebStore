using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebStore.Interfaces.Api;

namespace WebStore.Controllers
{
    public class WebApiValuesTestController : Controller
    {
        private readonly IValuesService _Values;

        public WebApiValuesTestController(IValuesService Values) => _Values = Values;

        public async Task<IActionResult> Index()
        {
            var values = await _Values.GetAsync();

            return View(values);
        }
    }
}