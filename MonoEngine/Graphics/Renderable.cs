using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Reflection;
using MonoEngine.Components;

namespace MonoEngine.Graphics
{
    public abstract class Renderable : IRenderable
    {
        public Renderable(Game game)
        {
            this.LoadContent(game.Content);
        }

        public void LoadContent(ContentManager contentManager)
        {
            var properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where((propertyInfo) => {
                    return propertyInfo.GetCustomAttribute<ContentAttribute>() != null;
                });
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<ContentAttribute>();
                var genericMethod = contentManager.GetType().GetMethod("Load").MakeGenericMethod(property.PropertyType);
                property.SetValue(this, genericMethod.Invoke(contentManager, new object[] { attribute.ResourceName }));
            }
        }

        public abstract void Draw(IRenderService renderService, GameTime gameTime);
    }
}
