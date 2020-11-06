using System;
using System.Collections.Generic;
using System.Text;

namespace WebCRM.DataAccess
{
	public class Client
	{
		public int Id { get; set; }

		public int Inn { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }

		public DateTime DateCreate { get; set; }

		public DateTime DateUpdate { get; set; }

		public List<FounderClient> FounderClients { get; set; }

		public Client()
		{
			FounderClients = new List<FounderClient>();
		}
	}
}
