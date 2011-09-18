using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using SheepJax;
using SheepJax.Comet;
using WebActivator;

[assembly: PreApplicationStartMethod(typeof(PreApplicationStartCode), "Start")]
namespace SheepJax
{
    public static class PreApplicationStartCode
    {
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(LongPollHttpModule));
        }
    }
}