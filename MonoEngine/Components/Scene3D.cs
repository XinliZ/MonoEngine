using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoEngine.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoEngine.Components
{
    public class Scene3D : SceneBase
    {
        public Scene3D(Game game, Vector2 baseScreenSize)
            : base(game, baseScreenSize)
        {

        }

        public override void LoadResource(ContentManager contentManager)
        {
            throw new NotImplementedException();
        }

        public override void UnloadResource()
        {
            throw new NotImplementedException();
        }
    }
}
