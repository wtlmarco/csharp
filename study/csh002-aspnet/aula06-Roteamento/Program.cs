var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RouteOptions>(opts =>{
    opts.ConstraintMap.Add("constraintPop", typeof(ConstraintPop));    
});

var app = builder.Build();

/*
* O Framework possui diversos Middlewares com funções específicas
*/

//1) Middleware Disponível no Framework
app.UseDeveloperExceptionPage();

//2) Middleware Disponível no Framework para tratamento de rota
app.UseRouting();

/*
* O uso de Endpoints separa a responsabilidade de identificação da rota
* para a chamada ao Middleware, dessa maneira, temos um Middleware 
* específico de roteamento para processar as chamadas
*/
app.UseEndpoints(endpoints => {
    //1) Endpoint que chama Middleware por função anônima
    endpoints.MapGet("ola/mundo", () => "Olá, Mundo!");

    //2) Endpoint que chama Middleware por função anônima
    endpoints.MapGet("rota", async context => {
        context.Response.ContentType = "text/plain; charset=utf-8";
        await context.Response.WriteAsync("Requisição foi roteada.");
    });

    //3) Endpoint com 3 segmentos indefinidos
    endpoints.MapGet("{p1}/{p2}/{p3}", async context => {
        context.Response.ContentType = "text/plain; charset=utf-8";
        await context.Response.WriteAsync("Requisição foi roteada.\n");
        foreach (var item in context.Request.RouteValues)
        {
            await context.Response.WriteAsync($"{item.Key}: {item.Value}\n");
        }
    });
    
    //3) Endpoint com 2 segmentos sendo o primeiro definido e os demais indefinidos
    endpoints.MapGet("arq/{arquivo}.{ext}", async context => {
        context.Response.ContentType = "text/plain; charset=utf-8";
        await context.Response.WriteAsync("Requisição foi roteada.\n");
        foreach (var item in context.Request.RouteValues)
        {
            await context.Response.WriteAsync($"{item.Key}: {item.Value}\n");
        }
    }); 

    //6) Endpoint que chama Middleware com integração de Endpoint
    //Separação definitiva de responsabilidade 
    //Da maneira implementada pode-se chamar outro Middleware caso especificado na mesma rota
    endpoints.MapGet("pop/{local}", new MiddlewareConsultaPop().Invoke);

    //7) Endpoint que chama Middleware com alto desacoplamento
    //Separação definitiva de responsabilidade
    //Da maneira implementada esse Middleware será Terminal
    //Utilizando o RouteNameMetadata() se precisar alterar a rota 
    //o Middleware dependente mesma não será impactado pelo padão de Injeção de Dependência
    endpoints.MapGet("pop2/{local}", EndpointConsultaPop.Endpoint)
    .WithMetadata(new RouteNameMetadata("consultapop"));

    //7.1) Endpoint utilizando parâmetro com valor padrão se não informado
    endpoints.MapGet("pop3/{local=Fortaleza}", EndpointConsultaPop.Endpoint)
    .WithMetadata(new RouteNameMetadata("consultapop"));

    //7.2) Endpoint utilizando permitindo entrada nula
    endpoints.MapGet("pop4/{local?}", EndpointConsultaPop.Endpoint)
    .WithMetadata(new RouteNameMetadata("consultapop"));

    //7.3) Endpoint definindo que tudo o que vier após o pop5/ é considerado como local
    endpoints.MapGet("pop5/{*local}", EndpointConsultaPop.Endpoint)
    .WithMetadata(new RouteNameMetadata("consultapop"));

    //7.4) Endpoint permitindo a validação do parâmetro, nesse caso utilizando Regex
    endpoints.MapGet("pop6/{local:regex(^\\w{{3}}$)?}", EndpointConsultaPop.Endpoint)
    .WithMetadata(new RouteNameMetadata("consultapop"));

    //7.5) Endpoint permitindo a validação do parâmetro, utilizando uma classe definida
    //Necessário incluir a restrição no Services através de Injeção de Dependência
    endpoints.MapGet("pop7/{local:constraintPop}", EndpointConsultaPop.Endpoint)
    .WithMetadata(new RouteNameMetadata("consultapop"));

    //8)  Endpoint gerando Exceção de ambiguidade de rotas definindo ordem de precendência
    //Isso ocorre por 2 rotas podendo ser acionadas
    endpoints.Map("num/{valor:int}", async context =>{
        await context.Response.WriteAsync("Endpoint para Inteiro");
    }).Add(b => ((RouteEndpointBuilder)b).Order = 1);

    endpoints.Map("num/{valor:double}", async context =>{
        await context.Response.WriteAsync("Endpoint para Double");
    }).Add(b => ((RouteEndpointBuilder)b).Order = 2);
});

/*
* Os modos de integração com o Pipeline de execução da Aplicação
* utilizando Middleware
*/

//1) Middleware implementado via função anônima
//Essa maneira é prática mas possui um forte acoplamento
//A utilização do MapGet() define uma Rota (URL) específica para ser acionado
//O acionamento ocorrerá somente por chamadas GET
app.MapGet("/mapget",() => "Hello, World!");

//2) Middleware implementado em método 
//Essa maneira permite um primeiro nível de desacoplamento da lógica do Middleware
//A utilização do Map() define uma Rota (URL) específica para ser acionado
app.Map("/map", HandleMapTest);

//3) Middleware implementado em classe
//Essa maneira permite um melhor nível de desacoplamento da lógica do Middleware
//Se o Middleware precisar ser acionado por uma rota específica a chamada UseMiddleware()
//não faz nenhum tratamento ficando para o próprio Middleware identificar a URL correspondente
app.UseMiddleware<MiddlewareConsultaCep>();

//4) Middleware implementado por função Anônima
//A utilização do Use() permite encadear os Middlewares para serem executados em sequência
//Esse Middleware não define uma rota específica para ser chamado, ou seja, é sempre executado
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("*** Middleware Função Anônima ***");
    await next();
});

//5) Chamada de Middleware FINAL de implementado com função anônima
//A utilização do Run() executa o Middleware sem nenhuma chamada a outro
//Esse Middleware não define uma rota específica para ser chamado, ou seja, é sempre executado
app.Run(async context => {
    //context.Response.ContentType = "text/plain; charset=utf-8";
    await context.Response.WriteAsync("\n*** Middleware terminal alcançado ***");
});

app.Run();

static void HandleMapTest(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("*** Middleware Map ***");
    });
}