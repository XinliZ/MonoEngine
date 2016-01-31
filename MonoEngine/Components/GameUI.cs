using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoEngine.Components
{
    public abstract class GameUI<T> : GameSession<T>
    {
        public GameUI(Game game)
            :base(game)
        {

        }
    }
}
