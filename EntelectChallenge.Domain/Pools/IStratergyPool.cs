namespace EntelectChallenge.Domain.Core.Pools
{
    public interface IStratergyPool : IPool
    {
        IWeightingStratergy GetStartergy<TStratergy>() where TStratergy : IWeightingStratergy;
    }
}
