using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GloriaEvent.Messages;

namespace PaymentWorkerService
{//This is the handler that processes the message received from the queue
    public class NewOrderHandler : IHandleMessages<PaymentRequestMessage>
    {
      
        public Task Handle(PaymentRequestMessage message)
        {
            Console.WriteLine($"Payment Request received fro basketId--{message.BasketId}.");
            return Task.CompletedTask;
        }
    }
}
