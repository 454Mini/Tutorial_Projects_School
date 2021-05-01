﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorBattles.Shared;
using Blazored.Toast.Services;

namespace BlazorBattles.Client.Services
{
    public class UnitService: IUnitService
    {
        private readonly IToastService _toastService;
        private readonly HttpClient _http;
        public UnitService(IToastService toastService, HttpClient http)
        {
          _toastService = toastService;
          _http = http;
        }


        public IList<Unit> Units { get; set; } = new List<Unit>();

        public IList<UserUnit> MyUnits { get; set; } = new List<UserUnit>();
        public void AddUnit(int unitId)
        {
            Unit unit = Units.First(unit => unit.Id == unitId);
            MyUnits.Add(new UserUnit{UnitId= unit.Id, Hitpoints = unit.HitPoints});
            _toastService.ShowSuccess($"Your {unit.Title} has been built", "Unit Built");
        }

        public async Task LoadUnitsAsync()
        {
            if (Units.Count == 0)
            {
                Units = await _http.GetFromJsonAsync<IList<Unit>>("api/unit");
            }
        }
    }
}
