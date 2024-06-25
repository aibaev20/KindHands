using KindHands.BLL.Interfaces;
using KindHands.DAL.Models;
using KindHands.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindHands.BLL.Services
{
    public class OrganisationService : IOrganisationService
    {
        private readonly OrganisationRepository _repository;

        public OrganisationService(OrganisationRepository repository)
        {
            _repository = repository;
        }

        public bool CheckOrganisation(string phoneNumber)
        {
            return _repository.GetAllOrganisationsWithUsers()?.Any(organisation => organisation.User.PhoneNumber == phoneNumber) ?? false;
        }

        public Organisation ConvertToOrganisation(string username, string password, string phoneNumber, string email, string name, string description)
        {
            User user = new User(username, password, phoneNumber, email);
            Organisation organisation = new Organisation(name, description, user);

            return organisation;
        }

        public void AddOrganisation(string username, string password, string phoneNumber, string email, string name, string description)
        {
            _repository.AddOrganisation(ConvertToOrganisation(username, password, phoneNumber, email, name, description));
        }

        public bool AuthenticateOrganisation(string email, string password, string phoneNumber)
        {
            return _repository.GetAllOrganisationsWithUsers()
                .Any(organisation => organisation.User.Email == email && organisation.User.Password == password && organisation.User.PhoneNumber == phoneNumber);
        }
    }
}
