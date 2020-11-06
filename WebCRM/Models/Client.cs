using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebCRM.Web
{
	public class Client
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Не указан ИНН")]
		[RegularExpression(@"\b([0-9]{10,12})\b", ErrorMessage = "Некорректный ИНН")]
		public long Inn { get; set; }

		[Required(ErrorMessage = "Не указано название")]
		public string Name { get; set; }

		public int Type { get; set; }

		public DateTime DateCreate { get; set; }

		public DateTime DateUpdate { get; set; }

		public List<FounderClient> FounderClients { get; set; }

		public Client()
		{
			FounderClients = new List<FounderClient>();
		}
	}
}
