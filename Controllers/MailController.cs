using ASPCore2.Models;
using ASPCore2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPCore2.Controllers
{
    [Route("api/[controller]")]
    public class MailController : Controller
    {
        private readonly IMailService _mailService;
        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }
        [HttpGet, Route("getfolder")]
        public Folder Get(string folder)
        {
            return _mailService.GetMailByFolder(folder);
        }
        [HttpGet("{mailId:int}"), Route("getmail")]
        public Mail Get(int mailId)
        {
            return _mailService.GetMail(mailId);
        }
    }
}