using Caso2.Interfaces;
using Caso2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Caso2.Controllers;

public class PresupuestoController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
       public PresupuestoController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var presupuestos = await _unitOfWork.Repository<Presupuesto>().GetAllAsync();
        return View(presupuestos);
    }

    public async Task<IActionResult> Details(int id)
    {
        var presupuesto = await _unitOfWork.Repository<Presupuesto>().GetByIdAsync(id);
        if (presupuesto == null) return NotFound();
        return View(presupuesto);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Presupuesto presupuesto)
    {
        if (ModelState.IsValid)
        {
            await _unitOfWork.Repository<Presupuesto>().AddAsync(presupuesto);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        return View(presupuesto);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var presupuesto = await _unitOfWork.Repository<Presupuesto>().GetByIdAsync(id);
        if (presupuesto == null) return NotFound();
        return View(presupuesto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Presupuesto presupuesto)
    {
        if (id != presupuesto.PresupuestoId) return NotFound();

        if (ModelState.IsValid)
        {
            _unitOfWork.Repository<Presupuesto>().Update(presupuesto);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        return View(presupuesto);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var presupuesto = await _unitOfWork.Repository<Presupuesto>().GetByIdAsync(id);
        if (presupuesto == null) return NotFound();
        return View(presupuesto);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var presupuesto = await _unitOfWork.Repository<Presupuesto>().GetByIdAsync(id);
        if (presupuesto == null) return NotFound();

        _unitOfWork.Repository<Presupuesto>().Remove(presupuesto);
        await _unitOfWork.Complete();
        return RedirectToAction(nameof(Index));
    }
}
