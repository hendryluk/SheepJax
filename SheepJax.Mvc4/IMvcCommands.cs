using System.Web.Mvc;

namespace SheepJax.Mvc4
{
    public interface IMvcCommands: IDefaultCommands
    {
        IMvcCommands Replace(string selector, ViewResultBase view);
        IMvcCommands Append(string selector, ViewResultBase view);
        IMvcCommands SetHtml(string selector, ViewResultBase view);
        IMvcCommands WritePage(ViewResultBase view);
    }
}