using medicalappointmentproject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace medicalappointmentproject.DataAccess
{
    public class AppointmentsService : IAppointmentsService
    {

        private readonly MedicalprojectContext _context;
        public AppointmentsService(MedicalprojectContext context)
        {
            _context = context;
        }
        public async Task<Appointment?> AppointmentDetailsAsync(int? id)
        {
            if (_context.Appointments != null)
                return await _context.Appointments
                     .Include(a => a.MedicalIssueNavigation)
                     .FirstOrDefaultAsync(m => m.AppointmentId == id);
            return null;
        }

        public SelectList CreateList()
        {
            return new SelectList(_context.DiseasesDoctorDetails, "DiseasesName", "DiseasesName");
        }

        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            _context.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(Appointment? appointment)
        {
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            await _context.SaveChangesAsync();
        }

        public async Task EditAppointmentAsync(Appointment appointment)
        {
            _context.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsAsync()
        {
            if (_context.Appointments != null)
            {
                var AppointDetails = await _context.Appointments.Include(a => a.MedicalIssueNavigation).ToListAsync();
                return AppointDetails;
            }
            return null;
        }

        public async Task<DoctorDetail> GetDoctorData(string disease)
        {
            //int doctorid = Convert.ToInt32(_context.DiseasesDoctorDetails.FirstOrDefault(d => d.DiseasesName == disease).SuitableDoctorId);
            //DoctorDetail doctor = _context.DoctorDetails.FirstOrDefault(d => d.DoctorId == doctorid);

            SqlParameter param = new SqlParameter("@DiseaseName",disease);
            DoctorDetail doctor = _context.Set<DoctorDetail>().FromSqlRaw("exec getData1 @DiseaseName", param).AsEnumerable().FirstOrDefault();

            return doctor;
        }
    }
}
