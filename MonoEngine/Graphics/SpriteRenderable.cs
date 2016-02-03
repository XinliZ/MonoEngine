using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoEngine.Graphics
{
    public class SpriteRenderable : Renderable
    {
        private int width;
        private int height;
        private int frameWidth;
        private int frameHeight;
        private int repeatX;
        private int repeatY;

        private Texture2D texture;

        public Vector2 origin { get; set; }
        //public Vector2 scale { get; set; }
        public int frame { get; set; }

        public SpriteRenderable(Game game, Texture2D texture, int repeatX, int repeatY)
            : base(game)
        {
            this.texture = texture;
            this.width = texture.Width;
            this.height = texture.Height;
            this.frameWidth = texture.Width / repeatX;
            this.frameHeight = texture.Height / repeatY;
            this.repeatX = repeatX;
            this.repeatY = repeatY;
        }

        public override void Draw(IRenderService renderService, GameTime gameTime)
        {
            if (frame >= repeatX * repeatY) frame = 0;

            int x = frame % this.repeatX;
            int y = frame / this.repeatX;
            var sourceRectangle = new Rectangle(x * this.frameWidth, y * this.frameHeight, this.frameWidth, this.frameHeight);
            renderService.SpriteBatch.Draw(texture, origin, sourceRectangle, Color.White);
        }
    }
}
