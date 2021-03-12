using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourOfHeroes.Models;

namespace TourOfHeroes.Services
{
   public interface IHeroService
    {
        Task<Hero[]> GetHeroes();
        //Hero model som array. Og thrading

        Task<Hero[]> Add(string HeroName);
        Task<Hero[]> Delete(Hero hero);

        Hero[] Search(string text);
    }
}
