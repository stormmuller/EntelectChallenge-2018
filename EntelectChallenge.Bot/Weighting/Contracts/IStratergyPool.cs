namespace StarterBot.Weighting.Contracts
{
    public interface IStratergyPool
    {
        IWeightingStratergy GetStartergy<TStratergy>() where TStratergy : IWeightingStratergy;
    }
}
