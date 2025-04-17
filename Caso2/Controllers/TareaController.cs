using Caso2.Interfaces;
using Caso2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Caso2.Controllers;

public class TareaController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public TareaController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var tareas = await _unitOfWork.Repository<Tarea>().GetAllAsync();
        return View(tareas);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Tarea tarea)
    {
        if (!ModelState.IsValid)
            return View(tarea);

        await _unitOfWork.Repository<Tarea>().AddAsync(tarea);
        await _unitOfWork.Complete();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var tarea = await _unitOfWork.Repository<Tarea>().GetByIdAsync(id);
        if (tarea == null)
            return NotFound();

        return View(tarea);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Tarea tarea)
    {
        if (!ModelState.IsValid)
            return View(tarea);

        _unitOfWork.Repository<Tarea>().Update(tarea);
        await _unitOfWork.Complete();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var tarea = await _unitOfWork.Repository<Tarea>().GetByIdAsync(id);
        if (tarea == null)
            return NotFound();

        _unitOfWork.Repository<Tarea>().Remove(tarea);
        await _unitOfWork.Complete();
        return RedirectToAction(nameof(Index));
    }
}
