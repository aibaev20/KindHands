using System;
using System.Collections.Generic;

namespace KindHands.DAL.Models;

public partial class Organisation
{
    public int OrganisationId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual ICollection<Ad> Ads { get; set; } = new List<Ad>();

    public virtual User? User { get; set; }
}
