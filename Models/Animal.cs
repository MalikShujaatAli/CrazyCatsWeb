using System;
using System.Collections.Generic;

namespace CrazyCatsWeb.Models;

public partial class Animal
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Species { get; set; } = null!;

    public string? Breed { get; set; }

    public int? Age { get; set; }

    public string? Description { get; set; }

    public bool IsAdopted { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<AdoptionApplication> AdoptionApplications { get; set; } = new List<AdoptionApplication>();
}
