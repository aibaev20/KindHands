using System;
using System.Collections.Generic;

namespace KindHands.DAL.Models;

public partial class Ad
{
    public int AdId { get; set; }

    public string Title { get; set; } = null!;

    public string Information { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Location { get; set; } = null!;

    public int? OrganisationId { get; set; }

    public virtual Organisation? Organisation { get; set; }

    public virtual ICollection<VolunteerAd> VolunteerAds { get; set; } = new List<VolunteerAd>();
}
