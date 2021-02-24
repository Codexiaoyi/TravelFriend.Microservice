using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelFriend.Identity.Infrastructure
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountContext accountContext;

        public AccountRepository(AccountContext accountContext)
        {
            this.accountContext = accountContext;
        }

        public async Task<bool> AddAccountAsync(Account account)
        {
            await accountContext.AddAsync(account);
            var result = await accountContext.SaveChangesAsync();
            return result == 1;
        }

        public async Task<Account> QueryAccountAsync(string email)
        {
            return await accountContext.Accounts.FirstOrDefaultAsync(x => x.UserEmail == email);
        }
    }
}
