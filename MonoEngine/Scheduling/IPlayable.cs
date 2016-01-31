using Microsoft.Xna.Framework;
using System;
using System.Threading.Tasks;

namespace MonoEngine.Scheduling
{
    internal interface IPlayable : IDisposable
    {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }

    internal interface IPlayable<T> : IPlayable
    {
        Task<T> WaitAsync();
    }
}
