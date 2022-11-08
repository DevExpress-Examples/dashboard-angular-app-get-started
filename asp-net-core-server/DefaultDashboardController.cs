using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;
using Microsoft.AspNetCore.DataProtection;

namespace AspNetCoreDashboardBackend {
    public class DefaultDashboardController : DashboardController {
        public DefaultDashboardController(DashboardConfigurator configurator, IDataProtectionProvider? dataProtectionProvider)
            : base(configurator, dataProtectionProvider) {
        }
    }
}