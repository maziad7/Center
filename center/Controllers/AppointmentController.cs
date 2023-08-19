using center.Models;
using center.RepositoryInterface;
using center.Repository;
using Microsoft.AspNetCore.Mvc;
using center.ViewModels;
using Microsoft.EntityFrameworkCore;
using center.Data;
using Microsoft.AspNetCore.Identity;

namespace center.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public AppointmentController(IAppointmentRepository appointmentRepository, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _appointmentRepository = appointmentRepository;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await _appointmentRepository.GetAppointments();
            return View(appointments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        public IActionResult Create()
        {
            var model = new AppointmentUserViewModel
            {
                Treatments = _context.Treatments.ToList(),
                Users=_userManager.Users.ToList() ,
                patients = _context.Patients.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentUserViewModel viewModel)
        {
            //if (ModelState.IsValid)
            try
            {
                var appointment = new Appointment
                {
                    SessionTime = viewModel.SessionTime,
                    paid_amount=viewModel.paid_amount,
                    UserId = viewModel.UserId,
                    TreatmentId = viewModel.TreatmentId,
                    PatientId = viewModel.PatientId
                };
                await _appointmentRepository.AddAppointment(appointment);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            AppointmentUserViewModel viewModel = new AppointmentUserViewModel
            {
                AppointmentId = id,
                SessionTime = appointment.SessionTime,
                paid_amount = appointment.paid_amount,
                UserId = appointment.UserId,
                Users = _userManager.Users.ToList(),
                patients = _context.Patients.ToList(),
                PatientId = appointment.PatientId,
                TreatmentId = appointment.TreatmentId,
                Treatments = _context.Treatments.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AppointmentUserViewModel viewModel)
        {
            if (id != viewModel.AppointmentId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            try
            {
                var appointment = new Appointment
                {
                    AppointmentId = viewModel.AppointmentId,
                    PatientId= viewModel.PatientId,
                    SessionTime = viewModel.SessionTime,
                    TreatmentId =viewModel.TreatmentId,
                    paid_amount = viewModel.paid_amount,
                    UserId = viewModel.UserId
                };
                await _appointmentRepository.UpdateAppointment(appointment);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
           
        }

        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _appointmentRepository.DeleteAppointment(id);
            return RedirectToAction("Index");
        }

    }
}
