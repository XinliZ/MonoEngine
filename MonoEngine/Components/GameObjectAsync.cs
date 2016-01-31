using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoEngine.Graphics;
using System.Threading;
using Microsoft.Xna.Framework.Input;

namespace MonoEngine.Components
{
    public abstract class GameObjectAsync : GameObject
    {
        private Animation animation;
        private SemaphoreSlim semaphore = new SemaphoreSlim(0, 1);
        private float duration;
        private TimeSpan elapsedTime = TimeSpan.Zero;
        private Keys[] triggerKeys;
        private Keys currentKey;
        private bool onRelease;

        public GameObjectAsync(Game game)
            : base(game)
        {

        }

        public abstract Task Run();

        public async Task Play(Animation ani, float duration)
        {
            this.duration = duration;
            elapsedTime = TimeSpan.Zero;
            this.triggerKeys = null;
            this.animation = ani;
            await this.semaphore.WaitAsync();
            this.animation = null;
        }

        public async Task<Keys> Play(Animation ani, Keys[] keys)
        {
            this.duration = 0;
            this.triggerKeys = keys;
            this.onRelease = false;
            this.animation = ani;
            await this.semaphore.WaitAsync();
            this.animation = null;
            return currentKey;
        }

        public async Task<Keys> PlayUntil(Animation ani, Keys[] keys)
        {
            this.duration = 0;
            this.triggerKeys = keys;
            this.onRelease = true;
            this.animation = ani;
            await this.semaphore.WaitAsync();
            this.animation = null;
            return currentKey;
        }

        protected void EndPlay()
        {
            this.semaphore.Release();
        }

        public override void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            if (duration > 0 && elapsedTime.TotalMilliseconds > duration)
            {
                EndPlay();
                elapsedTime = TimeSpan.Zero;
            }
            else if (triggerKeys != null)
            {
                var keyboardState = Keyboard.GetState();
                foreach (var key in this.triggerKeys)
                {
                    if (!onRelease && keyboardState.IsKeyDown(key))
                    {
                        this.currentKey = key;
                        EndPlay();
                        this.triggerKeys = null;
                    }
                    else if (onRelease && !keyboardState.IsKeyDown(key))
                    {
                        this.currentKey = key;
                        EndPlay();
                        this.triggerKeys = null;
                    }
                }
            }
            if (animation != null)
            {
                if (!animation.Update(gameTime))
                {
                    EndPlay();
                    this.duration = 0;
                    this.triggerKeys = null;
                }
            }
        }

        public override void Draw(IRenderService renderService, GameTime gameTime)
        {
            if (animation != null)
            {
                animation.Draw(renderService, gameTime, 200, 300);      // TODO: Remove the hard code numbers
            }
        }
    }
}
