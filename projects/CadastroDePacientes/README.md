<a name="readme-top"></a>
# Controle de Pacientes
<table>
<tr>
<td>
  Esse é um modelo de projeto tipo CRUD utilizando uma arquitetura de Serviços (API).<br>
  São disponibilizados dois cadastros relacionais de Convênio e Paciente.
	
  <h3><a name="readme-architecture">Arquitetura</a></h3>
  <ul>
    <li>API: Microsoft ASP .NET 7</li>
    <li>UI: Angular 16</li>
    <li>BD: SQL Server Express Edition</li>
  </ul>
</td>
</tr>
</table>

<h2>Conteúdo</h2>
  <ol>
    <li><a href="#readme-rules">Regras de Negócio</a></li>
    <li><a href="#readme-components">Componentes Técnicos</a></li>
    <li><a href="#readme-howto">Como Utilizar</a></li>
    <li><a href="#readme-contact">Contato</a></li>
</ol>

# ![WebApp](https://github.com/wtlmarco/CadastroDePacientes/assets/128224724/907e36bc-bb2e-4e23-8a71-0da4a85ff47a)

<h2>📋<a name="readme-rules">Regras de Negócio</a></h2>
<ul>
  <li>Um usuário deve conseguir cadastrar um novo paciente e editar um paciente existente, mas não deve ser possível excluir um cadastro.</li>
  <li>O sistema deve garantir que não haja cadastros duplicados utilizando CPF como identificação única, caso este esteja preenchido (não obrigatório).</li>
  <li>O convênio deve ser selecionado em uma lista, buscando da tabela de convênios.</li>
  <li>O sistema deve garantir as validações pertinentes a cada tipo de dados, como por exemplo:
    <br>
  - CPF: número válido e único na base de dados 
    <br>
	- Celular ou telefone fixo: ao menos um dos campos preenchido com número válido
  </li>
</ul>

<p align="right">(<a href="#readme-top">topo</a>)</p>

<h2>🛠️<a name="readme-components">Componentes Técnicos</a></h2>

<h3>API</h3>

![image](https://github.com/wtlmarco/CadastroDePacientes/assets/128224724/e3fdcd37-e612-4588-8a37-0ae08cab0689)

<ul>
  <li>[Data Access com Entity Framework] (https://learn.microsoft.com/en-us/aspnet/entity-framework)</li>
  <li>[Logging com nLog] (https://nlog-project.org/)</li>
  <li>[Validation com FluentValidation] (https://docs.fluentvalidation.net/en/latest/)</li>
</ul>

<h3>DATABASE</h3>

![image](https://github.com/wtlmarco/CadastroDePacientes/assets/128224724/8b7c04cb-ceac-41f3-a248-7cbf35cb18a0)

<h3>UI</h3>
<ul>
  <li>[Bootstrap 5] (https://getbootstrap.com/)</li>
  <li>[iMask] (https://imask.js.org/)</li>
</ul>

<p align="right">(<a href="#readme-top">topo</a>)</p>

<h2>📦<a name="readme-howto">Como Utilizar</a></h2>

<h3>ControleDePaciente.API</h3>

1 - Abra a solução do projeto no Visual Studio 2022
<br><br>
2 - Atualize a Connection String no arquivo appsettings.json conforme o exemplo abaixo

```
"ConnectionStrings": {
    "Default": "server=.\\sqlexpress;database=CadastroDePacientes;User Id=user_CadastroDePacientes;Password=user_CadastroDePacientes; TrustServerCertificate=True"
  }
```

3 - O local de armazenamento dos Logs estão configurados no arquivo nlog.config

```
<target xsi:type="File" name="fileTarget"
          fileName="${basedir}/logs/${shortdate}.log"
          layout="${longdate} ${uppercase:${level}} ${message}"
    archiveEvery="Day"
/>
```

4 - Faça a criação da Base de Dados através do Console Package Manager

```
PM> dotnet ef database update
```

5 - Execute a aplicação com o comando <b>Ctrl + F5</b>, será aberta uma janela do navegador com o Swagger

<h3>ControleDePaciente.UI</h3>
1 - Abra o projeto no Visual Studio Code
<br><br>
2 - Identifique a  porta utilizada pela API na URL do navegador <br><br>

3 - Acesse a pasta src/environments e altere o parâmetro baseApiUrl conforme o exemplo abaixo

```
export const environment = {
    production: false,
    baseApiUrl: 'https://localhost:7295'
};
```

4 - Execute a aplicação com o comando no <b>Terminal</b>

```
ng serve -o

```

<p align="right">(<a href="#readme-top">topo</a>)</p>

---|---
<h2>✒️<a name="readme-contact">Contato</a></h2>
Entre em contato: <a href="mailto:developer@wtlmarco.com" target="_blank">developer@wtlmarco.com</a>

[<img src = "https://img.shields.io/badge/wtlmarco.com-gray.svg?&style=for-the-badge&logoColor=white">](https://www.wtlmarco.com) [<img src = "https://img.shields.io/badge/github-black.svg?&style=for-the-badge&logo=github&logoColor=white">](https://github.com/wtlmarco) [<img src="https://img.shields.io/badge/linkedin-%230077B5.svg?&style=for-the-badge&logo=linkedin&logoColor=white" />](https://www.linkedin.com/in/marco-antonio-amaral-santos-b5b3b3199) [<img src = "https://img.shields.io/badge/instagram-%23E4405F.svg?&style=for-the-badge&logo=instagram&logoColor=white">](https://www.instagram.com/wtlmarcosd/) 

<p align="right">(<a href="#readme-top">topo</a>)</p>
