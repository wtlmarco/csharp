// See https://aka.ms/new-console-template for more information
using ConsoleAPP;
using System;

//var result = await Lab.GetDirectly("http://www.macoratti.net/vbn_jqsm.htm").ConfigureAwait(false);

//var result = await Lab.GetUsingExplicitRequest("http://webcode.me/qs.php").ConfigureAwait(false);

//var result = await Lab.GetUsingExplicitResponse(
//	"https://jsonplaceholder.typicode.com/users").ConfigureAwait(false);

//var result = await Lab.GetByPath<Contributor>("https://api.github.com/","repos/symfony/symfony/contributors").ConfigureAwait(false);

//var result = await Lab.GetByProxy("http://webcode.me", "example.com", 7302).ConfigureAwait(false);

//var result = await Lab.GetFile("http://webcode.me/favicon.ico").ConfigureAwait(false);

//var result = await Lab.GetStream("https://cdn.netbsd.org/pub/NetBSD/NetBSD-9.2/images/NetBSD-9.2-amd64-install.img.gz").ConfigureAwait(false);

var result = await Lab.GetWithAuthorization("https://httpbin.org/basic-auth/user7/passwd","user7","passwd").ConfigureAwait(false);

//var result = await Lab.PostByData<Contributor>(
//	"https://httpbin.org/post", 
//	new Contributor("aureliano@teste.com",345)
//	).ConfigureAwait(false);

//var result = await Lab.PostByForm(
//	"https://httpbin.org/post",
//	new Dictionary<string, string> {
//		{"name", "John Doe" },
//		{"occupation", "gardener" }
//	}).ConfigureAwait(false);

Console.WriteLine(result);

Console.ReadLine();

record Contributor(string Login, short Contributions);