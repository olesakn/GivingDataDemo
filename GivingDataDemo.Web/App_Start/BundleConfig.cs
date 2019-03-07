using System.Web;
using System.Web.Optimization;

namespace GivingDataDemo.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css"));
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*"));

            // Auto-include all angularJS services
            bundles.Add(new ScriptBundle("~/angularjs/services")
                .IncludeDirectory("~/app/services", "*.js"));
            
            // Auto-include all angularJS controllers
            bundles.Add(new ScriptBundle("~/angularjs/controllers")
                .IncludeDirectory("~/app/components", "*Controller.js", true));

            // Auto-include all angularJS directives
            bundles.Add(new ScriptBundle("~/angularjs/directives")
                .IncludeDirectory("~/app/components", "*Directive.js", true));


        }
    }
}
