using Microsoft.Xna.Framework;

namespace MonoEngine.Validators
{
    public interface IConditionValidator<T>
    {
        bool ConditionMeet(GameTime gameTime);
        T TargetState { get; }
    }
}
