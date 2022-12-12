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
            string html = @"<p>&nbsp;</p>
<p><br data-cke-filler=""true""></p>
                <h3>&nbsp;</h3>
                <h3>Davam H1</h3>
                <h4>Pak H2</h4>
                <p>Zde je novy Title pro dFw v2</p>
                <ol><li>one</li><li>two</li><li>three</li></ol>
                ";

            // Use HtmlAgilityPack to parse the HTML
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Use a recursive function to extract all of the HTML elements
            // List<HtmlNode> elements = GetAllElements(doc.DocumentNode);
            var elements = doc.DocumentNode.SelectNodes("/*").Where(n=>(n.Name == "p" && 
                                                                        !string.IsNullOrWhiteSpace(n.InnerText) &&
                                                                        n.InnerText !="&nbsp;"));

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