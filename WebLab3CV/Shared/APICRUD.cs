using ClassLibrary.Models;

namespace WebLab3CV.Shared
{
    public class APICRUD
    {
        List<Skills> listOfSkills = new();

        

        public async Task<List<Skills>> ListSkills(string baseAddress)
        {
            try
            {
                // Create a new instance of HttpClient with the provided base address
                using (var httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) })
                {
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
                        // Handle error if the request was not successful
                        // For example, you can log the error or display a message to the user
                        Console.WriteLine("Failed to retrieve products. Status code: " + response.StatusCode);
                        throw new Exception("response dont have a successful code");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the request
                Console.WriteLine("An error occurred while retrieving skills: " + ex.Message);
                throw new Exception("Error while Handling");
            }
        }

        public async Task<bool> AddSkill(string baseAddress, Skills skill)
        {
            try
            {
                // Create a new instance of HttpClient with the provided base address
                using (var httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) })
                {
                    // Make PUT request to your API endpoint
                    var response = await httpClient.PostAsJsonAsync<Skills>("/skills", skill);
                    
                    return response.IsSuccessStatusCode;
                    
                }
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
