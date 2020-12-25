using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public interface IEmailSender // don't forget the public modifier
    {

        void Send(string toAddress, string subject, string body, bool sendAsync = true);

    }
}
