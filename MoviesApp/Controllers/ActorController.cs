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
using MoviesApp.Filters;
using MoviesApp.Services;
using Microsoft.AspNetCore.Components.Web;
using MoviesApp.Services.Dto;
using Microsoft.AspNetCore.Authorization;

namespace MoviesApp.Controllers 
{
	public class ActorController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IActorService _service;

		public ActorController(IMapper mapper, IActorService service)
		{
			_service = service;
			_mapper = mapper;
		}

		// GET: ActorController
		[HttpGet]
		[Authorize]
		public ActionResult Index()
		{
			var actors = _mapper.Map<IEnumerable<ActorDto>, IEnumerable<ActorViewModel>>(_service.GetAllActors());
			return View(actors);
		}

		// GET: ActorController/Details/5
		[HttpGet]
		[Authorize]
		public ActionResult Details(int id)
		{
			var actor = _mapper.Map<ActorViewModel>(_service.GetActor(id));
			if (actor == null)
			{
				return NotFound();
			}
			return View(actor);
		}

		// GET: ActorController/Create
		[HttpGet]
		[Authorize(Roles = "Admin")]
		public ActionResult Create()
		{
			return View();
		}

		// POST: ActorController/Create
		[HttpPost]
		[Authorize(Roles = "Admin")]
		[ValidateAntiForgeryToken]
		[AgeFilter]
		public ActionResult Create([Bind("FirstName,LastName,Birthday")] InputMovieViewModel inputModel) 
		{
			if (ModelState.IsValid)
			{
				_service.AddActor(_mapper.Map<ActorDto>(inputModel));
				return RedirectToAction(nameof(Index));
			}
			return View(inputModel);
		}

		// GET: ActorController/Edit/5
		[HttpGet]
		[Authorize(Roles = "Admin")]
		public ActionResult Edit(int id) {
			var actor = _mapper.Map<EditActorViewModel>(_service.GetActor(id));
			if (actor == null)
				return NotFound();
			return View(actor);
		}

		// POST: ActorController/Edit/5
		[HttpPost]
		[Authorize(Roles = "Admin")]
		[ValidateAntiForgeryToken]
		[AgeFilter]
		public ActionResult Edit(int id,[Bind("FirstName,LastName,Birthday")] EditActorViewModel editModel)
		{
			if (ModelState.IsValid)
			{
				ActorDto actor = _mapper.Map<ActorDto>(editModel);
				actor.Id = id;
				actor = _service.UpdateActor(actor);
				if (actor == null)
					return NotFound();
				return RedirectToAction(nameof(Index));
			}
			return View(editModel);
		}

		// GET: ActorController/Delete/5
		[HttpGet]
		[Authorize(Roles = "Admin")]
		public ActionResult Delete(int id)
		{
			var deleteModel = _mapper.Map<DeleteActorViewModel>(_service.GetActor(id));
			if (deleteModel == null)
				return NotFound();
			return View(deleteModel);
		}

		// POST: ActorController/Delete/5
		[HttpPost, ActionName("Delete")]
		[Authorize(Roles = "Admin")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var actor = _service.DeleteActor(id);
			if (actor == null)
				return NotFound();
			return RedirectToAction(nameof(Index));
		}
	}
}
