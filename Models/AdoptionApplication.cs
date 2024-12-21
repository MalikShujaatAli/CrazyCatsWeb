using System;
using System.Collections.Generic;

namespace CrazyCatsWeb.Models;

public partial class AdoptionApplication
{
    public int Id { get; set; }

    public string ApplicantName { get; set; } = null!;

    public string ApplicantEmail { get; set; } = null!;

    public int AnimalId { get; set; }

    public string? Message { get; set; }

    public bool IsApproved { get; set; }

    public virtual Animal Animal { get; set; } = null!;
}
