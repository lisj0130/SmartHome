using Microsoft.AspNetCore.Mvc;
using Google.Apis.Auth;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UserController : Controller
{
    private readonly SmartHomeContext _context;

    public UserController(SmartHomeContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LoginGoogle([FromBody] GoogleLoginModel model)
    {
        var client = new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = ["80156721446-94fndvq99j91bmmd4327rn23kh3g5ci0.apps.googleusercontent.com"]
        };

        var payload = await GoogleJsonWebSignature.ValidateAsync(model.IdToken, client);

        var googleId = payload.Subject;
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.GoogleId == googleId);

        if (existingUser == null)
        {
            var newUser = new User
            {
                GoogleId = googleId,
                Email = payload.Email,
                Name = payload.Name
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            existingUser = newUser;
        }

        HttpContext.Session.SetString("UserId", existingUser.GoogleId);
        HttpContext.Session.SetString("UserName", existingUser.Name);
        HttpContext.Session.SetString("UserEmail", existingUser.Email);
        HttpContext.Session.SetInt32("UserDbId", existingUser.UserID);

        return Ok();
    }

    [HttpPost]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Ok();
    }
}
