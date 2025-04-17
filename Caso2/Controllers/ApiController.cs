using Caso2.Interfaces;
using Caso2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Caso2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteApiController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public ClienteApiController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _unitOfWork.Repository<Cliente>().GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _unitOfWork.Repository<Cliente>().GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Cliente c)
    {
        await _unitOfWork.Repository<Cliente>().AddAsync(c);
        await _unitOfWork.Complete();
        return Ok(c);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Cliente c)
    {
        if (id != c.ClienteId) return BadRequest();
        _unitOfWork.Repository<Cliente>().Update(c);
        await _unitOfWork.Complete();
        return Ok(c);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var c = await _unitOfWork.Repository<Cliente>().GetByIdAsync(id);
        if (c == null) return NotFound();
        _unitOfWork.Repository<Cliente>().Remove(c);
        await _unitOfWork.Complete();
        return Ok();
    }
}

[ApiController]
[Route("api/[controller]")]
public class EmpleadoApiController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public EmpleadoApiController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _unitOfWork.Repository<Empleado>().GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _unitOfWork.Repository<Empleado>().GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Empleado e)
    {
        await _unitOfWork.Repository<Empleado>().AddAsync(e);
        await _unitOfWork.Complete();
        return Ok(e);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Empleado e)
    {
        if (id != e.EmpleadoId) return BadRequest();
        _unitOfWork.Repository<Empleado>().Update(e);
        await _unitOfWork.Complete();
        return Ok(e);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var e = await _unitOfWork.Repository<Empleado>().GetByIdAsync(id);
        if (e == null) return NotFound();
        _unitOfWork.Repository<Empleado>().Remove(e);
        await _unitOfWork.Complete();
        return Ok();
    }
}

[ApiController]
[Route("api/[controller]")]
public class InformesprogresoApiController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public InformesprogresoApiController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _unitOfWork.Repository<Informesprogreso>().GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _unitOfWork.Repository<Informesprogreso>().GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Informesprogreso i)
    {
        await _unitOfWork.Repository<Informesprogreso>().AddAsync(i);
        await _unitOfWork.Complete();
        return Ok(i);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Informesprogreso i)
    {
        if (id != i.InformeId) return BadRequest();
        _unitOfWork.Repository<Informesprogreso>().Update(i);
        await _unitOfWork.Complete();
        return Ok(i);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var i = await _unitOfWork.Repository<Informesprogreso>().GetByIdAsync(id);
        if (i == null) return NotFound();
        _unitOfWork.Repository<Informesprogreso>().Remove(i);
        await _unitOfWork.Complete();
        return Ok();
    }
}

[ApiController]
[Route("api/[controller]")]
public class InteraccioneApiController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public InteraccioneApiController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _unitOfWork.Repository<Interaccione>().GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _unitOfWork.Repository<Interaccione>().GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Interaccione i)
    {
        await _unitOfWork.Repository<Interaccione>().AddAsync(i);
        await _unitOfWork.Complete();
        return Ok(i);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Interaccione i)
    {
        if (id != i.InteraccionId) return BadRequest();
        _unitOfWork.Repository<Interaccione>().Update(i);
        await _unitOfWork.Complete();
        return Ok(i);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var i = await _unitOfWork.Repository<Interaccione>().GetByIdAsync(id);
        if (i == null) return NotFound();
        _unitOfWork.Repository<Interaccione>().Remove(i);
        await _unitOfWork.Complete();
        return Ok();
    }
}

[ApiController]
[Route("api/[controller]")]
public class PresupuestoApiController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public PresupuestoApiController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _unitOfWork.Repository<Presupuesto>().GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _unitOfWork.Repository<Presupuesto>().GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Presupuesto p)
    {
        await _unitOfWork.Repository<Presupuesto>().AddAsync(p);
        await _unitOfWork.Complete();
        return Ok(p);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Presupuesto p)
    {
        if (id != p.PresupuestoId) return BadRequest();
        _unitOfWork.Repository<Presupuesto>().Update(p);
        await _unitOfWork.Complete();
        return Ok(p);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var p = await _unitOfWork.Repository<Presupuesto>().GetByIdAsync(id);
        if (p == null) return NotFound();
        _unitOfWork.Repository<Presupuesto>().Remove(p);
        await _unitOfWork.Complete();
        return Ok();
    }
}

[ApiController]
[Route("api/[controller]")]
public class ProyectoApiController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public ProyectoApiController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _unitOfWork.Repository<Proyecto>().GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _unitOfWork.Repository<Proyecto>().GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Proyecto p)
    {
        await _unitOfWork.Repository<Proyecto>().AddAsync(p);
        await _unitOfWork.Complete();
        return Ok(p);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Proyecto p)
    {
        if (id != p.ProyectoId) return BadRequest();
        _unitOfWork.Repository<Proyecto>().Update(p);
        await _unitOfWork.Complete();
        return Ok(p);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var p = await _unitOfWork.Repository<Proyecto>().GetByIdAsync(id);
        if (p == null) return NotFound();
        _unitOfWork.Repository<Proyecto>().Remove(p);
        await _unitOfWork.Complete();
        return Ok();
    }
}

[ApiController]
[Route("api/[controller]")]
public class TareaApiController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public TareaApiController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _unitOfWork.Repository<Tarea>().GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _unitOfWork.Repository<Tarea>().GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Tarea t)
    {
        await _unitOfWork.Repository<Tarea>().AddAsync(t);
        await _unitOfWork.Complete();
        return Ok(t);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Tarea t)
    {
        if (id != t.TareaId) return BadRequest();
        _unitOfWork.Repository<Tarea>().Update(t);
        await _unitOfWork.Complete();
        return Ok(t);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var t = await _unitOfWork.Repository<Tarea>().GetByIdAsync(id);
        if (t == null) return NotFound();
        _unitOfWork.Repository<Tarea>().Remove(t);
        await _unitOfWork.Complete();
        return Ok();
    }
}
