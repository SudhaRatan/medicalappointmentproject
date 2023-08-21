using medicalappointmentproject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace medicalappointmentproject.DataAccess
{
    public interface IAppointmentsService
    {
        public Task<DoctorDetail> GetDoctorData(string? disease);
        public SelectList CreateList();
        public Task<List<Appointment>> GetAppointmentsAsync();
        public Task CreateAppointmentAsync(Appointment appointment);
        public Task<Appointment?> AppointmentDetailsAsync(int? id);
        public Task EditAppointmentAsync(Appointment appointment);
        public Task DeleteAppointmentAsync(Appointment? appointment);
    }
}
