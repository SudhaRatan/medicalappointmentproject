using medicalappointmentproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace medicalappointmentproject.DataAccess
{
    public class DoctorDetailsService : IDoctorDetailsService
    {
        //Creating an instance of database context

        private readonly MedicalprojectContext _context;

        public DoctorDetailsService(MedicalprojectContext context)
        {
            _context = context;
        }

        public async Task<List<DoctorDetail>> GetDoctorDetailsAsync()
        {
            //Getting a list of doctor details from the database 

            if (_context.DoctorDetails != null)
                return await _context.DoctorDetails.ToListAsync();
            return null;
        }

        public async Task CreateDoctorAsync(DoctorDetail doctorDetail)
        {
            //Adding a new doctor details record

            _context.Add(doctorDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<DoctorDetail?> DoctorDetailsAsync(int? id)
        {
            //Getting a single record of doctor details when passed DoctorId

            if (_context.DoctorDetails != null)
                return await _context.DoctorDetails.FirstOrDefaultAsync(m => m.DoctorId == id);
            return null;
        }

        public async Task EditDoctorAsync(DoctorDetail doctorDetail)
        {
            //Edit the Doctor record when the whole doctor object is passed

            _context.Update(doctorDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(DoctorDetail? doctorDetail)
        {
            //Delete the Doctor record when the whole doctor object is passed

            if (doctorDetail != null)
            {
                _context.DoctorDetails.Remove(doctorDetail);
            }

            await _context.SaveChangesAsync();
        }
    }
}