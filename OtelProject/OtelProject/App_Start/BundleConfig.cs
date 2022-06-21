using System.Web;
#pragma warning disable CS0234 // The type or namespace name 'Optimization' does not exist in the namespace 'System.Web' (are you missing an assembly reference?)
using System.Web.Optimization;
#pragma warning restore CS0234 // The type or namespace name 'Optimization' does not exist in the namespace 'System.Web' (are you missing an assembly reference?)

namespace OtelProject
{
    public class BundleConfig
    {
        // Paketleme hakkında daha fazla bilgi için lütfen https://go.microsoft.com/fwlink/?LinkId=301862 adresini ziyaret edin
#pragma warning disable CS0246 // The type or namespace name 'BundleCollection' could not be found (are you missing a using directive or an assembly reference?)
        public static void RegisterBundles(BundleCollection bundles)
#pragma warning restore CS0246 // The type or namespace name 'BundleCollection' could not be found (are you missing a using directive or an assembly reference?)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Geliştirme yapmak ve öğrenmek için Modernizr'ın geliştirme sürümünü kullanın. Daha sonra,
            // üretim için hazır. https://modernizr.com adresinde derleme aracını kullanarak yalnızca ihtiyacınız olan testleri seçin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
