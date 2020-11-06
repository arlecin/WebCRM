using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCRM.DataAccess
{
	public class ClientRepository
	{
		private ModelContext context;

		public ClientRepository(ModelContext modelContext)
		{
			context = modelContext;
		}

		public IEnumerable<Client> GetAllClients()
		{
			return context.Clients.ToList();
		}
	}
}
