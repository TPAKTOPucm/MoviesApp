using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.ViewModels;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Controllers {
	public class ActorController : Controller {

		private readonly MoviesContext _context;
		private IMapper _mapper;

		public ActorController(MoviesContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}

		// GET: ActorController
		public ActionResult Index() {
			return View(_mapper.Map<List<ActorViewModel>>(_context.Actors.ToList()));
		}

		// GET: ActorController/Details/5
		public ActionResult Details(int id) {
			return View(_mapper.Map<ActorViewModel>(_context.Actors.Find(id)));
		}

		// GET: ActorController/Create
		public ActionResult Create() {
			return View();
		}

		// POST: ActorController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(InputMovieViewModel inputModel) {
			if (ModelState.IsValid) {
				_context.Add(_mapper.Map<Actor>(inputModel));
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(inputModel);
		}

		// GET: ActorController/Edit/5
		public ActionResult Edit(int id) {
			var actor = _mapper.Map<EditActorViewModel>(_context.Actors.Find(id));
			if (actor == null)
				return NotFound();
			return View(actor);
		}

		// POST: ActorController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, EditActorViewModel editModel) {
			if (ModelState.IsValid) {
				var actor = _mapper.Map<Actor>(editModel);
				actor.Id = id;
				if (_context.Actors.Any(a => a.Id == id)) {
					_context.Update(actor);
					_context.SaveChanges();
					return RedirectToAction(nameof(Index));
				} else {
					return NotFound();
				}
			}
			return View(editModel);
		}

		// GET: ActorController/Delete/5
		public ActionResult Delete(int id) {
			var deleteModel = _mapper.Map<DeleteActorViewModel>(_context.Actors.Find(id));
			if (deleteModel == null)
				return NotFound();
			return View(deleteModel);
		}

		// POST: ActorController/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id) {
			var movie = _context.Movies.Find(id);
			_context.Movies.Remove(movie);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
