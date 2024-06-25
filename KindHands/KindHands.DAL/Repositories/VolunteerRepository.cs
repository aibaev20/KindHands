using KindHands.DAL.Data;
using KindHands.DAL.Models;

namespace KindHands.DAL.Repositories
{
    public class VolunteerRepository
    {
        private readonly KindHandsDbContext _context;

        public VolunteerRepository(KindHandsDbContext context)
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
    }
}
