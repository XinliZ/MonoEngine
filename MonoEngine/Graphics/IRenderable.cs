using Microsoft.Xna.Framework;

namespace MonoEngine.Graphics
{
    public interface IRenderable
    {
        void Draw(IRenderService renderService, GameTime gameTime);
    }
}
