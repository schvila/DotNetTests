using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample HTML code to parse
            string html = @"<p>Hello World!</p><p><br data-cke-filler=""true""></p>";

            // Use HtmlAgilityPack to parse the HTML
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Use a recursive function to extract all of the HTML elements
            // List<HtmlNode> elements = GetAllElements(doc.DocumentNode);
            var elements = doc.DocumentNode.SelectNodes("/*").Where(n=>!string.IsNullOrWhiteSpace(n.InnerText));

            // Print out all of the HTML elements
            foreach (HtmlNode element in elements)
            {
                Console.WriteLine(element.Name + " :: ");
                Console.WriteLine(element.InnerHtml);
            }
        }

        static List<HtmlNode> GetAllElements(HtmlNode node)
        {
            // Create a list to hold the extracted elements
            List<HtmlNode> elements = new List<HtmlNode>();

            // Add the current node to the list
            elements.Add(node);

            // Recursively extract the child nodes of the current node
            foreach (HtmlNode child in node.ChildNodes)
            {
                elements.AddRange(GetAllElements(child));
            }

            return elements;
        }
    }
}