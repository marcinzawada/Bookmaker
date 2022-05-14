using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Services;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Infrastructure.Services;

public class EmailSenderService : IEmailSenderService
{
    private readonly SendGridClient _mailClient;
    private readonly EmailAddress _emailFrom;

    public EmailSenderService(IConfiguration configuration)

    {
        var apiKey = configuration.GetSection("SendGridApiKey").Value;
        _mailClient = new SendGridClient(apiKey);
        _emailFrom = new EmailAddress("advancedsubscriber@gmail.com", "BetGame");
    }

    public async Task SendResetPasswordEmail(string email, string userName, string token)
    {
        var subject = "BetGame - zresetuj swoje hasło";
        var to = new EmailAddress(email, userName);

        var plainTextContent =
            "Zresetuj swoje hasło. " +
            "Wpisz podany link do przeglądarki.\n" +
            $"https://betgame.azurewebsites.net/change-password?token={token} \n" +
            "Jeżeli nie chciałeś resetować hasła to zignoruj ten email.";

        var msg = MailHelper.CreateSingleEmail(_emailFrom, to, subject, plainTextContent, plainTextContent);
        var response = await _mailClient.SendEmailAsync(msg);
    }

}
