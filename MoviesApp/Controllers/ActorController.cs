using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.ViewModels;
using System.Collections;
using System.Linq;

namespace MoviesApp.Controllers {
	public class ActorController : Controller {

		private readonly MoviesContext _context;
		private IMapper mapper = new MapperConfiguration(
			cfg => { cfg.CreateMap<Actor, ActorViewModel>(); cfg.CreateMap<IEnumerable<Actor>, IEnumerable<ActorViewModel>>(); }).CreateMapper(); 

		// GET: ActorController
		public ActionResult Index() {
			return View(mapper.Map<IEnumerable<ActorViewModel>>(_context.Actors.ToList()));
		}

		// GET: ActorController/Details/5
		public ActionResult Details(int id) {
			return View(mapper.Map<ActorViewModel>(_context.Actors.Find(id)));
		}

		// GET: ActorController/Create
		public ActionResult Create() {
			return View();
		}

		// POST: ActorController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			} catch {
				return View();
			}
		}

		// GET: ActorController/Edit/5
		public ActionResult Edit(int id) {
			return View();
		}

		// POST: ActorController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			} catch {
				return View();
			}
		}

		// GET: ActorController/Delete/5
		public ActionResult Delete(int id) {
			return View();
		}

		// POST: ActorController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			} catch {
				return View();
			}
		}
	}
}
