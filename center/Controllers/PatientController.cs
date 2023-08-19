using center.Models;
using center.Repository;
using Microsoft.AspNetCore.Mvc;

namespace center.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IActionResult> Index()
        {
            var patients = await _patientRepository.GetPatients();
            return View(patients);
        }

        public async Task<IActionResult> Details(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            //if (ModelState.IsValid)
            try
            {
                await _patientRepository.AddPatient(patient);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View(patient);
            }
           
        }

        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Patient patient)
        {
            if (id != patient.PatientId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            try
            {
                await _patientRepository.UpdatePatient(patient);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(patient);
            }
            
        }

        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _patientRepository.DeletePatient(id);
            return RedirectToAction("Index");
        }
    }
}
