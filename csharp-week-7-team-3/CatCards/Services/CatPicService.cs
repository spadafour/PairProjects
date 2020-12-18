using CatCards.Models;
using RestSharp;

namespace CatCards.Services
{
    public class CatPicService : ICatPicService
    {
        private string API_URL { get; } = "https://random-cat-image.herokuapp.com/";
        private IRestClient Client = new RestClient();

        public CatPic GetPic()
        {
            try
            {
                IRestRequest request = new RestRequest(API_URL);
                IRestResponse<CatPic> response = Client.Get<CatPic>(request);
                return response.Data;
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
    }
}
