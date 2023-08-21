using medicalappointmentproject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace medicalappointmentproject.DataAccess
{
    public interface IDiseasesDoctorDetailsService
    {
        public SelectList Create();
        public SelectList CreatePost(DiseasesDoctorDetail diseasesDoctorDetail);
        public Task<List<DiseasesDoctorDetail>> GetDiseasesDoctorDetailsAsync();
        public Task CreateDiseasesDoctorAsync(DiseasesDoctorDetail diseasesDoctorDetail);
        public Task<DiseasesDoctorDetail?> DiseasesDoctorDetailsAsync(string? id);
        public Task EditDiseasesDoctorAsync(DiseasesDoctorDetail diseasesDoctorDetail);
        public Task DeleteDiseasesDoctorAsync(DiseasesDoctorDetail? diseasesDoctorDetail);
    }
}
