using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoEngine.Components
{
    public abstract class GameLevel<T> : GameSession<T>
    {
        public List<Scene2D> Scenes = new List<Scene2D>();

        public GameLevel(Game game)
            : base(game)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Scenes[0].Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Scenes[0].Draw(gameTime);
        }
    }
}
