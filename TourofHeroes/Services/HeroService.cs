using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TourOfHeroes.Models;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace TourOfHeroes.Services
{
    public class HeroService : IHeroService // Service implementerer IHeroservice
    {
        //Dependency injection så når vi kreaterer instans af hero service modtager vi en ny httpclient hver gang. Og tager denn og bruger i public async heroes. 
        //Så vi kan bruge dependency injection når vi creater instans af constructoren.
        private readonly HttpClient _http;

        private readonly IMessagingService _messagingService;
        private Hero[] heroes = null;

        
        public HeroService(HttpClient client, IMessagingService messagingService)
        {
            _http = client;
            _messagingService = messagingService;
        }
        
        public async Task<Hero[]> GetHeroes() //KOmmer fra interface, og retunrerer det vi havde før. 
        {
            //Hvis vi kalder heto service, kan vi se hver gang heto fetched er called
            await _messagingService.Add("Heroes Service: Heroes Fetched");
            //return await _http.GetFromJsonAsync<Hero[]>("sample-data/heroes.json"); //Returnerer data
            heroes= await _http.GetFromJsonAsync<Hero[]>("sample-data/heroes.json");
            return heroes;
        }

        public async Task<Hero[]> Add(string HeroName)
        {
            var heroList = new List<Hero>(heroes);
            var sortIndexes = heroList.OrderByDescending(x => x.Id);
            var currentIndex = sortIndexes.First().Id;
            var newHero = new Hero() {Name = HeroName, Id = ++currentIndex};
            heroList.Add(newHero);
            heroes = await Task.Factory.StartNew(() => heroList.ToArray());
            return heroes;
        }

        public async Task<Hero[]> Delete(Hero hero)
        {
            heroes = await Task.Factory.StartNew(() => heroes.Where(x => x != hero).ToArray()); 
             //Alle de heroes som ikke er den hero vi bruger, bliver sat til ny array
            return heroes;

            //"Where" er LINQ!
        }


        public Hero[] Search(string text)
        {
            return heroes.Where(x => x.Name.ToLower().Contains(text.Trim().ToLower())).ToArray();
        }


    }
}

//Service så vi kan pull information ind i component