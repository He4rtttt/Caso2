using Caso2.Interfaces;
using Caso2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Caso2.Controllers;

public class InformesprogresoController : Controller

{
    private readonly IUnitOfWork _unitOfWork;
        public InformesprogresoController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var informes = await _unitOfWork.Repository<Informesprogreso>().GetAllAsync();
        return View(informes);
    }

    public async Task<IActionResult> Details(int id)
    {
        var informe = await _unitOfWork.Repository<Informesprogreso>().GetByIdAsync(id);
        if (informe == null) return NotFound();
        return View(informe);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Informesprogreso informe)
    {
        if (ModelState.IsValid)
        {
            await _unitOfWork.Repository<Informesprogreso>().AddAsync(informe);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        return View(informe);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var informe = await _unitOfWork.Repository<Informesprogreso>().GetByIdAsync(id);
        if (informe == null) return NotFound();
        return View(informe);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Informesprogreso informe)
    {
        if (id != informe.InformeId) return NotFound();

        if (ModelState.IsValid)
        {
            _unitOfWork.Repository<Informesprogreso>().Update(informe);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        return View(informe);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var informe = await _unitOfWork.Repository<Informesprogreso>().GetByIdAsync(id);
        if (informe == null) return NotFound();
        return View(informe);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var informe = await _unitOfWork.Repository<Informesprogreso>().GetByIdAsync(id);
        if (informe == null) return NotFound();

        _unitOfWork.Repository<Informesprogreso>().Remove(informe);
        await _unitOfWork.Complete();
        return RedirectToAction(nameof(Index));
    }
}
