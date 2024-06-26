using System;
using System.Collections.Generic;

namespace KindHands.DAL.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Organisation> Organisations { get; set; } = new List<Organisation>();

    public virtual ICollection<Volunteer> Volunteers { get; set; } = new List<Volunteer>();
}
