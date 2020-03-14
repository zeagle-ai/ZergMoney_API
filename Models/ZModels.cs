using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZergMoney_API.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HouseholdId { get; set; }
    }

    public class BudgetItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int BudgetId { get; set; }
        public decimal Amount { get; set; }

    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class Household
    {
        /// <summary>
        /// ID of the Parent HouseHold
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Invite
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string Email { get; set; }
        public Guid HHToken { get; set; }
        public DateTime InviteDate { get; set; }
        public string InvitedById { get; set; }
        public bool HasBeenUsed { get; set; }
    }

    public class InviteSent
    {
        public int Id { get; set; }
        public int InviteId { get; set; }
        public ApplicationUser User { get; set; }
        public int IsValid { get; set; }
    }

    public class PersonalAccount
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string Name { get; set; }
        public string InstitutionName { get; set; }
        public decimal Balance { get; set; }
        [Display(Name = "Reconciled Balance")]
        public decimal ReconciledBalance { get; set; }
        public string CreatedById { get; set; }
        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; }
    }

    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int HouseHoldId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        [Display(Name = "Credit")]
        public string Deposit { get; set; }
        public bool Void { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Entered By")]
        public string EnteredById { get; set; }
        public bool Reconciled { get; set; }
        public decimal ReconciledAmount { get; set; }
        public bool IsDeleted { get; set; }

    }
}