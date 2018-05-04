namespace StarterBot.Weighting.Startergies
{
    using System;
    using StarterBot.Entities.Bot;
    using StarterBot.Enums;

    public class AttackEnemyBuildingsStratergy : IWeightingStratergy
    {
        public Weight CalculateWeight(GameStateAdaptor gameState, Weight weight)
        {
            return weight;
        }
    }
}
