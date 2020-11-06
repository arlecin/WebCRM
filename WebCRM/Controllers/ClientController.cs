using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebCRM.Web
{
	public class ClientController : Controller
	{
		private IUnitOfWork dataBase;

		public ClientController(IUnitOfWork db)
		{
			dataBase = db;
		}

		public IActionResult Index(int page = 1)
		{
			var clients = dataBase.Client.GetAllClients().ToList();

			return View(new PageViewModel<Client>(page, clients));
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Client client)
		{
			dataBase.Client.AddClient(client);
			dataBase.Save();

			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			dataBase.Client.DeleteClientById(id);
			dataBase.Save();

			return RedirectToAction("Index");
		}

		public IActionResult Update(int id)
		{
			var client = dataBase.Client.GetClientById(id);

			return View(client);
		}

		[HttpPost]
		public IActionResult Update(Client client)
		{
			dataBase.Client.UpdateClient(client);
			dataBase.Save();

			return RedirectToAction("Index");
		}
	}
}
