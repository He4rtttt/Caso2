using Caso2.Interfaces;
using Caso2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Caso2.Controllers;

public class InteraccioneController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public InteraccioneController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var interacciones = await _unitOfWork.Repository<Interaccione>().GetAllAsync();
            return View(interacciones);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Interaccione interaccione)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Repository<Interaccione>().AddAsync(interaccione);
                await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(interaccione);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var interaccione = await _unitOfWork.Repository<Interaccione>().GetByIdAsync(id);
            if (interaccione == null) return NotFound();
            return View(interaccione);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Interaccione interaccione)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<Interaccione>().Update(interaccione);
                await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(interaccione);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var interaccione = await _unitOfWork.Repository<Interaccione>().GetByIdAsync(id);
            if (interaccione == null) return NotFound();
            return View(interaccione);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interaccione = await _unitOfWork.Repository<Interaccione>().GetByIdAsync(id);
            _unitOfWork.Repository<Interaccione>().Remove(interaccione);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
    }