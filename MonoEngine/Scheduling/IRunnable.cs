using Microsoft.Xna.Framework;
using System.Threading.Tasks;

namespace MonoEngine.Scheduling
{
    public interface IRunnable
    {
        void Update(GameTime gameTime);
    }

    public interface IRunnable<T> : IRunnable
    {
        Task<T> WaitAsync();
    }
}
