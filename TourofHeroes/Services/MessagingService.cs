using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourOfHeroes.Services
{
    public class MessagingService: IMessagingService
    {
        
        //Public property som holder messaging
        public List<string> Messages { get; set; } = new List<string>();


        //Eventhandler
        public event EventHandler<List<string>> OnMessageChanged;
        
        //Get: returnrerer message property, det som er i messages
        public List<string> Get() => Messages;
        
        //Publiv async task: tpls lib: task handleling i c#
        //Task som ikke returnerer noget, der an sættes type efter, Task.factory = Starter ny tråd. Tager besked liste, og returnerer messages
        //Hvis den er null, gør ikke invoke. ? => Kalded hvis der ikke er noget. 
        //Vi parser ingen objecter, men tager messaging list og adder til denne
        //Så kalder vi onmessageschanged event. 
        //? sikrer hvis nogen kalder den uden at have sat den
        //New list, add messages, clear list. Alt hvad vi skal bruge i en service
        //Sikrer os at vores state er hvor vi vil have den
        public async Task Add(string message)
        {
            await Task.Factory.StartNew(() => Messages.Add(message));
            OnMessageChanged?.Invoke(this, Messages);
        }

        public async Task Clear()
        {
            await Task.Factory.StartNew(() => Messages.Clear());
            OnMessageChanged?.Invoke(this, Messages);
        }
    }
}
