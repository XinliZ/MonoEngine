using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoEngine.Graphics
{
    internal class RenderService : IRenderService
    {
        public SpriteBatch SpriteBatch { get; private set; }
        public GraphicsDevice GraphicsDevice { get; private set; }
        public Rectangle ViewPortRectangle { get; private set; }

        private Matrix globalTransformation;

        // TODO: Need to be updated on display model changes
        public RenderService(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Vector2 baseScreenSize)
        {
            this.SpriteBatch = spriteBatch;
            this.GraphicsDevice = graphicsDevice;
            this.ViewPortRectangle = new Rectangle(0, 0, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight);

            this.globalTransformation = Matrix.CreateScale(new Vector3(
                GraphicsDevice.PresentationParameters.BackBufferWidth / baseScreenSize.X,
                GraphicsDevice.PresentationParameters.BackBufferHeight / baseScreenSize.Y,
                1
                ));
        }

        public void BeginDraw()
        {
            this.SpriteBatch.Begin(transformMatrix: globalTransformation);
        }

        public void EndDraw()
        {
            this.SpriteBatch.End();
        }

        public void Dispose()
        {
            SpriteBatch.Dispose();
            GraphicsDevice.Dispose();
        }
    }
}
