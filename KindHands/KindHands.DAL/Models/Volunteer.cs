using System;
using System.Collections.Generic;

namespace KindHands.DAL.Models;

public partial class Volunteer
{
    public int VolunteerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<VolunteerAd> VolunteerAds { get; set; } = new List<VolunteerAd>();
}
