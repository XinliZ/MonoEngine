using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoEngine.Components
{
    public abstract class SceneEngine : GameObject
    {
        private RenderService renderService;

        public SceneEngine(Game game, Vector2 baseScreenSize)
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
    }
}
