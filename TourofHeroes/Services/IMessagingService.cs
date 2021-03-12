using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourOfHeroes.Services
{
    public interface IMessagingService
    {
        Task Add(string Message);
        Task Clear();
        List<string> Get();

        //Crazy, event handler som returnrerer en liste af beskeder, når messaging ændres
        event EventHandler<List<string>> OnMessageChanged;
    }
}
