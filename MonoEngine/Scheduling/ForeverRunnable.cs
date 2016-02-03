using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoEngine.Scheduling
{
    public class ForeverRunnable : IRunnable<object>
    {
        public void Update(GameTime gameTime)
        {
            // Do nothing
        }

        public async Task<object> WaitAsync()
        {
            await new Task(()=> { });
            return null;
        }
    }
}
