using medicalappointmentproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace medicalappointmentproject.DataAccess
{
    public interface IDoctorDetailsService
    {
        public Task<List<DoctorDetail>> GetDoctorDetailsAsync();
        public Task CreateDoctorAsync(DoctorDetail doctorDetail);
        public Task<DoctorDetail?> DoctorDetailsAsync(int? id);
        public Task EditDoctorAsync(DoctorDetail doctorDetail);
        public Task DeleteDoctorAsync(DoctorDetail? doctorDetail);
    }
}
