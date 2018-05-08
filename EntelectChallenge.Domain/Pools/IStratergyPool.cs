using EntelectChallenge.Domain.Core;

namespace EntelectChallenge.Domain.Pools
{
    public interface IStratergyPool : IPool
    {
        IStratergy GetStartergy<TStratergy>() where TStratergy : IStratergy;
    }
}
