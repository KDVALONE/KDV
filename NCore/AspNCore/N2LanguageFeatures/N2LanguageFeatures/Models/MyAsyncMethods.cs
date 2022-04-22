using System.Net.Http;
using System.Threading.Tasks;
namespace N2LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        //упращеная версия кода с применением потоков с Async await
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://apress.com");
            return httpMessage.Content.Headers.ContentLength;
        }

        #region Версия кода с применением потоков
        //public static Task<long?> GetPageLength()
        //{
        //    HttpClient client = new HttpClient();
        //    var httpTask = client.GetAsync("http://apress.com");
        //    return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>
        //    {
        //        return antecedent.Result.Content.Headers.ContentLength;
        //    });
        //}
        #endregion


    }
}