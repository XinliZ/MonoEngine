using MonoEngine.Components;
using MonoEngine.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2D
{
    class Level_0 : GameRunner<int>
    {
        public Level_0(Game1 game)
            : base(game, new Microsoft.Xna.Framework.Vector2(800, 480))
        {
            this.Scenes.Add(new Scene(game, new Microsoft.Xna.Framework.Vector2(800, 480)));
            Run(game);
        }

        private async Task Run(Game1 game)
        {
            this.Play<object>(new Background(game), new ForeverRunnable());

            var cowboy = new Cowboy(game, this);
            await cowboy.Run();
        }
    }
}
