namespace IDtest
{
    delegate void ActionFunction();

    class Action
    {
        public int ActionID;
        public ActionFunction Function;

        public Action(int ActionID, ActionFunction Function)
        {
            this.ActionID = ActionID;
            this.Function = Function;
        }
    }
}
