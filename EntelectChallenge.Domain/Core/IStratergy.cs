using EntelectChallenge.Domain.Entities;

namespace EntelectChallenge.Domain.Core
{
    public interface IStratergy
    {
        Weight CalculateWeight(Weight weight);
    }
}
