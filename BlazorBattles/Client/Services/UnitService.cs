﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorBattles.Shared;
using Blazored.Toast.Services;

namespace BlazorBattles.Client.Services
{
    public class UnitService: IUnitService
    {
        private readonly IToastService _toastService;
        public UnitService(IToastService toastService)
        {
          _toastService = toastService;
          //injecter toast service, så denne kan bruges
          //use toast service som den bliver brugt i razor component, da den er injectet. SÅdan injectes toastservice i 
          //Toast service. 

        }
        public IList<Unit> Units { get; } = new List<Unit>
        {
            new Unit {Id = 1, Title = "Knight", Attach = 10, Defense = 10, BananaCost = 100},
            new Unit {Id = 2, Title = "Archer", Attach = 15, Defense = 5, BananaCost = 150},
            new Unit {Id = 3, Title = "Mage", Attach = 20, Defense = 1, BananaCost = 200}
        };

        public IList<UserUnit> MyUnits { get; set; } = new List<UserUnit>();
        public void AddUnit(int unitId)
        {
            Unit unit = Units.First(unit => unit.Id == unitId);
            MyUnits.Add(new UserUnit{UnitId= unit.Id, Hitpoints = unit.HitPoints});
            _toastService.ShowSuccess($"Your {unit.Title} has been built", "Unit Built");
        }
    }
}
