using System.Text;
using Boilerplate.AspNetCore;
using Boilerplate.AspNetCore.Filters;
using Microsoft.AspNetCore.Mvc;
using Preduzece.TimeTracker.Constants;
using Preduzece.TimeTracker.Constants.HomeController;
using Preduzece.TimeTracker.Services.BrowserConfig;
using Preduzece.TimeTracker.Services.Manifest;
using Preduzece.TimeTracker.Services.Robots;

namespace Preduzece.TimeTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrowserConfigService _browserConfigService;
        private readonly IManifestService _manifestService;
        private readonly IRobotsService _robotsService;

        public HomeController(
            IBrowserConfigService browserConfigService,
            IManifestService manifestService,
            IRobotsService robotsService)
        {
            _browserConfigService = browserConfigService;
            _manifestService = manifestService;
            _robotsService = robotsService;
        }

        [HttpGet("", Name = HomeControllerRoute.GetIndex)]
        public IActionResult Index()
        {
            return View(HomeControllerAction.Index);
        }

        /// <summary>
        /// Gets the browserconfig XML for the current site. This allows you to customize the tile, when a user pins
        /// the site to their Windows 8/10 start screen. See http://www.buildmypinnedsite.com and
        /// https://msdn.microsoft.com/en-us/library/dn320426%28v=vs.85%29.aspx
        /// </summary>
        /// <returns>The browserconfig XML for the current site.</returns>
        [NoTrailingSlash]
        [ResponseCache(CacheProfileName = CacheProfileName.BrowserConfigXml)]
        [Route("browserconfig.xml", Name = HomeControllerRoute.GetBrowserConfigXml)]
        public ContentResult BrowserConfigXml()
        {
            var content = _browserConfigService.GetBrowserConfigXml();
            return Content(content, ContentType.Xml, Encoding.UTF8);
        }

        /// <summary>
        /// Gets the manifest JSON for the current site. This allows you to customize the icon and other browser
        /// settings for Chrome/Android and FireFox (FireFox support is coming). See https://w3c.github.io/manifest/
        /// for the official W3C specification. See http://html5doctor.com/web-manifest-specification/ for more
        /// information. See https://developer.chrome.com/multidevice/android/installtohomescreen for Chrome's
        /// implementation.
        /// </summary>
        /// <returns>The manifest JSON for the current site.</returns>
        [NoTrailingSlash]
        [ResponseCache(CacheProfileName = CacheProfileName.ManifestJson)]
        [Route("manifest.json", Name = HomeControllerRoute.GetManifestJson)]
        public ContentResult ManifestJson()
        {
            var content = _manifestService.GetManifestJson();
            return Content(content, ContentType.Json, Encoding.UTF8);
        }

        /// <summary>
        /// Tells search engines (or robots) how to index your site.
        /// The reason for dynamically generating this code is to enable generation of the full absolute sitemap URL
        /// and also to give you added flexibility in case you want to disallow search engines from certain paths. The
        /// sitemap is cached for one day, adjust this time to whatever you require. See
        /// http://rehansaeed.com/dynamically-generating-robots-txt-using-asp-net-mvc/
        /// </summary>
        /// <returns>The robots text for the current site.</returns>
        [NoTrailingSlash]
        [ResponseCache(CacheProfileName = CacheProfileName.RobotsText)]
        [Route("robots.txt", Name = HomeControllerRoute.GetRobotsText)]
        public IActionResult RobotsText()
        {
            var content = _robotsService.GetRobotsText();
            return Content(content, ContentType.Text, Encoding.UTF8);
        }
    }
}
