using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoEngine.Components
{
    // The scene here is a container to organize the resources. Ever scene will contain some resources
    // specific to this scene, and could be unloaded in next scene. It is totally ok to have only one scene
    // if all the resources of current level could fit in the memory.
    public abstract class SceneBase
    {
        private RenderService renderService;

        // TODO: Need the content properties support

        public SceneBase(Game game, Vector2 baseScreenSize)
        {
            
        }

        public abstract void LoadResource(ContentManager contentManager);

        public abstract void UnloadResource();
    }
}
