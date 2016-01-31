using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoEngine.Graphics
{
    public interface IRenderService : IDisposable
    {
        SpriteBatch SpriteBatch { get; }
        GraphicsDevice GraphicsDevice { get; }
        Rectangle ViewPortRectangle { get; }
    }
}
