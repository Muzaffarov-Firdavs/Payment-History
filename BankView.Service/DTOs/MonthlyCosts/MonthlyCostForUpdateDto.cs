﻿namespace BankView.Service.DTOs.MonthlyCosts
{
    public class MonthlyCostForUpdateDto
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public long UserId { get; set; }
    }
}
