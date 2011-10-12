namespace SheepJax
{
    public class SheepJaxInvoke
    {
        public string FunctionName { get; private set; }
        public object[] Args { get; private set; }

        public SheepJaxInvoke(string functionName, params object[] args)
        {
            FunctionName = functionName;
            Args = args;
        }
    }
}