using System.Web;
using System.Web.Optimization;

namespace MVCOA
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/mvcAjax").Include(
                      "~/Scripts/jquery-3.3.1.min.js",
                      "~/Scripts/jquery.unobtrusive-ajax.min.js",
                      "~/Scripts/jquery.validate.min.js",
                      "~/Scripts/jquery.validate.unobtrusive.min.js",
                      "~/Scripts/jquery.msgProcess.js"
                      ));

            bundles.Add(new ScriptBundle("~/easyUIJS").Include(
                      "~/Scripts/jquery.min.js",
                      "~/EasyUI/jquery.easyui.min.js",
                      "~/Scripts/jquery.msgProcess.js",
                      "~/EasyUI/easyui-lang-zh_CN.js"
                      ));

            bundles.Add(new StyleBundle("~/EasyUI/themes/css1").Include(
                      "~/EasyUI/themes/icon.css"
                      ));
            bundles.Add(new StyleBundle("~/EasyUI/themes/default/css2").Include(
                      "~/EasyUI/themes/default/easyui.css"
                      ));

            BundleTable.EnableOptimizations = true;
        }
    }
}
