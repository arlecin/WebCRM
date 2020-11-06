using System;
using System.Collections.Generic;
using System.Text;

namespace WebCRM.Web
{
	public class UnitOfWork : IUnitOfWork
	{
		private ModelContext DataBase { get; }

		private ClientRepository clientRepository;

		private FounderRepository founderRepository;

		public UnitOfWork()
		{
			DataBase = new ModelContext();
		}

        public ClientRepository Client
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(DataBase);
                return clientRepository;
            }
        }
        public FounderRepository Founder
        {
            get
            {
                if (founderRepository == null)
                    founderRepository = new FounderRepository(DataBase);
                return founderRepository;
            }
        }
        public void Save()
        {
            DataBase.SaveChanges();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
