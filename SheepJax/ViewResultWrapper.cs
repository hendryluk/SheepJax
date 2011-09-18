using System.Diagnostics.Contracts;
using System.Web.Mvc;

namespace SheepJax
{
    public class ViewResultWrapper
    {
        private readonly ViewResultBase _viewResult;
        private readonly object _model;

        public ViewResultWrapper(ViewResultBase viewResult)
        {
            Contract.Requires(viewResult != null);
            _viewResult = viewResult;
            _model = viewResult.ViewData.Model;
        }

        public ViewResultBase GetViewResult()
        {
            Contract.Ensures(Contract.Result<ViewResultBase>() != null);
            _viewResult.ViewData.Model = _model;
            return _viewResult;
        }
    }
}