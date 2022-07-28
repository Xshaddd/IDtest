using System;
using System.Collections.Generic;
using System.Linq;

namespace IDtest
{
    static class ActionList
    {
        public static List<Action> Actions { get; private set; } = new List<Action>();
        public static void Init()
        {
            Actions.Add(new Action(0, Exit));
            Actions.Add(new Action(1, StartGame));
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
