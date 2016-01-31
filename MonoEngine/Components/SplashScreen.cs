using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoEngine.Components
{
    public class SplashScreen : GameSession<object>
    {
        Texture2D texture;
        Texture2D overlayTexture;
        GraphicsDeviceManager graphics;
        int i = 0;
        int delta = 2;

        public SplashScreen(Game game, int minimiumDurationSeconds = 0)
            : base(game)
        {
            graphics = game.graphics;
        }

        public override void LoadResource(ContentManager content)
        {
            this.texture = content.Load<Texture2D>("Logo");
            this.overlayTexture = new Texture2D(this.GraphicsDevice, 5, 5, false, SurfaceFormat.Color);
            Color[] color = new Color[25];
            for (int i = 0; i < color.Length; i++)
            {
                color[i] = Color.White;
            }
            this.overlayTexture.SetData(color);
        }

        public override void UnloadResource()
        {
            Utils.SafeDispose(this.texture);
            Utils.SafeDispose(this.overlayTexture);
        }

        public override void Update(GameTime gameTime)
        {
            i += delta;
            if (i > 110) delta = -delta * 2;


            if (i < 0)
            {
                this.EndSession(null);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            spriteBatch.Begin();
            spriteBatch.Draw(this.texture, new Vector2(0f, 0f), new Color(Color.White, 0.01f * i));
            spriteBatch.Draw(this.overlayTexture, new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), new Color(Color.Black, 1 - 0.01f * i));
            spriteBatch.End();
        }
    }
}
