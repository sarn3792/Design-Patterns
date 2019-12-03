using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace DesignPatterns.SOLID
{
    // hl modules should not depend on low-level; both should depend on abstractions
    // abstractions should not depend on details; details should depend on abstractions

    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
        // public DateTime DateOfBirth;
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    public class Relationships : IRelationshipBrowser // low-level
    {
        private List<(Person, Relationship, Person)> relations
          = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public List<(Person, Relationship, Person)> Relations => relations;

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations
              .Where(x => x.Item1.Name == name
                          && x.Item2 == Relationship.Parent).Select(r => r.Item3);
        }

        internal void AddParentAndChild(DesignPatterns.Person parent, DesignPatterns.Person child1)
        {
            throw new NotImplementedException();
        }
    }

    public class Research
    {
        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
            {
                WriteLine($"John has a child called {p.Name}");
            }
        }
    }
}
