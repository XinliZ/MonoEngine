using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoEngine.Graphics;

namespace MonoEngine.Graphics
{
    public class Animation
    {
        private Texture2D texture;
        private int frameCount;
        private int frame = 0;
        private Rectangle sourceRect;

        private int width;
        private int height;

        private int repeatX;
        private int repeatY;
        private float frameTime;
        private bool repeat;

        private TimeSpan elapsedTime = TimeSpan.Zero;

        public Animation(Texture2D texture, int repeatX, int repeatY, float frameTime, bool repeat)
        {
            this.frameCount = repeatX * repeatY;
            this.texture = texture;
            this.repeatX = repeatX;
            this.repeatY = repeatY;
            this.frameTime = frameTime;
            this.width = texture.Width / repeatX;
            this.height = texture.Height / repeatY;
            this.repeat = repeat;
        }

        public void Reset()
        {
            this.frame = 0;
            this.elapsedTime = TimeSpan.Zero;
        }

        public bool Update(GameTime gameTime)
        {
            bool isEnded = false;
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime.TotalMilliseconds > frameTime)
            {
                frame++;
                elapsedTime = TimeSpan.Zero;
                if (frame >= frameCount)
                {
                    if (repeat)
                    {
                        frame = 0;
                    }
                    else {
                        frame = frameCount - 1;
                        isEnded = true;
                    }
                }
            }
            sourceRect = new Rectangle((frame % repeatX) * width, (frame / repeatX) * height, width, height);
            return !isEnded;
        }

        public void Draw(IRenderService renderService, GameTime gameTime, int x, int y)
        {
            renderService.SpriteBatch.Draw(texture, new Vector2(x, y), sourceRect, Color.White);
        }
    }
}
