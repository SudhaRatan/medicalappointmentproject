using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using medicalappointmentproject.Models;
using medicalappointmentproject.DataAccess;

namespace medicalappointmentproject.Controllers
{
    public class DoctorDetailsController : Controller
    {
        private readonly IDoctorDetailsService _doctorDetails;

        public DoctorDetailsController(IDoctorDetailsService doctorDetails)
        {
            _doctorDetails = doctorDetails;
        }

        // GET: DoctorDetails
        public async Task<IActionResult> Index()
        {
            List<DoctorDetail> doctorDetailsList = await _doctorDetails.GetDoctorDetailsAsync();
            if (doctorDetailsList != null)
                return View(doctorDetailsList);
            return NotFound();
        }

        // GET: DoctorDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DoctorDetail doctorDetail = await _doctorDetails.DoctorDetailsAsync(id);
            if (doctorDetail == null)
            {
                return NotFound();
            }

            return View(doctorDetail);
        }

        // GET: DoctorDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorId,DoctorName,Specialisation,AvailableTime,DoctorFee")] DoctorDetail doctorDetail)
        {
            if (ModelState.IsValid)
            {
                await _doctorDetails.CreateDoctorAsync(doctorDetail);
                return RedirectToAction(nameof(Index));
            }
            return View(doctorDetail);
        }


        // GET: DoctorDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorDetail = await _doctorDetails.DoctorDetailsAsync(id);
            if (doctorDetail == null)
            {
                return NotFound();
            }
            return View(doctorDetail);
        }

        // POST: DoctorDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorId,DoctorName,Specialisation,AvailableTime,DoctorFee")] DoctorDetail doctorDetail)
        {
            if (id != doctorDetail.DoctorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _doctorDetails.EditDoctorAsync(doctorDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(doctorDetail);
        }


        // GET: DoctorDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorDetail = await _doctorDetails.DoctorDetailsAsync(id);
            if (doctorDetail == null)
            {
                return NotFound();
            }

            return View(doctorDetail);
        }

        // POST: DoctorDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorDetail = await _doctorDetails.DoctorDetailsAsync(id);
            await _doctorDetails.DeleteDoctorAsync(doctorDetail);
            return RedirectToAction(nameof(Index));
        }

    }
}
