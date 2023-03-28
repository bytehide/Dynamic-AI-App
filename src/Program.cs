// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using Test;

OpenAIAPI api = new OpenAIAPI("TODO: SET OPEN AI API KEY HERE"); // shorthand

var source = "";

Console.WriteLine("Creating source code with AI...");

await api.Completions.StreamCompletionAsync(
    new CompletionRequest("Create a example code for c# application that write in the console: 'I am dynamic app from AI' and ask for a number in the console and multiply it by 5", Model.DavinciText, 2000, 0.5, presencePenalty: 0.1, frequencyPenalty: 0.1),
    res => source += res.ToString());

var compiler = new Compiler();
var runner = new Runner();

Console.WriteLine("Source code created.");

Console.WriteLine("Compiling...");


byte[] compiled = compiler.Compile(source);
string[] none = Array.Empty<string>();

Console.Clear();

runner.Execute(compiled, none);

Console.ReadLine();


