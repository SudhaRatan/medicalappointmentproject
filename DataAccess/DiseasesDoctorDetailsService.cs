using medicalappointmentproject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace medicalappointmentproject.DataAccess
{
    public class DiseasesDoctorDetailsService : IDiseasesDoctorDetailsService
    {
        private readonly MedicalprojectContext _context;

        public DiseasesDoctorDetailsService(MedicalprojectContext context)
        {
            _context = context;
        }
        public async Task<List<DiseasesDoctorDetail>> GetDiseasesDoctorDetailsAsync()
        {
            var ddd = await _context.DiseasesDoctorDetails.Include(d => d.SuitableDoctor).ToListAsync();
            return ddd;
        }

        public async Task CreateDiseasesDoctorAsync(DiseasesDoctorDetail diseasesDoctorDetail)
        {
            _context.Add(diseasesDoctorDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDiseasesDoctorAsync(DiseasesDoctorDetail? diseasesDoctorDetail)
        {
            if (diseasesDoctorDetail != null)
            {
                _context.DiseasesDoctorDetails.Remove(diseasesDoctorDetail);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<DiseasesDoctorDetail?> DiseasesDoctorDetailsAsync(string? id)
        {
            return await _context.DiseasesDoctorDetails
                .Include(d => d.SuitableDoctor)
                .FirstOrDefaultAsync(m => m.DiseasesName == id);
        }


        public async Task EditDiseasesDoctorAsync(DiseasesDoctorDetail diseasesDoctorDetail)
        {
            _context.Update(diseasesDoctorDetail);
            await _context.SaveChangesAsync();
        }

        public SelectList Create()
        {
            return new SelectList(_context.DoctorDetails, "DoctorId", "DoctorId");
        }

        public SelectList CreatePost(DiseasesDoctorDetail diseasesDoctorDetail)
        {
            return new SelectList(_context.DoctorDetails, "DoctorId", "DoctorId", diseasesDoctorDetail.SuitableDoctorId);
        }
    }
}
