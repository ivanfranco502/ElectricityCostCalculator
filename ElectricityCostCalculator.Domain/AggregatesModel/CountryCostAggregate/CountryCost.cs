using System;
using ElectricityCostCalculator.Domain.SeedWork;
using System.Collections.Generic;
using System.Linq;

namespace ElectricityCostCalculator.Domain.AggregatesModel.CountryCostAggregate
{
    public class CountryCost : IAggregateRoot
    {
        private readonly HashSet<IEnergy> _availableEnergies;
        private decimal _remainedElectricity;
        public decimal TotalElectricity { get; }

        public decimal WindSupply { get; }
        public decimal NaturalGasCost { get; }

        public IReadOnlySet<IEnergy> AvailableEnergies => _availableEnergies;

        public CountryCost(long totalElectricity, decimal windSupply, decimal naturalGasCost)
        {
            TotalElectricity = totalElectricity;
            _remainedElectricity = totalElectricity;
            WindSupply = windSupply;
            NaturalGasCost = naturalGasCost;
            _availableEnergies = new HashSet<IEnergy>();
        }

        public decimal GetForecastCost()
        {
            var cost = 0m;

            AddWindSupply(WindSupply);
            AddNuclearSupply();
            AddNaturalGasSupply(NaturalGasCost);

            cost = AvailableEnergies.Sum(e => e.GetTotalCost());
            return Math.Round(cost / TotalElectricity, 2);
        }

        private void AddNaturalGasSupply(decimal naturalGasCost)
        {
            var naturalGas = new NaturalGas(_remainedElectricity, naturalGasCost);

            _remainedElectricity -= naturalGas.Amount;

            _availableEnergies.Add(naturalGas);
        }

        private void AddNuclearSupply()
        {
            var nuclear = new Nuclear(_remainedElectricity);

            _remainedElectricity -= nuclear.Amount;

            _availableEnergies.Add(nuclear);
        }

        private void AddWindSupply(decimal windSupply)
        {
            var windSupplyNeeded = windSupply;

            if (_remainedElectricity < windSupply)
            {
                windSupplyNeeded = _remainedElectricity;
            }

            var wind = new Wind(windSupplyNeeded);

            _remainedElectricity -= wind.Amount;

            _availableEnergies.Add(wind);
        }
    }
}