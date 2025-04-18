using Caso2.Interfaces;
using Caso2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Caso2.Controllers;
 public class EmpleadoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmpleadoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var empleados = await _unitOfWork.Repository<Empleado>().GetAllAsync();
            return View(empleados);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Empleado empleado)
        {
            if (!ModelState.IsValid) return View(empleado);
            await _unitOfWork.Repository<Empleado>().AddAsync(empleado);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var empleado = await _unitOfWork.Repository<Empleado>().GetByIdAsync(id);
            if (empleado == null) return NotFound();
            return View(empleado);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var empleado = await _unitOfWork.Repository<Empleado>().GetByIdAsync(id);
            if (empleado == null) return NotFound();
            return View(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Empleado empleado)
        {
            if (!ModelState.IsValid) return View(empleado);
            _unitOfWork.Repository<Empleado>().Update(empleado);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var empleado = await _unitOfWork.Repository<Empleado>().GetByIdAsync(id);
            if (empleado == null) return NotFound();
            return View(empleado);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _unitOfWork.Repository<Empleado>().GetByIdAsync(id);
            if (empleado == null) return NotFound();
            _unitOfWork.Repository<Empleado>().Remove(empleado);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
    }