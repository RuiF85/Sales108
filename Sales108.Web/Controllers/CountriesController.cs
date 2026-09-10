using Microsoft.AspNetCore.Mvc;
using Sales108.Web.Data;
using Sales108.Web.Data.Entities;

namespace Sales108.Web.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IActionResult Index()
        {
            return View(_countryRepository.GetAll());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _countryRepository.GetByIdAsync(id.Value);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Country country)
        {
            if (ModelState.IsValid)
            {
                var countries = _countryRepository.GetAll();

                if(countries.Any(c => c.Name == country.Name))
                {
                    ModelState.AddModelError("Name", "A country with the same name already exists.");
                    return View(country);
                }
                await _countryRepository.CreateAsync(country);
                return RedirectToAction(nameof(Index));
            }

            return View(country);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _countryRepository.GetByIdAsync(id.Value);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var countries = _countryRepository.GetAll();

                if(countries.Any(c => c.Name == country.Name && c.Id != country.Id))
                {
                    ModelState.AddModelError("Name", "A country with the same name already exists.");
                    return View(country);
                }
                await _countryRepository.UpdateAsync(country);
                return RedirectToAction(nameof(Index));
            }

            return View(country);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _countryRepository.GetByIdAsync(id.Value);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);

            if (country != null)
            {
                await _countryRepository.DeleteAsync(country);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
