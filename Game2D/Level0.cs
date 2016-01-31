using MonoEngine.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2D
{
    class Level_0 : GameLevel<int>
    {
        public Level_0(Game1 game)
            : base(game)
        {
            this.Scenes.Add(new Scene(game, new Microsoft.Xna.Framework.Vector2(800, 480)));
        }
    }
}
