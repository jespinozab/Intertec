// See https://aka.ms/new-console-template for more information
using CodeChallengeConsole;
using System;

string input = "";
string output = "";

// If the args are coming empty, it can be read from the command line
if (args.Length > 0)
{
    // If the args don't come with "", this join them so it can be processed as a paragraph
    input = string.Join(" ", args);
}
else
{
    Console.WriteLine("Enter a sentence to parse (or 'exit' to quit):");
    input = Console.ReadLine();
}

var callService = new CallService();
string apiUrl = callService.GetHttpsApiUrl(input);
await callService.ExecuteCall(input, output, apiUrl);
Console.WriteLine(output);

