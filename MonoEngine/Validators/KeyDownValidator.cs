using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoEngine.Validators
{
    public class KeyDownValidator<T> : IConditionValidator<T>
    {
        private Keys key;

        public T TargetState { get; private set; }

        public KeyDownValidator(Keys key, T state)
        {
            this.key = key;
            this.TargetState = state;
        }

        public bool ConditionMeet(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();
            return keyboard.IsKeyDown(this.key);
        }
    }
}
