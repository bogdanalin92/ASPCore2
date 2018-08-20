using ASPCore2.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ASPCore2.Pages
{
    public class GreetingModel : PageModel
    {
        private IGreeter _greeter;
        public string CurrentGreeting { get; set;}
        public GreetingModel(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public void OnGet()
        {
            CurrentGreeting = $"{_greeter.GetMessageOfTheDay()}";
        }
        public void OnGet(string name)
        {
            CurrentGreeting = $"{name}:  {_greeter.GetMessageOfTheDay()}";
        }
    }
}