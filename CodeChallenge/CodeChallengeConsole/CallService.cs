using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallengeConsole
{
    public class CallService
    {
        public string GetHttpsApiUrl(string input)
        {
            // Read the API endpoint from the configuration file
            input = input.Replace(" ", "+");
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            string apiUrl = config.GetValue<string>("HttpsEndpoint") + $"?input={input}";
            return apiUrl;
        }

        public string GetHttpApiUrl(string input)
        {
            // Read the API endpoint from the configuration file
            input = input.Replace(" ", "+");
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            string apiUrl = config.GetValue<string>("HttpEndpoint") + $"?input={input}";
            return apiUrl;
        }

        public async Task<string> ExecuteCall(string input, string output, string apiUrl)
        {
            try
            {
                // Create an HTTP client and send an HTTP GET request to the endpoint
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(2);
                var response = await client.GetAsync(apiUrl);

                // Check if the response status code is OK
                if (response.IsSuccessStatusCode)
                {
                    output = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    output = $"Call to endpoint returned: {response.StatusCode}";
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle network errors
                Console.WriteLine($"The request was canceled due to the HttpClient is not Running. If you start it, the call will be done from the API");
                Console.WriteLine("Calling Service Internally");
                output = new Service().GetResult(input);
            }
            catch (TaskCanceledException ex)
            {
                // Handle timeouts
                Console.WriteLine($"The request was canceled due to the HttpClient is not Running. If you start it, the call will be done from the API");
                Console.WriteLine("Calling Service Internally");
                output = new Service().GetResult(input);
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                Console.WriteLine($"Error: {ex.Message}");                
                output = "ERROR";
            }
            finally
            {
                Console.WriteLine($"Output: {output}");
            }

            return output;
        }
        
    }
}
