using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
namespace IdentityApp.Models
{
    public class Invoice
    {
		public int InvoiceId { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal InvoiceAmount { get; set; }
        public string InvoiceMonth { get; set; }
        public string InvoiceOwner { get; set; }
        public string CreatorId { get; set; }
        public InvoiceStatus Status { get; set; }
    }
}

namespace IdentityApp
{
    public enum InvoiceStatus
    {
        Submitted,
        Approved,
        Rejected
      }
}
