using System;
using System.Collections.Generic;
using System.Threading;

namespace GoWHunter.Fiddler.Receipe
{
    public class Recipe : IRecipe
    {
        public List<Action> _actions = new List<Action>();

        public string Name
        {
            get { return "Treasure Hunt"; }
        }

        public void AddStep(Action action)
        {
            _actions.Add(action);
        }

        public virtual void Cook(int intervalBetweenEachRun, int repeatTimes, int intervalBetweenEachStep)
        {
            for(int i = 0; i < repeatTimes; i ++)
            {
                
                foreach (Action action in _actions)
                {
                    action();
                    Thread.Sleep(intervalBetweenEachStep);
                }
                Logger.LogConsoleAndDebug("Done {0} {1} / {2}", Name, i + 1, repeatTimes);
                Thread.Sleep(intervalBetweenEachRun);
            }
            Logger.LogConsoleAndDebug("Done {0} {1} / {2}", Name, repeatTimes, repeatTimes);
        }
    }
}