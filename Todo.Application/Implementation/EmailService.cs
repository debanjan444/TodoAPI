using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Constants;
using Todo.Application.Contracts;

namespace Todo.Application.Implementation
{
    public class EmailService(IHttpClientFactory clientFactory) : IEmailService
    {

        public async Task<bool> SendMailAsync(string recipient)
        {
            using var httpClient =
                clientFactory.CreateClient(
                    ApplicationConstants.EmailServiceClient);

            var response =
                await httpClient.GetAsync(
                    $"/email/send?recipient={recipient}");

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
