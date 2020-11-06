using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebCRM.Web
{
	public class FounderOfClientController : Controller
	{
		private IUnitOfWork dataBase;

		public FounderOfClientController(IUnitOfWork db)
		{
			dataBase = db;
		}

		public IActionResult Index(int idClient)
		{
			var founders = dataBase.Founder.GetAllFounderInClient(idClient).ToList();
			ViewBag.idClient = idClient;

			return View(founders);
		}

		public IActionResult Create(int idClient)
		{
			var founders = dataBase.Founder.GetAllFounders().ToList();
			ViewBag.idClient = idClient;

			return View(founders);
		}

		[HttpPost]
		public IActionResult Create(int idFounder, int idClient)
		{
			dataBase.Founder.AddFounderInClient(idFounder, idClient);
			dataBase.Save();

			return RedirectToAction("Index", new { idClient = idClient });
		}

		public IActionResult Delete(int idFounder, int idClient)
		{
			dataBase.Founder.DeleteFounderInClient(idFounder, idClient);
			dataBase.Save();

			return RedirectToAction("Index", new { idClient = idClient });
		}
	}
}
