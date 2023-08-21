using medicalappointmentproject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace medicalappointmentproject.DataAccess
{
    public class DiseasesDoctorDetailsService : IDiseasesDoctorDetailsService
    {
        //Creating an instance of database context

        private readonly MedicalprojectContext _context;

        public DiseasesDoctorDetailsService(MedicalprojectContext context)
        {
            _context = context;
        }
        public async Task<List<DiseasesDoctorDetail>> GetDiseasesDoctorDetailsAsync()
        {
            //Getting a list of diseases mapped to doctors from the database 

            var ddd = await _context.DiseasesDoctorDetails.Include(d => d.SuitableDoctor).ToListAsync();
            return ddd;
        }

        public async Task CreateDiseasesDoctorAsync(DiseasesDoctorDetail diseasesDoctorDetail)
        {
            //Adding a new disease mapped with doctor

            _context.Add(diseasesDoctorDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDiseasesDoctorAsync(DiseasesDoctorDetail? diseasesDoctorDetail)
        {

            if (diseasesDoctorDetail != null) 
            {
                //Removing a disease entry if the object passed is not null

                _context.DiseasesDoctorDetails.Remove(diseasesDoctorDetail);
            }

            //Commiting to the database

            await _context.SaveChangesAsync();
        }

        public async Task<DiseasesDoctorDetail?> DiseasesDoctorDetailsAsync(string? id)
        {
            //Getting details of diseases mapped with doctors when the name of the disease is passed

            return await _context.DiseasesDoctorDetails
                .Include(d => d.SuitableDoctor)
                .FirstOrDefaultAsync(m => m.DiseasesName == id);
        }


        public async Task EditDiseasesDoctorAsync(DiseasesDoctorDetail diseasesDoctorDetail)
        {
            //Updating disease details

            _context.Update(diseasesDoctorDetail);
            await _context.SaveChangesAsync();
        }

        public SelectList Create()
        {
            //Fetching Doctor details and Returning a drop down list

            return new SelectList(_context.DoctorDetails, "DoctorId", "DoctorId");
        }

        public SelectList CreatePost(DiseasesDoctorDetail diseasesDoctorDetail)
        {
            return new SelectList(_context.DoctorDetails, "DoctorId", "DoctorId", diseasesDoctorDetail.SuitableDoctorId);
        }
    }
}
