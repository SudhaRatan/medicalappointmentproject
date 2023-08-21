using medicalappointmentproject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace medicalappointmentproject.DataAccess
{
    public class AppointmentsService : IAppointmentsService
    {
        //Creating an instance of database context

        private readonly MedicalprojectContext _context;
        public AppointmentsService(MedicalprojectContext context)
        {
            _context = context;
        }
        public async Task<Appointment?> AppointmentDetailsAsync(int? id)
        {
            //Checking appointments context exists

            if (_context.Appointments != null)

                //Returning Appointment details

                return await _context.Appointments
                     .Include(a => a.MedicalIssueNavigation)
                     .FirstOrDefaultAsync(m => m.AppointmentId == id);
            return null;
        }

        public SelectList CreateList(Appointment appointment)
        {
            //Fetching Diseases names and Returning a drop down list

            return new SelectList(_context.DiseasesDoctorDetails, "DiseasesName", "DiseasesName", appointment.MedicalIssue);
        }

        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            //Adding an Appointment

            _context.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(Appointment? appointment)
        {
            if (appointment != null)
            {
                //Removing an appointment if the appointment modal passed is not null

                _context.Appointments.Remove(appointment);
            }

            //Committing to the database

            await _context.SaveChangesAsync();
        }

        public async Task EditAppointmentAsync(Appointment appointment)
        {
            //Updating the Appointment

            _context.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsAsync()
        {
            if (_context.Appointments != null)
            {
                //Getting a list of appointments from the database if the appointments context is not null

                var AppointDetails = await _context.Appointments.Include(a => a.MedicalIssueNavigation).ToListAsync();
                return AppointDetails;
            }
            return null;
        }

        public DoctorDetail GetDoctorData(string? disease)
        {
            //Executing Stored procedure which takes disease name as input and results in Doctor modal which maps to the disease id

            SqlParameter param = new SqlParameter("@DiseaseName", disease);
            DoctorDetail doctor = _context.Set<DoctorDetail>().FromSqlRaw("exec getData1 @DiseaseName", param).AsEnumerable().FirstOrDefault();
            return doctor;
        }

        public SelectList CreateListGet()
        {
            return new SelectList(_context.DiseasesDoctorDetails, "DiseasesName", "DiseasesName");

        }
    }
}
