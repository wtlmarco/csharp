public static class TypeBroker
{
    //DesingPattern TypeBroker
    //Utilizado para diminuir o acoplamento entre as classes
    //possibilitando que centralizar em um único ponto a definição 
    //de qual serviço utilizar, no exemplo abaixo, toda a aplicação
    //pode optar de utilizar o servico EnderecoTextual ou EnderecoHtml
    //pela simples substituição somente nesse ponto, anteriormente,
    //toda chamada 

    //private static IFormatadorEndereco instanciaCompartilhada = new EnderecoTextual();

    private static IFormatadorEndereco instanciaCompartilhada = new EnderecoHtml();

    public static IFormatadorEndereco FormatadorEndereco => instanciaCompartilhada;
}