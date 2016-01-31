using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonoEngine.Components
{
    public abstract class GameSession<T> : Scheduling.IPlayable<T>
    {
        protected GraphicsDevice GraphicsDevice;
        protected Game Game;
        private SemaphoreSlim semaphore = new SemaphoreSlim(0, 1);
        private T result;
        
        public GameSession(Game game)
        {
            this.GraphicsDevice = game.GraphicsDevice;
            this.Game = game;
        }

        public virtual void LoadResource(ContentManager content)
        {
        }

        public virtual void UnloadResource()
        {
        }

        public async Task<T> WaitAsync()
        {
            await semaphore.WaitAsync();
            return result;
        }

        protected void EndSession(T result)
        {
            this.result = result;
            this.semaphore.Release();
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);

        public void Dispose()
        {
            this.UnloadResource();
        }
    }
}
