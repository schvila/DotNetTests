// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using System.Linq;
using Duplicates;


List<Person> persons = new List<Person>()
{
    new Person() { Id = 1, Name = "Jedna" },
    new Person() { Id = 2, Name = "Dve" },
    new Person() { Id = 3, Name = "Tri" },
    new Person() { Id = 1, Name = "Ctyri" },
};

List<Person> persons2 = new List<Person>()
{
    new Person() { Id = 4, Name = "4Jedna" },
    new Person() { Id = 5, Name = "5Dve" },
    new Person() { Id = 6, Name = "6Tri" },
    new Person() { Id = 1, Name = "1Ctyri" },
};

List<Person> dist = new List<Person>();
var uni = persons.UnionBy(persons2, p=>p.Id).OrderByDescending(o=>o.Name);
foreach (var p in uni)
{
    Console.WriteLine(p.Name);
}
var cnt = persons.DistinctBy(p=>p.Id).Count();
Console.WriteLine($"Total={persons.Count()}, distinct={cnt}");