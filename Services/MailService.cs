using ASPCore2.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace ASPCore2.Services
{
    public interface IMailService
    {
        Folder GetMailByFolder(string folder);
        Mail GetMail(int id);
    }

    public class MailService : IMailService
    {
        IHostingEnvironment _env;
        WebMail webMail;
        public MailService(IHostingEnvironment env)
        {
            _env = env;
            webMail = LoadMail();
        }

        private WebMail LoadMail()
        {
            var data = File.ReadAllText(Path.Combine(_env.ContentRootPath, "Data", "webmail.json"));
            return JsonConvert.DeserializeObject<WebMail>(data);
        }

        public Mail GetMail(int id)
        {
            var mailItems = webMail.Folders.SelectMany(f => f.Mails);
            return mailItems.Single(m => m.Id == id);
        }

        public Folder GetMailByFolder(string folder)
        {
            return webMail.Folders.First(f => f.Id == folder);
        }
    }
}