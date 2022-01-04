using ActionMailer.Net.Mvc;
using BlogAspnetCursombanagouro.Models.FormModel;
using System;

namespace BlogAspnetCursombanagouro.Controllers
{
    public class MailerController : MailerBase
    {
        public EmailResult Contact(ContactFormModel model)
        {
            From = String.Format("{0} <{1}>", model.Name, model.Email);
            // From = "Daniel Matias da Silva <head.dev.gg@gmail.com>";
            To.Add("head.dev.gg@gmail.com");
            Subject = "Contato via blog";

            return Email("Contact", model);
        }
    }
}