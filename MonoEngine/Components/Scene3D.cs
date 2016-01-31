using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoEngine.Graphics;

namespace MonoEngine.Components
{
    public class Scene3D : GameObject
    {
        public Scene3D(Game game)
            : base(game)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var child in this.Children)
            {
                child.Update(gameTime);
            }
        }

        public override void Draw(IRenderService renderService, GameTime gameTime)
        {
            foreach (var child in this.Children)
            {
                child.Draw(renderService, gameTime);
            }
        }
    }
}
