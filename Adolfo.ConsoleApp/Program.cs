using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace Adolfo.ConsoleApp
{
    class Program
    {
        static async void Main(string[] args)
        {
            var client = new HttpClient();
            try
            {


                var disco = await client.GetDiscoveryDocumentAsync("http://localhost:60148");
                if (disco.IsError)
                {
                    Console.WriteLine(disco.Error);
                    return;
                }

                // request token
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = "client",
                    ClientSecret = "secret",

                    Scope = "api1"
                });

                if (tokenResponse.IsError)
                {
                    Console.WriteLine(tokenResponse.Error);
                    return;
                }

                Console.WriteLine(tokenResponse.Json);
                Console.WriteLine("\n\n");

                Console.ReadLine();

                // call api
                //var apiClient = new HttpClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                //var response = await apiClient.GetAsync("http://localhost:5001/identity");
                //if (!response.IsSuccessStatusCode)
                //{
                //    Console.WriteLine(response.StatusCode);
                //}
                //else
                //{
                //    var content = await response.Content.ReadAsStringAsync();
                //    Console.WriteLine(JArray.Parse(content));
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private static async void Run()
        {
            var client = new HttpClient();
            try
            {

            
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:60148");
            if(disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",

                Scope = "api1"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            Console.ReadLine();

                // call api
                //var apiClient = new HttpClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                //var response = await apiClient.GetAsync("http://localhost:5001/identity");
                //if (!response.IsSuccessStatusCode)
                //{
                //    Console.WriteLine(response.StatusCode);
                //}
                //else
                //{
                //    var content = await response.Content.ReadAsStringAsync();
                //    Console.WriteLine(JArray.Parse(content));
                //}
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
