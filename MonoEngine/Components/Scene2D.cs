using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoEngine.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace MonoEngine.Components
{
    public class Scene2D : GameObject
    {
        private RenderService renderService;

        public Scene2D(Game game, Vector2 baseScreenSize)
            : base(game)
        {
            this.renderService = new RenderService(game.GraphicsDevice, new SpriteBatch(game.GraphicsDevice), baseScreenSize);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var child in this.Children)
            {
                child.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime)
        {
            renderService.BeginDraw();
            foreach (var child in this.Children)
            {
                child.Draw(renderService, gameTime);
            }
            renderService.EndDraw();
        }

        public override void Draw(IRenderService renderService, GameTime gameTime)
        {
            // Do nothing. Scene doesn't need to draw it's self
        }
    }
}
