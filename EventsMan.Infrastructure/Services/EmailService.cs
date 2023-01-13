using System.Net;
using EventsMan.Application.Common.Models;
using EventsMan.Application.Services.EmailService;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EventsMan.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IOptions<EmailSettings> _mailSettings;
    public EmailSettings _emailSettings { get; }

    public EmailService(IOptions<EmailSettings> mailSettings)
    {
        _mailSettings = mailSettings;
    }
    public async Task<bool> SendEmail(Email mail)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);
        var subkect = mail.Subject;
        var to = new EmailAddress(mail.To);
        var body = mail.Body;

        var from = new EmailAddress
        {
            Name = _emailSettings.FromAddress,
            Email = _emailSettings.FromName
        };

        var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subkect, body, body);
        var response = await client.SendEmailAsync(sendGridMessage);

        if (response.StatusCode is HttpStatusCode.Accepted or HttpStatusCode.OK)
        {
            return true;
        }

        return false;
    }
}