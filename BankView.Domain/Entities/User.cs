using BankView.Domain.Commons;
using BankView.Domain.Enums;

namespace BankView.Domain.Entities
{
    public class User : Auditable
    {
        public string FirstaName { get; set; }
        public string LastaName { get; set; }
        public decimal Balance { get; set; }
        public UserRole Role { get; set; }
        public ICollection<DailyCost> DailyCosts { get; set; }
        public ICollection<MonthlyCost> MonthlyCosts { get; set; }
        public ICollection<YearlyCost> YearlyCosts { get; set; }
    }
}
