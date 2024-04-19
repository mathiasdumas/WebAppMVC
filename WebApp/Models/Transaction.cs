using System;
namespace WebApp.Models
{
	public class Transaction
	{
		public int Id { get; set; }
		public string CashierName { get; set; }
		public Product Product { get; set; }

	}
}

