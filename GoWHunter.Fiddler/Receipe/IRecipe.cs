using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWHunter.Fiddler.Receipe
{
    
    interface IRecipe
    {
        string Name { get; }
        void AddStep(Action action);
        void Cook(int intervalBetweenEachRun, int repeatTimes, int intervalBetweenEachStep);
    }
}
