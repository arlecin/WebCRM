using System;
using System.Collections.Generic;
using System.Text;

namespace WebCRM.Web
{
	public interface IUnitOfWork : IDisposable
	{
		ClientRepository Client { get; }

		FounderRepository Founder { get; }

		void Save();
	}
}
