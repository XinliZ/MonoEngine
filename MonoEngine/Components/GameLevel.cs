using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoEngine.Components
{
    public class GameLevel<T> : GameSession<T>
    {
        public List<SceneEngine> Scenes = new List<SceneEngine>();

        public GameLevel(Game game)
            : base(game)
        {
        }

        public GameLevel(Game game, params SceneEngine[] scenes)
            : base(game)
        {
            this.Scenes.AddRange(scenes);
        }

        public static GameLevel<object> CreateLevelFromScene(Game game, SceneEngine scene)
        {
            return new GameLevel<object>(game, scene);
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
