using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine.Graphics;
using MonoEngine.Scheduling;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoEngine.Components
{
    public class GameRunner<T> : GameSession<T>, IGameRunner
    {
        public List<SceneBase> Scenes = new List<SceneBase>();

        public List<IRunnable> runnableList = new List<IRunnable>();
        public List<IRenderable> renderableList = new List<IRenderable>();
        private RenderService renderService;

        public GameRunner(Game game, Vector2 baseScreenSize, params SceneBase[] scenes)
            : base(game)
        {
            this.Scenes.AddRange(scenes);
            this.renderService = new RenderService(game.GraphicsDevice, new SpriteBatch(game.GraphicsDevice), baseScreenSize);
        }

        //public static GameRunner<object> CreateLevelFromScene(Game game, SceneBase scene)
        //{
        //    return new GameRunner<object>(game, null, scene);
        //}

        public override void Update(GameTime gameTime)
        {
            foreach (var runnable in this.runnableList)
            {
                runnable.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            this.renderService.BeginDraw();
            foreach(var renderable in this.renderableList)
            {
                renderable.Draw(this.renderService, gameTime);
            }
            this.renderService.EndDraw();
        }

        public async Task<Ty> Play<Ty>(IRenderable renderable, IRunnable<Ty> runnable)
        {
            this.runnableList.Add(runnable);
            this.renderableList.Add(renderable);
            Ty result = await runnable.WaitAsync();
            this.runnableList.Remove(runnable);
            this.renderableList.Remove(renderable);
            return result;
        }
    }
}
