using ClassLibrary.Models;
using System.Text.Json;
using System.Text;
using System.Net.Http;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;

namespace WebLab3CV.Shared
{
    public class APICRUD
    {
        List<Skills> listOfSkills = new();
        public HttpClient httpClient = new();

        public async Task<List<Skills>> ListSkills(string baseAdress)
        {
            try
            {
                // Create a new instance of HttpClient with the provided base address
                httpClient = new HttpClient { BaseAddress = new Uri(baseAdress) };
                // Make GET request to your API endpoint
                var response = await httpClient.GetAsync("/skills");

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response body into a list of products
                    listOfSkills = await response.Content.ReadFromJsonAsync<List<Skills>>();
                    if (listOfSkills != null)
                        return listOfSkills;

                    else
                        throw new Exception("List is Empty");

                }
                else
                {
                    //a bad attempt at handling an error.
                    Console.WriteLine("Failed to retrieve products. Status code: " + response.StatusCode);
                    throw new Exception("response dont have a successful code");
                }
            }
            catch (Exception ex)
            {
                //a bad attempt at handling an error.
                Console.WriteLine("An error occurred while retrieving skills: " + ex.Message);
                throw new Exception("Error while Handling");
            }
        }

        public async Task<bool> AddSkill(string baseAdress, Skills skill)
        {
            try
            {
                //using var httpClient = new HttpClient { BaseAddress = new Uri(baseAdress) };
                httpClient = new HttpClient { BaseAddress = new Uri(baseAdress) };
                var response = await httpClient.PostAsJsonAsync("/skills", skill);

                return response.IsSuccessStatusCode;


            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the request
                Console.WriteLine("An error occurred while retrieving skills: " + ex.Message);
                return false;
            }
        }
    }
}
