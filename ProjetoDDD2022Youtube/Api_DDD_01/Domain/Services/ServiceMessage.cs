using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    internal class ServiceMessage : IServiceMessage
    {
        private readonly IMessage _iMessagge;

        public ServiceMessage(IMessage iMessagge)
        {
            _iMessagge = iMessagge;
        }
    }
}
