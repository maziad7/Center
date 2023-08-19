using center.Models;
using center.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace center.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly ITreatmentRepository _treatmentRepository;

        public TreatmentController(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var treatments = await _treatmentRepository.GetTreatments();
            return View(treatments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var treatments = await _treatmentRepository.GetTreatmentById(id);
            if (treatments == null)
            {
                return NotFound();
            }
            return View(treatments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Treatment treatment)
        {
            //if (ModelState.IsValid)
            try
            {
                await _treatmentRepository.AddTreatment(treatment);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(treatment);
            }
          
        }

        public async Task<IActionResult> Edit(int id)
        {
            var treatment = await _treatmentRepository.GetTreatmentById(id);
            if (treatment == null)
            {
                return NotFound();
            }
            return View(treatment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Treatment treatment)
        {
            if (id != treatment.TreatmentId)
            {
                return NotFound();
            }

           // if (ModelState.IsValid)
           try
            {
                await _treatmentRepository.UpdateTreatment(treatment);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(treatment);
            }
            
        }

        public async Task<IActionResult> Delete(int id)
        {
            var treatment = await _treatmentRepository.GetTreatmentById(id);
            if (treatment == null)
            {
                return NotFound();
            }
            return View(treatment);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _treatmentRepository.DeleteTreatment(id);
            return RedirectToAction("Index");
        }
    }
}
