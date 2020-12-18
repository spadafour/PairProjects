using CatCards.Models;
using RestSharp;
using System.Net.Http;

namespace CatCards.Services
{
    public class CatFactService : ICatFactService
    {
        private string API_URL { get; } = "https://cat-fact.herokuapp.com/facts/random";
        private IRestClient Client = new RestClient();

        public CatFact GetFact()
        {
            try
            {
                RestRequest request = new RestRequest(API_URL);
                IRestResponse<CatFact> response = Client.Get<CatFact>(request);
                return response.Data;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
