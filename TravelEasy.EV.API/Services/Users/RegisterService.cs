using TravelEasy.EV.DataLayer;
namespace TravelEasy.EV.API.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly ElectricVehiclesContext _EVContext;
        public RegisterService(ElectricVehiclesContext context) 
        { _EVContext = context; }

        string IRegisterService.Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IRegisterService.Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IRegisterService.Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IRegisterService.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        void IRegisterService.UserAuthentification(int userId)
        {
            throw new NotImplementedException();
        }

        void IRegisterService.UserRegister()
        {
            throw new NotImplementedException();
        }
    }
}
