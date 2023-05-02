using Newtonsoft.Json;

public sealed class JsonCep : IEndereco
{
    [JsonProperty("cep")]
    public string CEP {get; set;}

    [JsonProperty("logradouro")]
    public string Logradouro {get; set;}

    [JsonProperty("complemento")]
    public string Complemento {get; set;}

    [JsonProperty("bairro")]
    public string Bairro {get; set;}

    [JsonProperty("localidade")]
    public string Localidade {get; set;}

    [JsonProperty("uf")]
    public string Estado {get; set;}

    [JsonProperty("unidade")]
    public string Unidade {get; set;}

    [JsonProperty("ibge")]
    public string IBGE {get; set;}

    [JsonProperty("gia")]
    public int? GIA {get; set;}
}