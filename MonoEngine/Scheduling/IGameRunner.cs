using MonoEngine.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoEngine.Scheduling
{
    public interface IGameRunner
    {
        Task<Ty> Play<Ty>(IRenderable renderable, IRunnable<Ty> runnable);
    }
}
