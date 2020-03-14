using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace ZergMoney_API.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public async Task<Household> GetHouseHold(int hhId)
        {
            SqlParameter param1 = new SqlParameter("@hhId", hhId);
            return await Database.SqlQuery<Household>("GetHousehold @hhId", param1).FirstOrDefaultAsync();
        }

        public async Task<List<PersonalAccount>> GetHouseHoldAccounts(int hhId)
        {
            SqlParameter param1 = new SqlParameter("@hhId", hhId);
            return await Database.SqlQuery<PersonalAccount>("GetHouseHoldAccounts @hhId", param1).ToListAsync();
        }
        public async Task<List<Transaction>> GetTransactions(int accId)
        {
            SqlParameter param1 = new SqlParameter("@accId", accId);
            return await Database.SqlQuery<Transaction>("GetTransactions @accId", param1).ToListAsync();
        }
        public async Task<Budget> GetBudget(int hhId)
        {
            SqlParameter param1 = new SqlParameter("@hhId", hhId);
            return await Database.SqlQuery<Budget>("GetBudget @hhid", param1).FirstOrDefaultAsync();
        }
        public async Task<List<BudgetItem>> GetBudgetItems(int budgId)
        {
            SqlParameter param1 = new SqlParameter("@budgId", budgId);
            return await Database.SqlQuery<BudgetItem>("GetBudgetItems @budgId", param1).ToListAsync();
        }
        public int AddTransaction(int accountId, string description, DateTime date, decimal amount, bool isVoid, int catId, string owner, bool rec, decimal recAmount, bool isDel, string dep, int hhId)
        {
            SqlParameter param1 = new SqlParameter("@AccountId", accountId);
            SqlParameter param2 = new SqlParameter("@Description", description);
            SqlParameter param3 = new SqlParameter("@Date", date);
            SqlParameter param4 = new SqlParameter("@Amount", amount);
            SqlParameter param5 = new SqlParameter("@Void", isVoid);
            SqlParameter param6 = new SqlParameter("@CategoryId", catId);
            SqlParameter param7 = new SqlParameter("@EnteredById", owner);
            SqlParameter param8 = new SqlParameter("@Reconciled", rec);
            SqlParameter param9 = new SqlParameter("@ReconciledAmount", recAmount);
            SqlParameter param10 = new SqlParameter("@IsDeleted", isDel);
            SqlParameter param11 = new SqlParameter("@Deposit", dep);
            SqlParameter param12 = new SqlParameter("@HouseHoldID", hhId);
            return Database.ExecuteSqlCommand("AddTransaction @AccountId, @Description, @Date, @Amount, @Void, @CategoryId, @EnteredById, @Reconciled, @ReconciledAmount, @IsDeleted, @Deposit, @HouseHoldID",
                param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);
        }
        public int AddAccount(int hhId, string name, decimal bal, decimal recBal, string owner, bool isDel, string bankName)
        {
            SqlParameter param1 = new SqlParameter("@hhId", hhId);
            SqlParameter param2 = new SqlParameter("@name", name);
            SqlParameter param3 = new SqlParameter("@bal", bal);
            SqlParameter param4 = new SqlParameter("@recBal", recBal);
            SqlParameter param5 = new SqlParameter("@owner", owner);
            SqlParameter param6 = new SqlParameter("@isDel", isDel);
            SqlParameter param7 = new SqlParameter("@bankName", bankName);
            return Database.ExecuteSqlCommand("AddAccount @hhId, @name, @bal, @recBal, @owner, @isDel, @bankName",
                param1, param2, param3, param4, param5, param6, param7);
        }
    }
}