using Kozmos.WebAPI.Data.Model;
using Kozmos.WebAPI.Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kozmos.WebAPI.Data.Services
{
    public class CustomerMessageServices
    {
        private KozmosContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CustomerMessageServices(KozmosContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public async Task<List<CustomerMessageGetVM>> GetAllCustomerMessagesService()
        {
            var messages = await _context.CustomerMessages.ToListAsync();
            var messagesVMList = new List<CustomerMessageGetVM>();
            foreach (var item in messages)
            {
                var user = await _userManager.FindByIdAsync(item.ApplicationUserId);
                messagesVMList.Add(new CustomerMessageGetVM
                {
                    ApplicationUserEmail = user?.Email,
                    ApplicationUserFullName = user?.FullName,
                    Text = item.Text,
                    Title = item.Title,
                    IsResolved = item.IsResolved,

                });
            }

            return messagesVMList;
        }

        

        public async Task<bool> CreateUserMessage(CustomerMessageAddVM vm)
        {
            try
            {
                await _context.CustomerMessages.AddAsync(new CustomerMessage
                {
                    Title = vm.Title,
                    Text = vm.Text,
                    ApplicationUserId = _context.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsResolved = false
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }


        }

        public async Task<bool> ChangeIsResolvedService(int Id)
        {
            var customerMessage = await _context.CustomerMessages.FindAsync(Id);

            if (customerMessage != null)
            {

                customerMessage.IsResolved = !customerMessage.IsResolved;

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }




    }
}
