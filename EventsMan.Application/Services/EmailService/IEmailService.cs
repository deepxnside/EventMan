using EventsMan.Application.Common.Models;

namespace EventsMan.Application.Services.EmailService;

public interface IEmailService
{
   Task<bool> SendEmail(Email email);
}