using System.Threading.Tasks;
using Ticket.Data.ViewModel.Account;

namespace Ticket.Service.Service.Abstract
{
    public interface IAccountService
    {
        public Task<ResponseViewModel> Login(LoginViewModel model);
        public ResponseViewModel Register(RegisterViewModel model);
    }
}
