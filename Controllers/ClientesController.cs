// Controllers/ClientesController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CadastroClientesMVC.Models;

public class ClientesController : Controller
{
    public IActionResult Index()
    {
        List<Cliente> clientes = Cliente.GetClientes();
        return View(clientes);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            cliente.AddCliente();
            return RedirectToAction("Index");
        }
        return View(cliente);
    }

    public IActionResult Edit(int id)
    {
        var cliente = Cliente.GetClientes().Find(c => c.ID_Cliente == id);
        if (cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }

    [HttpPost]
    public IActionResult Edit(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            cliente.UpdateCliente();
            return RedirectToAction("Index");
        }
        return View(cliente);
    }

    public IActionResult Delete(int id)
    {
        var cliente = Cliente.GetClientes().Find(c => c.ID_Cliente == id);
        if (cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        Cliente.DeleteCliente(id);
        return RedirectToAction("Index");
    }
}
