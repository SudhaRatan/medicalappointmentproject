using medicalappointmentproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace medicalappointmentproject.DataAccess
{
    public class DoctorDetailsService : IDoctorDetailsService
    {
        private readonly MedicalprojectContext _context;

        public DoctorDetailsService(MedicalprojectContext context)
        {
            _context = context;
        }

        public async Task<List<DoctorDetail>> GetDoctorDetailsAsync()
        {
            if (_context.DoctorDetails != null)
                return await _context.DoctorDetails.ToListAsync();
            return null;
        }

        public async Task CreateDoctorAsync(DoctorDetail doctorDetail)
        {
            _context.Add(doctorDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<DoctorDetail?> DoctorDetailsAsync(int? id)
        {
            if (_context.DoctorDetails != null)
                return await _context.DoctorDetails.FirstOrDefaultAsync(m => m.DoctorId == id);
            return null;
        }

        public async Task EditDoctorAsync(DoctorDetail doctorDetail)
        {
            _context.Update(doctorDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(DoctorDetail? doctorDetail)
        {
            if (doctorDetail != null)
            {
                _context.DoctorDetails.Remove(doctorDetail);
            }

            await _context.SaveChangesAsync();
        }
    }
}