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
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentsService _appointmentsService;

        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        // GET: Appointments

        public async  Task<IActionResult> GetData(IFormCollection data)
        {
            string disease = data["Disease"];
            DoctorDetail doctor = await _appointmentsService.GetDoctorData(disease);
            return Json(new { doctorname = doctor.DoctorName, timeslot = doctor.AvailableTime });
        }

        public async Task<IActionResult> Index()
        {
            return View(await _appointmentsService.GetAppointmentsAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentsService.AppointmentDetailsAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["MedicalIssue"] = _appointmentsService.CreateList();
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,PatientName,MedicalIssue,DoctorToVisit,DoctorAvalialbeTime,AppointmentTime")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                await _appointmentsService.CreateAppointmentAsync(appointment);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicalIssue"] = _appointmentsService.CreateList();
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentsService.AppointmentDetailsAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["MedicalIssue"] = _appointmentsService.CreateList();
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,PatientName,MedicalIssue,DoctorToVisit,DoctorAvalialbeTime,AppointmentTime")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appointmentsService.EditAppointmentAsync(appointment);
                }
                catch (DbUpdateConcurrencyException)
                {
                        return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicalIssue"] = _appointmentsService.CreateList();
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentsService.AppointmentDetailsAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var appointment = await _appointmentsService.AppointmentDetailsAsync(id);
            _appointmentsService.DeleteAppointmentAsync(appointment);
            return RedirectToAction(nameof(Index));
        }
    }
}
