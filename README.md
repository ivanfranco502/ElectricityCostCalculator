# ElectricityCostCalculator
Calculator for the real cost of generating electricity for a country. 
---
For now, we will only consider the supply that comes from wind, nuclear and natural gas, but we expect to include more sources like sun, hydroelectric, geothermal, other fossil fuels.
For wind energy, we will pay `61,1 €/MWh` when the wind speed is good and `75,3 €/MWh` when it’s not enough to compensate for the investment.
The wind has a total generation capacity of `100 GWh`. We know that wind speed is good when the system can generate more than `40%` of its full generation capacity.
Nuclear power has a fixed price of `56.1 €/MWh`, but its production capacity is limited to `30 GWh` as it cannot be adjusted to demand.
Fossil fuels can produce as much electricity as required, but their costs depend on the raw material price. It has a linear price of `1.2` for its MWh equivalent.
For instance, if the natural gas it’s priced at `42,0 €/MWh`, generated electricity will cost `50,4 €/MWh`.

At a given point in time of winter, we are forecasting a generation need of `135 GWh`. 
- Due to wind conditions, this energy will be able to supply `70 GWh`.
- As we know, nuclear power production it’s fixed at `30 GWh`. 
- Fossil fuels will generate the remaining `35 GWh` with a natural gas cost of `67.2 €/MWh`.

What will be the selling cost of an MWh?

```
● Wind: 70.000 Mwh * 61.1 €/MWh = 4.277.000 €
● Nuclear power: 30.000 * 56,1 €/MWh = 1.683.000 €
● Fossil fuels: 35.000 * 67,2 €/MWh = 2.352.000 €
```

So in these conditions, the cost per `KWh`will be `8,312,000 / 135000 = 61.57 €/MWh`

## Considerations
- All the values are considered as `MWh`.
- It was included the infrastructure layer just for the purpose of showing all the layers in a DDD-architecture. However, for the sake of clarity of this exercise I didn't find useful to add DB-related classes, that is the main reason why is empty.
- For the energies that have a production capactity, if the needed amount is more than this limitation we will reduce the amount to the limit value.
- I think there is an error in the example for Fossil Fuels, it is taking the electricty cost as the natural gas cost (where should be multiplied by 1.2).
- To keep simple the code, I didn't include the Command and Queries separation or use a Mediator pattern.