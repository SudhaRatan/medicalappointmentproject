using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace medicalappointmentproject.Models;

public partial class DoctorDetail
{
    [Required]
    public int DoctorId { get; set; }

    [Required]
    public string DoctorName { get; set; } = null!;

    [Required]
    public string Specialisation { get; set; } = null!;

    [Required]
    public string AvailableTime { get; set; } = null!;

    [Required]
    public int DoctorFee { get; set; }

    [Required]
    public virtual ICollection<DiseasesDoctorDetail> DiseasesDoctorDetails { get; set; } = new List<DiseasesDoctorDetail>();
}
