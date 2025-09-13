using GerenciamentoDePessoas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePessoas.Controllers;

[Route("/[controller]")]
public class PersonController : Controller
{
    
    [Route("Home")]
    public IActionResult Index()
    {
        ViewBag.Message = TempData["Success"];
        ViewBag.User =  TempData["User"];
        return View();
    }
    
    [Route("Details/{id:int}")]
    public IActionResult Details(int id)
    {
        
        ViewBag.Description = "People Details";
        ViewBag.Date = DateTime.Now;
        
        ViewData["Resume"] = "Here you can see the details of the people registered in the system.";
        
        TempData["Success"] = "Operation completed successfully!";
        
        Person person1 = new()
        {
            Id = 1,
            Name = "John Doe",
            Email = "johndoe@email.com",
            BirthDate = new DateTime(1990, 1, 1)
        };
        
        Person person2 = new()
        {
            Id = 2,
            Name = "Maria Doe",
            Email = "mariadoe@email.com",
            BirthDate = new DateTime(1994, 2, 15)
        };
        
        Person person3 = new()
        {
            Id = 3,
            Name = "José Doe",
            Email = "josedoe@email.com",
            BirthDate = new DateTime(2025, 12, 15)
        };
        
        List<Person> people = new() { person1, person2, person3 };
        
        
        // return View(people);
        return RedirectToAction("Index", "Person");
    }

    //https://localhost:7275/Person/FindByEmail?email=johndoe@email.com
    [HttpGet("FindByEmail")]
    public IActionResult FindByEmail(string email)
    {
        Person person1 = new()
        {
            Id = 1,
            Name = "John Doe",
            Email = "johndoe@email.com",
            BirthDate = new DateTime(1990, 1, 1)
        };
        
        Person person2 = new()
        {
            Id = 2,
            Name = "Maria Doe",
            Email = "mariadoe@email.com",
            BirthDate = new DateTime(1994, 2, 15)
        };
        
        Person person3 = new()
        {
            Id = 3,
            Name = "José Doe",
            Email = "josedoe@email.com",
            BirthDate = new DateTime(2025, 12, 15)
        };
        
        List<Person> people = new() { person1, person2, person3 };
        
        
        Person? foundPerson = people.Find(p => p.Email == email);
        
        return View(foundPerson);
        
        
    }


    [HttpGet("CreateUser")]
    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost("CreateUser")]
    public IActionResult CreateUser([FromForm] Person person)
    {

        if (ModelState.IsValid == false)
            return View(person);
        
        TempData["Success"] = "Person created successfully!";
        TempData["User"] = person.ToString();
        
        return RedirectToAction("Index", "Person");
    }
}

