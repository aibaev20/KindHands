using KindHands.DAL.Data;
using KindHands.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KindHands.DAL.Repositories
{
    public class VolunteerRepository
    {
        private readonly KindHandsContext _context;

        public VolunteerRepository(KindHandsContext context)
        {
            _context = context;
        }

        public List<Volunteer> GetAllVolunteers()
        {
            return _context.Volunteers.ToList();
        }

        public void AddVolunteer(Volunteer newVolunteer)
        {
            _context.Volunteers.Add(newVolunteer);
            _context.SaveChanges();
        }

        public List<Volunteer> GetAllVolunteersWithUsers()
        {
            return _context.Volunteers
                .Include(v => v.User)
                .ToList();
        }
    }
}
