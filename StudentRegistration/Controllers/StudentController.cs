using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class StudentController : Controller
{
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(StudentViewModel model)
    {
        if (ModelState.IsValid)
        {
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                DOB = model.DOB,
                Gender = model.Gender,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Username = model.Username,
                Password = model.Password,
                Qualifications = model.Qualifications
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        return View(model);
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var student = _context.Students
            .Include(s => s.Qualifications)
            .FirstOrDefault(s => s.Username == username && s.Password == password);

        if (student != null)
        {
            HttpContext.Session.SetString("Username", student.Username);
            return RedirectToAction("List");
        }

        ViewBag.ErrorMessage = "Invalid credentials.";
        return View();
    }

    public IActionResult List()
    {
        var username = HttpContext.Session.GetString("Username");
        if (string.IsNullOrEmpty(username))
        {
            return RedirectToAction("Login");
        }

        var student = _context.Students
            .Include(s => s.Qualifications)
            .FirstOrDefault(s => s.Username == username);

        if (student == null)
        {
            return NotFound();
        }

        var viewModel = new StudentViewModel
        {
            FirstName = student.FirstName,
            LastName = student.LastName,
            Age = student.Age,
            DOB = student.DOB,
            Gender = student.Gender,
            Email = student.Email,
            PhoneNumber = student.PhoneNumber,
            Username = student.Username,
            Password = student.Password,
            Qualifications = student.Qualifications
        };

        return View(new List<StudentViewModel> { viewModel });


    }
}
