using System.Net;
using System.Text;

namespace WebServer
{
    internal class HttpServer
    {
        private bool running = false;
        private HttpListener listener;
        private bool pageFound;
        private bool methodAllowed;

        /// <summary>
        /// Constructor for the HttpServer class. It sets the listener and adds a prefix
        /// </summary>
        public HttpServer()
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8000/");
        }
        /// <summary>
        /// Starts the server and calls the HandleConnections method
        /// </summary>
        public void Start()
        {
            running = true;
            listener.Start();
            HandleConnections();
        }
        /// <summary>
        /// Stops the server
        /// </summary>
        private void Stop()
        {
            listener.Stop();
        }
        /// <summary>
        /// While running it'll handle connections to the Http server 
        /// and call the CheckHttpMethod, SetStatusCode and DisplayPage methods
        /// If running is false it'll call the Stop method
        /// </summary>
        private void HandleConnections()
        {
            while (running)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                byte[] data;
                CheckHttpMethod(request);
                data = Encoding.UTF8.GetBytes(String.Format(GetPage(request.Url.AbsolutePath)));
                SetStatusCode(response);
                DisplayPage(response, data);
            }
            Stop();
        }
        /// <summary>
        /// Displays the data as an HTML page
        /// </summary>
        /// <param name="response"></param>
        /// <param name="data"></param>
        private void DisplayPage(HttpListenerResponse response, byte[] data)
        {
            response.ContentType = "text/html";
            response.OutputStream.Write(data);
            response.Close();
        }
        /// <summary>
        /// Checks the Http method and changes the methodAllowed attribute depending on the method
        /// </summary>
        /// <param name="request"></param>
        private void CheckHttpMethod(HttpListenerRequest request)
        {
            if (request.HttpMethod == "GET" || request.HttpMethod == "POST") methodAllowed = true;
            else methodAllowed = false;
        }

        /// <summary>
        /// Gets the relevant html page from HtmlStorage.cs
        /// </summary>
        /// <param name="path"></param>
        /// <returns HtmlPage from HtmlStorage></returns>
        private string GetPage(string path)
        {
            HtmlStorage html = new HtmlStorage();
            if (!methodAllowed) return html.NotAllowedPage;
            switch (path)
            {
                case "/":
                    pageFound = true;
                    return html.StartPage;
                case "/index.html":
                    pageFound = true;
                    return html.IndexPage;
                case "/end":
                    running = false;
                    pageFound = true;
                    return html.EndPage;
                default:
                    pageFound = false;
                    return html.ErrorPage;
            }
        }
        /// <summary>
        /// Sets the ststus code to 405 if method allowed, 404 if page not found, otherwise 200
        /// </summary>
        /// <param name="response"></param>
        private void SetStatusCode(HttpListenerResponse response)
        {
            if (methodAllowed == true)
            {
                if (pageFound == true) response.StatusCode = 200;
                else response.StatusCode = 404;
            }
            else response.StatusCode = 405;
        }
    }
}
