namespace SheepJax
{
    public class SheepJaxInvoke
    {
        public string FunctionName { get; private set; }
        public object[] Args { get; private set; }

        public SheepJaxInvoke(string functionName, object[] args)
        {
            FunctionName = functionName;
            Args = args;
        }
    }
}