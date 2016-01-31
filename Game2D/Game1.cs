using MonoEngine.Components;

namespace Game2D
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : MonoEngine.Game
    {
        public override async void RunGame()
        {
            using (var splashScreen = new SplashScreen(this, 3))
            {
                splashScreen.LoadResource(Content);
                await this.Play(splashScreen);
            }

            using (var level = new Level_0(this))
            {
                level.LoadResource(Content);
                await this.Play(level);
            }
        }
    }
}
