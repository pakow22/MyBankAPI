namespace MyBankAPI.MiddleWares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(RequestDelegate requestDelegate, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            var requestInfo = await GetRequestInfoAsync(context.Request);
            string request = $"Method Type {requestInfo.Method.ToString()} - Method Name {requestInfo.Path.ToString()}";
            LogRequest(request);

            using (var responseBody = new MemoryStream())
            {
                try
                {
                    // Replace the response stream with our custom stream
                    context.Response.Body = responseBody;

                    await _next(context);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    context.Response.StatusCode = 500;
                }
                finally
                {
                    var responseText = await GetResponseTextAsync(responseBody);

                    // Log the response
                    LogResponse(responseText);

                    responseBody.Seek(0, SeekOrigin.Begin);

                    // Copy the response data back to the original response stream
                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
        }
        private async Task<RequestInfo> GetRequestInfoAsync(HttpRequest request)
        {
            var requestInfo = new RequestInfo
            {
                Method = request.Method,
                Path = request.Path,
                QueryString = request.QueryString.ToString(),
                Headers = request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()),
                DateTime = DateTime.Now.ToString()
            };

            request.EnableBuffering();
            using (var reader = new StreamReader(request.Body, leaveOpen: true))
            {
                requestInfo.Body = await reader.ReadToEndAsync();
                request.Body.Seek(0, SeekOrigin.Begin); 
            }

            return requestInfo;
        }
        private async Task<string> GetResponseTextAsync(Stream responseStream)
        {
            responseStream.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(responseStream).ReadToEndAsync();
            responseStream.Seek(0, SeekOrigin.Begin);

            return responseBody;
        }

        private void LogResponse(string responseText)
        {
            _logger.LogInformation("ResponseInformation: {ResponseText}", responseText);
        }
        private void LogRequest(string requestText)
        {
            _logger.LogInformation("RequestInformation : {RequestText}", requestText);
        }
        public class RequestInfo
        {
            public string Method { get; set; }
            public string Path { get; set; }
            public string QueryString { get; set; }
            public Dictionary<string, string> Headers { get; set; }
            public string Body { get; set; }
            public string DateTime { get; set; }
        }
    }

}
