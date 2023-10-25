using APICrudClient1.Models;
using Newtonsoft.Json;
using System.Net;

namespace APICrudClient1
{
    public class APIGateway
    {
        private string url = "https://localhost:7152/api/Customer";
        private HttpClient httpClient = new HttpClient();

        public List<Customer> ListCustomers()
        {
            List<Customer> customers = new List<Customer>();
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<Customer>>(result);
                    if (datacol != null)
                        customers = datacol;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(" Error Occured at API End Point,, Error Info:: " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured at the api Endpoint, error info::::: " + ex.Message);
            }
            finally { }
            return customers;
        }
    }
}
