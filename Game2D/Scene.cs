using Microsoft.Xna.Framework;

namespace Game2D
{
    class Scene : MonoEngine.Components.Scene2D
    {
        public Scene(Game1 game, Vector2 baseScreenSize)
            : base(game, baseScreenSize)
        {
            //var background = new Background(game);
            //this.Add(background);

            //var cowboy = new Cowboy(game);
            //this.Add(cowboy);

            //var task = cowboy.Run();
        }
    }
}
