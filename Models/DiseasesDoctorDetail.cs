using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace medicalappointmentproject.Models;

public partial class DiseasesDoctorDetail
{
    [Required]
    public int DiseasesId { get; set; }

    [Required]
    public string DiseasesName { get; set; } = null!;

    [Required]
    public int? SuitableDoctorId { get; set; }

    [Required]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [Required]
    public virtual DoctorDetail? SuitableDoctor { get; set; }
}
