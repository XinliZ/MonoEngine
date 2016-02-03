using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoEngine.Scheduling
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

        public bool ConditionMeet()
        {
            var keyboard = Keyboard.GetState();
            return keyboard.IsKeyDown(this.key);
        }
    }
}
