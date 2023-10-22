using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Engineers.ToList());
    }

    public ActionResult Details(int id)
    {
      Engineer thisEnge = _db.Engineers
          .Include(engineer => engineer.JoinEntities)
          .ThenInclude(join => join.Machine)
          .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEnge);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer enge)
    {

      _db.Engineers.Add(enge);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Engineer thisEnge = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEnge);
    }

    [HttpPost]
    public ActionResult Edit(Engineer enge)
    {
      if (!ModelState.IsValid)
      {
        return RedirectToAction("Edit");
      }
      _db.Engineers.Update(enge);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Engineer thisEnge = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEnge);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Engineer thisEnge = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      _db.Engineers.Remove(thisEnge);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
      Engineer enge = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);

      List<Machine> machines = _db.Machines.ToList();

      if (machines.Count == 0)
      {
        return RedirectToAction("Details", new { id = enge.EngineerId });
      }
      else
      {
        ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
        return View(enge);
      }
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer enge, int machineId)
    {
      #nullable enable
      EngineerMachine? joinEntity = _db.EngineerMachines.FirstOrDefault(join => (join.MachineId == machineId && join.EngineerId == enge.EngineerId));
      #nullable disable
      if (joinEntity == null && machineId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { MachineId = machineId, EngineerId = enge.EngineerId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = enge.EngineerId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      EngineerMachine joinEntry = _db.EngineerMachines.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}