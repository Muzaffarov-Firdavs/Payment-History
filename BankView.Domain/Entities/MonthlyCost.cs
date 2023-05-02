﻿using BankView.Domain.Commons;

namespace BankView.Domain.Entities
{
    public class MonthlyCost : Auditable
    {
        public decimal Amount { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
