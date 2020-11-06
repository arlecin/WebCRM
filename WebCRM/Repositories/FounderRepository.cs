using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCRM.Web
{
	public class FounderRepository
	{
		private ModelContext context;

		public FounderRepository(ModelContext modelContext)
		{
			context = modelContext;
		}

		public IEnumerable<Founder> GetAllFounders()
		{
			return context.Founders.ToList();
		}

		public void AddFounder(Founder founder)
		{
			var founderIdDb = GetFounderByInn(founder.Inn);

			if(founderIdDb != null)
				throw new Exception("Учредитель с таким ИНН уже есть в базе");

			founder.DateCreate = DateTime.Now;
			founder.DateUpdate = DateTime.Now;
			context.Founders.Add(founder);
		}

		public void DeleteFounderById(int id)
		{
			var founder = context.Founders.Find(id);
			context.Founders.Remove(founder);
		}

		public Founder GetFounderById(int id)
		{
			return context.Founders.Find(id);
		}

		public void UpdateFounder(Founder founder)
		{
			var founderIdDb = GetFounderByInn(founder.Inn);

			if (founderIdDb != null && founderIdDb.Id != founder.Id)
				throw new Exception("Учредитель с таким ИНН уже есть в базе");

			var founderUpdate = context.Founders.Find(founder.Id);
			founderUpdate.Inn = founder.Inn;
			founderUpdate.Name = founder.Name;
			founderUpdate.Syrname = founder.Syrname;
			founderUpdate.Patronymic = founder.Patronymic;
			founderUpdate.DateUpdate = DateTime.Now;
		}

		public IEnumerable<Founder> GetAllFounderInClient(int id)
		{
			return context.Founders.Where(f => f.FounderClients.Any(fc => fc.ClientId == id));
		}

		public void AddFounderInClient(int idFounder, int idClient)
		{
			var client = context.Clients.Find(idClient);

			if (client.Type == (int)TypeClient.PhysicalEntity && client.FounderClients.Count > 0)
				throw new Exception("Физическое лицо не может иметь больше одного учредителя");

			if(client.FounderClients.FirstOrDefault(f => f.FounderId == idFounder) != null)
				throw new Exception("У этого клиента уже присутствует текущий учредитель");

			client.FounderClients.Add(new FounderClient { ClientId = idClient, FounderId = idFounder });
		}

		public void DeleteFounderInClient(int idFounder, int idClient)
		{
			var client = context.Clients.Include(c => c.FounderClients).First(c => c.Id == idClient);
			var founder = context.Founders.First(f => f.Id == idFounder);
			var clientFounder = client.FounderClients.First(cf => cf.FounderId == founder.Id);

			client.FounderClients.Remove(clientFounder);
		}

		public Founder GetFounderByInn(long inn)
		{
			return context.Founders.FirstOrDefault(f => f.Inn == inn);
		}
	}
}
