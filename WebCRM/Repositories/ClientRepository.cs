using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCRM.Web
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

		public void AddClient(Client client)
		{
			var clientInDb = GetClientByInn(client.Inn);
			if(clientInDb != null)
				throw new Exception("Клиент с таким ИНН уже есть в базе");

			client.DateCreate = DateTime.Now;
			client.DateUpdate = DateTime.Now;
			context.Clients.Add(client);
		}

		public Client GetClientById(int id)
		{
			return context.Clients.Find(id);
		}

		public void DeleteClientById(int id)
		{
			var client = context.Clients.Find(id);
			context.Clients.Remove(client);
		}

		public void UpdateClient(Client client)
		{
			var clientInDb = GetClientByInn(client.Inn);
			if (clientInDb != null && clientInDb.Id != client.Id)
				throw new Exception("Клиент с таким ИНН уже есть в базе");

			var clientUpdate = context.Clients.Find(client.Id);
			clientUpdate.Inn = client.Inn;
			clientUpdate.Name = client.Name;
			clientUpdate.Type = client.Type;
			clientUpdate.DateUpdate = DateTime.Now;
		}

		public Client GetClientByInn(long inn)
		{
			return context.Clients.FirstOrDefault(c => c.Inn == inn);
		}
	}
}
