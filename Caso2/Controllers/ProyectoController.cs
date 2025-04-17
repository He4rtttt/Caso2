using Caso2.Interfaces;
using Caso2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Caso2.Controllers;

public class ProyectoController : Controller
{
    
    private readonly IUnitOfWork _unitOfWork;
    
    public ProyectoController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var proyectos = await _unitOfWork.Repository<Proyecto>().GetAllAsync();
        return View(proyectos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Proyecto proyecto)
    {
        if (!ModelState.IsValid)
            return View(proyecto);

        await _unitOfWork.Repository<Proyecto>().AddAsync(proyecto);
        await _unitOfWork.Complete();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var proyecto = await _unitOfWork.Repository<Proyecto>().GetByIdAsync(id);
        if (proyecto == null)
            return NotFound();

        return View(proyecto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Proyecto proyecto)
    {
        if (!ModelState.IsValid)
            return View(proyecto);

        _unitOfWork.Repository<Proyecto>().Update(proyecto);
        await _unitOfWork.Complete();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var proyecto = await _unitOfWork.Repository<Proyecto>().GetByIdAsync(id);
        if (proyecto == null)
            return NotFound();

        _unitOfWork.Repository<Proyecto>().Remove(proyecto);
        await _unitOfWork.Complete();
        return RedirectToAction(nameof(Index));
    }
}
