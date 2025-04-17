using Caso2.Interfaces;
using Caso2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Caso2.Controllers;

public class ClienteController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public ClienteController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var clientes = await _unitOfWork.Repository<Cliente>().GetAllAsync();
        return View(clientes);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Cliente cliente)
    {
        if (!ModelState.IsValid) return View(cliente);

        await _unitOfWork.Repository<Cliente>().AddAsync(cliente);
        await _unitOfWork.Complete();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var cliente = await _unitOfWork.Repository<Cliente>().GetByIdAsync(id);
        if (cliente == null) return NotFound();

        return View(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Cliente cliente)
    {
        if (!ModelState.IsValid) return View(cliente);

        _unitOfWork.Repository<Cliente>().Update(cliente);
        await _unitOfWork.Complete();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _unitOfWork.Repository<Cliente>().GetByIdAsync(id);
        if (cliente == null) return NotFound();

        _unitOfWork.Repository<Cliente>().Remove(cliente);
        await _unitOfWork.Complete();
        return RedirectToAction(nameof(Index));
    }
}
