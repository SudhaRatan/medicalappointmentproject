using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace medicalappointmentproject.Models;

public partial class Appointment
{
    [Required]
    public int AppointmentId { get; set; }

    [Required]
    [DisplayName("Patient Name")]
    public string PatientName { get; set; } = null!;

    [DisplayName("Medical Issue")]
    [Required]
    public string? MedicalIssue { get; set; }

    [DisplayName("Doctor To Visit")]
    [Required]
    public string? DoctorToVisit { get; set; }
    [DisplayName("Doctor Available Time")]
    [Required]
    public string? DoctorAvalialbeTime { get; set; }

    [DisplayName("Appointment Time")]
    [Required]
    public DateTime? AppointmentTime { get; set; }
    [DisplayName("Medical Issue")]
    [Required]
    public virtual DiseasesDoctorDetail? MedicalIssueNavigation { get; set; }
}
