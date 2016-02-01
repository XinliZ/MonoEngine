using Microsoft.Xna.Framework.Graphics;
using MonoEngine.Components;
using MonoEngine.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;

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

        private Animation animationIdle;
        private Animation animationRun;
        private Animation animationJump;
        private Animation animationCelebrate;
        private Animation animationDie;

        private int x;
        private int y;

        public Cowboy(Game1 game)
            :base(game)
        {
            animationIdle = new Animation(cowboyIdle, 1, 1, 1000, true);
            animationRun = new Animation(cowboyRun, 10, 1, 50, true);
            animationJump = new Animation(cowboyJump, 11, 1, 50, false);
            animationCelebrate = new Animation(cowboyCelebrate, 11, 1, 50, false);
            animationDie = new Animation(cowboyDie, 12, 1, 50, false);
        }

        public async override Task Run()
        {
            while (true)
            {
                var keyEvent = await Play(animationIdle, new Keys[] { Keys.Left, Keys.Right, Keys.Space, Keys.K });
                if (keyEvent == Keys.Space)
                {
                    await Play(animationJump, 1000);
                    animationJump.Reset();
                }
                else if (keyEvent == Keys.Left)
                {
                    keyEvent = await PlayUntil(animationRun, new Keys[] { Keys.Left });
                }
                else if (keyEvent == Keys.K)
                {
                    await Play(animationDie, 2000);
                    animationDie.Reset();
                    return;
                }

            }
        }
    }
}
