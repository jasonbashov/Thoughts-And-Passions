using RegistrationApp.DTOs;

namespace RegistrationApp.Interfaces
{
    public interface IRegistrationRule
    {
        void Validate(RegistrationData registrationData);
    }
}
