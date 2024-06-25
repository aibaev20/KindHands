using KindHands.DAL.Data;
using KindHands.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KindHands.DAL.Repositories
{
    public class OrganisationRepository
    {
        private readonly KindHandsDbContext _context;

        public OrganisationRepository(KindHandsDbContext context)
        {
            _context = context;
        }

        public List<Organisation> GetAllOrganisations()
        {
            return _context.Organisations.ToList();
        }

        public void AddOrganisation(Organisation newOrganisation)
        {
            _context.Organisations.Add(newOrganisation);
            _context.SaveChanges();
        }

        public List<Organisation> GetAllOrganisationsWithUsers()
        {
            return _context.Organisations
                .Include(o => o.User)
                .ToList();
        }
    }
}
