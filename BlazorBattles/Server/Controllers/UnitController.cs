﻿using BlazorBattles.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Controllers
{
    [Route("api/[controller]")] 
    [ApiController] //Attribut indikerer serve http api responses
    public class UnitController : ControllerBase
    {
        //Liste af units, så de kan flyttes fra unit service (kopieret)
        public IList<Unit> Units { get; } = new List<Unit>
        {
            new Unit {Id = 1, Title = "Knight", Attach = 10, Defense = 10, BananaCost = 100},
            new Unit {Id = 2, Title = "Archer", Attach = 15, Defense = 5, BananaCost = 150},
            new Unit {Id = 3, Title = "Mage", Attach = 20, Defense = 1, BananaCost = 200}
        };
        
        [HttpGet]
        public IActionResult GetUnits()
        {
            return Ok(Units);
        }
    }
}