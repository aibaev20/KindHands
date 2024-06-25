using KindHands.BLL.Interfaces;
using KindHands.DAL.Models;
using KindHands.DAL.Repositories;

namespace KindHands.BLL.Services
{
    public class VolunteerService : IVolunteerService
    {
        private readonly VolunteerRepository _repository;

        public VolunteerService(VolunteerRepository repository)
        {
            _repository = repository;
        }

        public bool CheckVolunteer(string phoneNumber)
        {
            return _repository.GetAllVolunteersWithUsers()?.Any(volunteer => volunteer.User.PhoneNumber == phoneNumber) ?? false;
        }

        public Volunteer ConvertToVolunteer(string username, string password, string phoneNumber, string email, string firstName, string lastName)
        {
            User user = new User(username, password, phoneNumber, email);
            Volunteer volunteer = new Volunteer(firstName, lastName, user);

            return volunteer;
        }

        public void AddVolunteer(string username, string password, string phoneNumber, string email, string firstName, string lastName)
        {
            _repository.AddVolunteer(ConvertToVolunteer(username, password, phoneNumber, email, firstName, lastName));
        }

        public bool AuthenticateVolunteer(string email, string password, string phoneNumber)
        {
            return _repository.GetAllVolunteersWithUsers()
                .Any(volunteer => volunteer.User.Email == email && volunteer.User.Password == password && volunteer.User.PhoneNumber == phoneNumber);
        }
    }
}
