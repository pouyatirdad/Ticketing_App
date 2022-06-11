using Ticket.Data.ViewModel.Account;

namespace Ticket.Service.Service.Abstract
{
    public interface IAccountService
    {
        public void Login(LoginViewModel model);
        public bool Register(RegisterViewModel model);
    }
}
