using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{/// <summary>
/// This class contains the HTML Pages that the server can display
/// </summary>
    internal class HtmlStorage
    {
        private string errorPage=
        "<!DOCTYPE>" +
        "<html>" +
        "  <head>" +
        "    <title>Error</title>" +
        "  </head>" +
        "  <body>" +
        "    <p>Error 404 Page not found</p>" +
        "  </body>" +
        "</html>";

        private string startPage =
        "<!DOCTYPE>" +
        "<html>" +
        "  <head>" +
        "    <title>Start Page</title>" +
        "  </head>" +
        "  <body>" +
        "    <p>Start Page</p>" +
        "  </body>" +
        "</html>";

        private string indexPage =
        "<!DOCTYPE>" +
        "<html>" +
        "  <head>" +
        "    <title>Index Page</title>" +
        "  </head>" +
        "  <body>" +
        "    <p>Index page</p>" +
        "  </body>" +
        "</html>";
        private string notAllowedPage =
        "<!DOCTYPE>" +
        "<html>" +
        "  <head>" +
        "    <title>NotAllowed</title>" +
        "  </head>" +
        "  <body>" +
        "    <p>Method not allowed</p>" +
        "  </body>" +
        "</html>";
        private string endPage =
        "<!DOCTYPE>" +
        "<html>" +
        "  <head>" +
        "    <title>End</title>" +
        "  </head>" +
        "  <body>" +
        "    <p>Server shutting down....</p>" +
        "  </body>" +
        "</html>";

        public string ErrorPage { get { return errorPage; } private set { errorPage = value; } }
        public string StartPage { get { return startPage; } private set { startPage = value; } }
        public string IndexPage { get { return indexPage; } private set { indexPage = value; } }
        public string NotAllowedPage { get { return notAllowedPage; } private set { notAllowedPage = value; } }
        public string EndPage { get { return endPage; } private set { endPage = value; } }
    }
}
