using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoEngine.Scheduling
{
    public interface IConditionValidator<T>
    {
        bool ConditionMeet();
        T TargetState { get; }
    }
}
