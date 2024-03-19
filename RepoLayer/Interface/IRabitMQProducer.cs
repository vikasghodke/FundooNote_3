using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message);

    }
}
