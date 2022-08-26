using System;
using aspnetrun_microservice.Frameworks.Entities.Emails;

namespace aspnetrun_microservice.Frameworks.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }


}

