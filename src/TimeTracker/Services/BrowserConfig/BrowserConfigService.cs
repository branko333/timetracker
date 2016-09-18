using System.Text;
using System.Xml.Linq;
using Boilerplate.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Preduzece.TimeTracker.Services.BrowserConfig
{
    public class BrowserConfigService : IBrowserConfigService
    {
        private readonly IUrlHelper _urlHelper;

        public BrowserConfigService(IUrlHelper urlHelper)
        {
            this._urlHelper = urlHelper;
        }

        /// <summary>
        /// Gets the browserconfig XML for the current site. This allows you to customize the tile, when a user pins
        /// the site to their Windows 8/10 start screen. See http://www.buildmypinnedsite.com and
        /// https://msdn.microsoft.com/en-us/library/dn320426%28v=vs.85%29.aspx
        /// </summary>
        /// <returns>The browserconfig XML for the current site.</returns>
        public string GetBrowserConfigXml()
        {
            // The URL to the 70x70 small tile image.
            var square70X70LogoUrl = _urlHelper.Content("~/img/icons/mstile-70x70.png");
            // The URL to the 150x150 medium tile image.
            var square150X150LogoUrl = _urlHelper.Content("~/img/icons/mstile-150x150.png");
            // The URL to the 310x310 large tile image.
            var square310X310LogoUrl = _urlHelper.Content("~/img/icons/mstile-310x310.png");
            // The URL to the 310x150 wide tile image.
            var wide310X150LogoUrl = _urlHelper.Content("~/img/icons/mstile-310x150.png");
            // The colour of the tile. This colour only shows if part of your images above are transparent.
            var tileColour = "#1E1E1E";

            var document = new XDocument(
                new XElement(
                    "browserconfig",
                    new XElement(
                        "msapplication",
                        new XElement(
                            "tile",
                            new XElement(
                                "square70x70logo",
                                new XAttribute("src", square70X70LogoUrl)),
                            new XElement(
                                "square150x150logo",
                                new XAttribute("src", square150X150LogoUrl)),
                            new XElement(
                                "square310x310logo",
                                new XAttribute("src", square310X310LogoUrl)),
                            new XElement(
                                "wide310x150logo",
                                new XAttribute("src", wide310X150LogoUrl)),
                            new XElement("TileColor", tileColour)))));

            return document.ToString(Encoding.UTF8);
        }
    }
}