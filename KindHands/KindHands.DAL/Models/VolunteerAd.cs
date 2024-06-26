using System;
using System.Collections.Generic;

namespace KindHands.DAL.Models;

public partial class VolunteerAd
{
    public int VolunteerAdId { get; set; }

    public int? AdId { get; set; }

    public int? VolunteerId { get; set; }

    public virtual Ad? Ad { get; set; }

    public virtual Volunteer? Volunteer { get; set; }
}
