
using System;
using center.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using center.Data;
using center.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace center.Repository
{
    internal class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _context.Appointments
                //.Include(a => a.Treatment)
                //.Include(a => a.User)
                //.Include(a => a.patient)
                .ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _context.Appointments
                //.Include(a => a.Treatment)
                //.Include(a => a.User)
                //.Include(a => a.patient)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);
        }

        public async Task AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
