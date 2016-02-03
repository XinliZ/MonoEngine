using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoEngine.Validators
{
    public class TimingValidator<T> : IConditionValidator<T>
    {
        public T TargetState { get; private set; }
        private TimeSpan duration;
        private TimeSpan elapsedTime = TimeSpan.Zero;

        public TimingValidator(TimeSpan duration, T state)
        {
            this.duration = duration;
            this.TargetState = state;
        }

        public bool ConditionMeet(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            return elapsedTime > duration;
        }
    }
}
