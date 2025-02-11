﻿
using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.ProjectModel;

public class ProjectRegistrationForm
{   
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }


}
