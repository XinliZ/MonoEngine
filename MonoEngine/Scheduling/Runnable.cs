using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Threading;
using MonoEngine.Graphics;
using MonoEngine.Validators;

namespace MonoEngine.Scheduling
{
    public class Runnable<T> : IRunnable<T>
    {
        private SemaphoreSlim semaphore = new SemaphoreSlim(0, 1);

        private Func<GameTime, bool> action;
        private IConditionValidator<T>[] validators;
        private T result;

        public Runnable(Func<GameTime, bool> action, params IConditionValidator<T>[] validators)
        {
            this.action = action;
            this.validators = validators;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!action(gameTime))
            {
                //result = next state
                result = default(T);
                semaphore.Release();
            }
            else
            {
                var validator = checkValidators(validators, gameTime);
                if (validator != null)
                {
                    result = validator.TargetState;
                    semaphore.Release();
                }
            }
        }

        private IConditionValidator<T> checkValidators(IConditionValidator<T>[] validators, GameTime gameTime)
        {
            foreach (var validator in validators)
            {
                if (validator.ConditionMeet(gameTime))
                {
                    return validator;
                }
            }
            return null;
        }

        public async Task<T> WaitAsync()
        {
            await semaphore.WaitAsync();
            return result;
        }
    }
}
