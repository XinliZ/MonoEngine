using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MonoEngine.Graphics;

namespace MonoEngine.Components
{
    public abstract class GameObject : IDisposable
    {
        protected MonoEngine.Game Game;

        public GameObject(MonoEngine.Game game)
        {
            this.Game = game;

            // TODO: It is not necessary to load the content in the constructors. This could be optimized later to have a better content loading strategy
            LoadContent(game.Content);
        }
        protected List<GameObject> Children = new List<GameObject>();

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

        protected void Add(GameObject gameObject)
        {
            this.Children.Add(gameObject);
        }

        public virtual void Initialize()
        {

        }

        public virtual void LoadResource(ContentManager contentManager)
        {
        }

        public virtual void UnloadResource()
        {
        }

        

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(IRenderService renderService, GameTime gameTime);

        public void Dispose()
        {
            this.UnloadResource();
        }
    }
}
