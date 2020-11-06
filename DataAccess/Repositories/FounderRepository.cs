using System;
using System.Collections.Generic;
using System.Text;

namespace WebCRM.DataAccess
{
	public class FounderRepository
	{
		private ModelContext context;

		public FounderRepository(ModelContext modelContext)
		{
			context = modelContext;
		}
	}
}
