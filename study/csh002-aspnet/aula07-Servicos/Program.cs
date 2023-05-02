var builder = WebApplication.CreateBuilder(args);

/*
* 3) Utilizando Serviços
*/
//Design Pattern - DI (injeção de dependência)
//Recurso de Injeção de Dependência Nativo
//no Services incluímos os serviços que utilizaremos na Aplicação

//3 A) Nesse modo teremos somente uma instância do serviço a ser compartilhada
//builder.Services.AddSingleton<IFormatadorEndereco, EnderecoHtml>();

//3 B) Nesse modo rota que implementa o serviço terá uma instância separada
//builder.Services.AddTransient<IFormatadorEndereco, EnderecoHtml>();

//3 C) Nesse modo será criado um novo objeto de serviço a cada requisição
builder.Services.AddScoped<IFormatadorEndereco, EnderecoHtml>();

var app = builder.Build();

/*
* 1) Estudo de inclusão de Middlewares
*/
//1.1) Inclusão dos Middlewares nativos 
app.UseDeveloperExceptionPage();
app.UseRouting();

//3.3 Utilizando Injeção de Depedência, modo criando classe acessória
//que recebe pelo seu construtor a interface do Servico e que 
//o próprio Pipeline do Framework automaticamente instância a classe correta
//pela Injeção de Dependência
app.UseMiddleware<MiddlewareConsultaCep>();

//1.3) Inclusão de Middleware por função anônima utilizando Design Pattern Broker
app.Use(async (context, next) => {
    if(context.Request.Path == "/mw/lambda")
    {
        await TypeBroker.FormatadorEndereco.Formatar(context, await EndpointConsultaCep.ConsultaCep("01001000"));
    }
    else
    {
        await next();
    }
});


app.UseEndpoints(endpoints => {
    //3.2 Utilizando Injeção de Depedência
    //Quando a classe é estanciada verifica-se que seu construtor recebe a interface IFormatadorEndereco
    //e o próprio Framework passa a referência ao serviço já definido 
    endpoints.MapGet("ep/classe2/{cep:regex(^\\d{{8}}$)?}", EndpointConsultaCep.Endpoint);

    //3.4 Utilizando Injeção de Depedência, modo criando classe acessória
    //que implementa a integração com o serviço separando a responsabilidade 
    //do EndPoint e do ID
    endpoints.MapConsultaCep("ep/classe3/{cep:regex(^\\d{{8}}$)?}");

    //3.4 Utilizando Injeção de Depedência, utilizando um mapeamento dinâmico e uma
    //uma classe definida  para o processamento do Middleware
    endpoints.MapEndpoint<MiddlewareConsultaCep>("ep/classe4/{cep:regex(^\\d{{8}}$)?}");

    //1.4) Inclusão de Middleware por Endpoint utilizando Design Pattern Broker
    endpoints.MapGet("ep/lambda/{cep:regex(^\\d{{8}}$)?}", async context => {
        string cep = context.Request.RouteValues["cep"] as string ?? "01001000";
        await  TypeBroker.FormatadorEndereco.Formatar(context, await EndpointConsultaCep.ConsultaCep(cep));
    });
});

/*
* 2) Estudo de Design Patterns
*/
//2.1) Requisição inicial
//Cada chamada cria uma instância não compartilhada
app.Use(async (context, next) => {
    if(context.Request.Path == "/sample1")
    {
        await new EnderecoTextual().Formatar(context, await EndpointConsultaCep.ConsultaCep("01001000"));
    }
    else
    {
        await next();
    }
});

//2.2) Design Pattern Singleton
//Nova requisição do mesmo Middleware emuma instância única e compartilhada
app.Use(async (context, next) => {
    if(context.Request.Path == "/sample2")
    {
        await EnderecoTextual.Singleton.Formatar(context, await EndpointConsultaCep.ConsultaCep("01001000"));
    }
    else
    {
        await next();
    }
});

//2.3) Design Pattern TypeBroker
//Também Singleton, o modelo TypeBroker melhora mais ainda o desacoplamento concentrando
//em somente 1 ponto a esoclha de qual serviço entregar
app.Use(async (context, next) => {
    if(context.Request.Path == "/sample3")
    {
        await TypeBroker.FormatadorEndereco.Formatar(context, await EndpointConsultaCep.ConsultaCep("01001000"));
    }
    else
    {
        await next();
    }
});

/*
* 3) Utilizando Serviços
*/
//3.1) Chamada de Serviços por função anônima utilizando Injeção de Dependência
app.Use(async (context, next) => {
    if(context.Request.Path == "/servico1")
    {   
        var servico = context.RequestServices.GetRequiredService<IFormatadorEndereco>(); 
        await servico.Formatar(context, await EndpointConsultaCep.ConsultaCep("01001000"));
    }
    else
    {
        await next();
    }
});

app.Run(async context => {
    await context.Response.WriteAsync("Middleware terminal.");
});

//app.MapGet("/", () => "Hello World!");

app.Run();
