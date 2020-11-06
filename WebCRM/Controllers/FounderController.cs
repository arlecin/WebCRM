using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebCRM.Web
{
	public class FounderController : Controller
	{
		private IUnitOfWork dataBase;

		public FounderController(IUnitOfWork db)
		{
			dataBase = db;
		}

		public IActionResult Index(int page = 1)
		{
			var founders = dataBase.Founder.GetAllFounders().ToList();

			return View(new PageViewModel<Founder>(page, founders));
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Founder foundr)
		{
			dataBase.Founder.AddFounder(foundr);
			dataBase.Save();

			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			dataBase.Founder.DeleteFounderById(id);
			dataBase.Save();

			return RedirectToAction("Index");
		}

		public IActionResult Update(int id)
		{
			var founder = dataBase.Founder.GetFounderById(id);

			return View(founder);
		}

		[HttpPost]
		public IActionResult Update(Founder founder)
		{
			dataBase.Founder.UpdateFounder(founder);
			dataBase.Save();

			return RedirectToAction("Index");
		}
	}
}
