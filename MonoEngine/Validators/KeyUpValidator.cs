using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoEngine.Validators
{
    public class KeyUpValidator<T> : IConditionValidator<T>
    {
        private Keys key;

        public T TargetState { get; private set; }

        public KeyUpValidator(Keys key, T state)
        {
            this.key = key;
            this.TargetState = state;
        }

        public bool ConditionMeet(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();
            return keyboard.IsKeyUp(this.key);
        }
    }
}
