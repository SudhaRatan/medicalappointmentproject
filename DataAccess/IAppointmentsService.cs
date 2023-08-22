using HospitalAppointmentProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalAppointmentProject.DataAccess
{
    public interface IAppointmentsService
    {
        public DoctorDetail GetDoctorData(string? disease);
        public SelectList CreateListGet();
        public SelectList CreateList(Appointment appointment);
        public Task<List<Appointment>> GetAppointmentsAsync();
        public Task CreateAppointmentAsync(Appointment appointment);
        public Task<Appointment?> AppointmentDetailsAsync(int? id);
        public Task EditAppointmentAsync(Appointment appointment);
        public Task DeleteAppointmentAsync(Appointment? appointment);
    }
}
