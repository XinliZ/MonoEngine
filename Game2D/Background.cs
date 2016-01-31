using Microsoft.Xna.Framework.Graphics;
using MonoEngine.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoEngine.Graphics;

namespace Game2D
{
    class Background : GameObject
    {
        [Content("Backgrounds/Layer0_0", ContentCategory.Background)]
        public Texture2D BackgroundLayer0 { get; set; }
        [Content("Backgrounds/Layer1_0", ContentCategory.Background)]
        public Texture2D BackgroundLayer1 { get; set; }
        [Content("Backgrounds/Layer2_0", ContentCategory.Background)]
        public Texture2D BackgroundLayer2 { get; set; }

        public Background(Game1 game)
            :base(game)
        {

        }

        public override void Update(GameTime gameTime)
        {
            // Nothing to update for background
        }

        public override void Draw(IRenderService renderService, GameTime gameTime)
        {
            renderService.SpriteBatch.Draw(BackgroundLayer0, Vector2.Zero, Color.White);
            renderService.SpriteBatch.Draw(BackgroundLayer1, Vector2.Zero, Color.White);
            renderService.SpriteBatch.Draw(BackgroundLayer2, Vector2.Zero, Color.White);
        }
    }
}
