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
    public class Scene2D : SceneEngine
    {
        public Scene2D(Game game, Vector2 baseScreenSize)
            : base(game, baseScreenSize)
        {
        }


        public override void Draw(IRenderService renderService, GameTime gameTime)
        {
            // Do nothing. Scene doesn't need to draw it's self
        }
    }
}
