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
    public class DiseasesDoctorDetailsController : Controller
    {
        private readonly IDiseasesDoctorDetailsService _diseasesDoctorDetailsService;

        public DiseasesDoctorDetailsController(IDiseasesDoctorDetailsService diseasesDoctorDetailsService)
        {
            _diseasesDoctorDetailsService = diseasesDoctorDetailsService;
        }

        // GET: DiseasesDoctorDetails
        public async Task<IActionResult> Index()
        {
            return View(await _diseasesDoctorDetailsService.GetDiseasesDoctorDetailsAsync());
        }

        // GET: DiseasesDoctorDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiseasesDoctorDetail? diseasesDoctorDetail = await _diseasesDoctorDetailsService.DiseasesDoctorDetailsAsync(id);
            if (diseasesDoctorDetail == null)
            {
                return NotFound();
            }

            return View(diseasesDoctorDetail);
        }



        // GET: DiseasesDoctorDetails/Create
        public IActionResult Create()
        {
            ViewData["SuitableDoctorId"] = _diseasesDoctorDetailsService.Create();
            return View();
        }

        // POST: DiseasesDoctorDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiseasesId,DiseasesName,SuitableDoctorId")] DiseasesDoctorDetail diseasesDoctorDetail)
        {
            if (ModelState.IsValid)
            {
                _diseasesDoctorDetailsService.CreateDiseasesDoctorAsync(diseasesDoctorDetail);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SuitableDoctorId"] = _diseasesDoctorDetailsService.CreatePost(diseasesDoctorDetail);
            return View(diseasesDoctorDetail);
        }

        // GET: DiseasesDoctorDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseasesDoctorDetail = await _diseasesDoctorDetailsService.DiseasesDoctorDetailsAsync(id);
            if (diseasesDoctorDetail == null)
            {
                return NotFound();
            }
            ViewData["SuitableDoctorId"] = _diseasesDoctorDetailsService.CreatePost(diseasesDoctorDetail);
            return View(diseasesDoctorDetail);
        }

        // POST: DiseasesDoctorDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("DiseasesId,DiseasesName,SuitableDoctorId")] DiseasesDoctorDetail diseasesDoctorDetail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _diseasesDoctorDetailsService.EditDiseasesDoctorAsync(diseasesDoctorDetail);
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SuitableDoctorId"] = _diseasesDoctorDetailsService.CreatePost(diseasesDoctorDetail);
            return View(diseasesDoctorDetail);
        }

        // GET: DiseasesDoctorDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseasesDoctorDetail = await _diseasesDoctorDetailsService.DiseasesDoctorDetailsAsync(id);
            if (diseasesDoctorDetail == null)
            {
                return NotFound();
            }

            return View(diseasesDoctorDetail);
        }

        // POST: DiseasesDoctorDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var diseasesDoctorDetail = await _diseasesDoctorDetailsService.DiseasesDoctorDetailsAsync(id);
            await _diseasesDoctorDetailsService.DeleteDiseasesDoctorAsync(diseasesDoctorDetail);
            return RedirectToAction(nameof(Index));
        }
    }
}
