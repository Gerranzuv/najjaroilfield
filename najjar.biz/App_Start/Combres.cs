[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(najjar.biz.App_Start.Combres), "PreStart")]
namespace najjar.biz.App_Start {
	using System.Web.Routing;
	using global::Combres;
	
    public static class Combres {
        public static void PreStart() {
            RouteTable.Routes.AddCombresRoute("Combres");
        }
    }
}