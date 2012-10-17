namespace SheepJax
{
    public interface IDefaultCommands: ISheepJaxInvokable
    {
        IDefaultCommands RedirectPage(string url);
        IDefaultCommands ReloadPage();

        IDefaultCommands Replace(string selector, string view);

        IDefaultCommands Append(string selector, string view);

        IDefaultCommands SetHtml(string selector, string view);

        IDefaultCommands Remove(string selector);
        IDefaultCommands Hide(string selector);
        IDefaultCommands Show(string selector);
    }

    public interface ISheepJaxInvokable
    {
        T As<T>();
        dynamic Dynamic { get; }
        void Invoke(string methodName, params object[] args);
    }
}