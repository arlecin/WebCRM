using System;
using System.Collections.Generic;
using System.Text;

namespace WebCRM.Web
{
	public class FounderClient
	{
		public int ClientId { get; set; }

		public Client Client { get; set; }

		public int FounderId { get; set; }

		public Founder Founder { get; set; }
	}
}
