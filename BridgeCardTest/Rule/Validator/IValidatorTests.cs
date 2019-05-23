using BridgeCard.Rule.Validator;

namespace BridgeCardTest.Rule.Validator
{
    public interface IValidatorTests
    {
        IValidator Validator { get;}

        void ShouldValidateSatisfy();
    
        void ShouldValidateNotSatisfy();

        void ShouldCalculateCorrectPints();
    }
}