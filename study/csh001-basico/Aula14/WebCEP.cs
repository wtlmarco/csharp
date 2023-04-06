using System.Net;
using System.Text.Json;
using Newtonsoft.Json;

namespace Aula14
{
    public class WebCEP
    {
        [JsonProperty("cep")]
        public string CEP { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("localidade")]
        public string Localidade { get; set; }

        [JsonProperty("uf")]
        public string UF { get; set; }

        public override string ToString()
        {
            return string.Join(", ", Logradouro, Complemento, Bairro, Localidade, UF);
        }

        public static WebCEP ObterEndereco(string CEP)
        {
            string url = $"https://viacep.com.br/ws/{CEP}/json/";

            WebClient wc = null;

            try
            {
                wc = new WebClient();
                string dadosJson = wc.DownloadString(url);
                return JsonConvert.DeserializeObject<WebCEP>(dadosJson);

            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally 
            {
                wc?.Dispose();
            }

            return null;
        }
    }
}
