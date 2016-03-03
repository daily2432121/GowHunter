using System;
using System.Collections.Generic;
using System.Threading;

namespace GoWHunter.Fiddler.Receipe
{
    public class Recipe : IRecipe
    {
        public List<Action> _actions = new List<Action>();

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
                    action(); Thread.Sleep(intervalBetweenEachStep);
                }
                Thread.Sleep(intervalBetweenEachRun);
            }
        }
    }
}