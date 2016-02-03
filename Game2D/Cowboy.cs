using Microsoft.Xna.Framework.Graphics;
using MonoEngine.Components;
using MonoEngine.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;
using MonoEngine.Scheduling;
using Microsoft.Xna.Framework;

namespace Game2D
{
    class Cowboy : GameObjectAsync
    {
        [Content("Sprites/Player/Idle", ContentCategory.Shape)]
        Texture2D cowboyIdle { get; set; }

        [Content("Sprites/Player/Die", ContentCategory.Shape)]
        Texture2D cowboyDie { get; set; }

        [Content("Sprites/Player/Celebrate", ContentCategory.Shape)]
        Texture2D cowboyCelebrate { get; set; }

        [Content("Sprites/Player/Jump", ContentCategory.Shape)]
        Texture2D cowboyJump { get; set; }

        [Content("Sprites/Player/Run", ContentCategory.Shape)]
        Texture2D cowboyRun { get; set; }

        private SpriteRenderable animationIdle;
        private SpriteRenderable animationWalk;
        private SpriteRenderable animationJump;
        private SpriteRenderable animationCelebrate;
        private SpriteRenderable animationDie;

        private int x;
        private int y;

        enum State
        {
            Idle,
            Walking,
            Jumping,
            Dying,
            Died
        }

        public Cowboy(Game1 game, IGameRunner runner)
            :base(game, runner)
        {
            animationIdle = new SpriteRenderable(game, cowboyIdle, 1, 1);
            animationWalk = new SpriteRenderable(game, cowboyRun, 10, 1);
            animationJump = new SpriteRenderable(game, cowboyJump, 11, 1);
            animationCelebrate = new SpriteRenderable(game, cowboyCelebrate, 11, 1);
            animationDie = new SpriteRenderable(game, cowboyDie, 12, 1);
        }

        public async override Task Run()
        {
            State state = State.Idle;
            float x = 200.0f;
            float y = 200.0f;
            float frame = 0.0f;
            while (true)
            {
                if (state == State.Idle)
                {
                    state = await Runner.Play(animationIdle, 
                        new Runnable<State>((gameTime) => { animationIdle.origin = new Vector2(x, y); return true; }, 
                            new KeyDownValidator<State>(Keys.Left, State.Walking))
                    );
                }
                else if (state == State.Walking)
                {
                    state = await Runner.Play(animationWalk, new Runnable<State>((gameTime) => 
                    {
                        x -= 1f;
                        animationWalk.origin = new Vector2(x, y);
                        frame += 0.2f;
                        if (frame > 10.5f)
                        {
                            frame = 0.0f;
                        }
                        animationWalk.frame = (int)frame;
                        return true;
                    }, new KeyUpValidator<State>(Keys.Left, State.Idle)));
                }
            }
        }
    }
}
