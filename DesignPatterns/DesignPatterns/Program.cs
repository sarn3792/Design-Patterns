﻿using DesignPatterns.SOLID;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SOLID
            #region SRP
            /*
            var j = new Journal();
            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");
            WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename);
            Process.Start(filename);
            */
            #endregion

            #region OPC
            /*
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            WriteLine("Green products (old):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
                WriteLine($" - {p.Name} is green");

            // ^^ BEFORE

            // vv AFTER
            var bf = new BetterFilter();
            WriteLine("Green products (new):");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
                WriteLine($" - {p.Name} is green");

            WriteLine("Large products");
            foreach (var p in bf.Filter(products, new SizeSpecification(Size.Large)))
                WriteLine($" - {p.Name} is large");

            WriteLine("Large blue items");
            foreach (var p in bf.Filter(products,
              new AndSpecification(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large)))
            )
            {
                WriteLine($" - {p.Name} is big and blue");
            }
            */
            #endregion

            #region LSP
            /*
            Rectangle rc = new Rectangle(2, 3);
            WriteLine($"{rc} has area {Operations.Area(rc)}");

            // should be able to substitute a base type for a subtype
            // Square
            Rectangle sq = new Square();
            sq.Width = 4;
            WriteLine($"{sq} has area {Operations.Area(sq)}");
            */
            #endregion

            #region DIP
            /*
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Matt" };

            // low-level module
            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
            */

            #endregion

            #endregion

            #region Creationals
            #region Builder
            #region CreationalBuilder
            /*
            // if you want to build a simple HTML paragraph using StringBuilder
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            WriteLine(sb);

            // now I want an HTML list with 2 words in it
            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
            WriteLine(sb);

            // ordinary non-fluent builder
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            WriteLine(builder);

            // fluent builder
            sb.Clear();
            builder.Clear(); // disengage builder from the object it's building, then...
            builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
            WriteLine(builder);
            */
            #endregion
            #region CreationalBuilderInheritance
            /*
            var me = Person.New
                   .Called("Dmitri")
                   .WorksAsA("Quant")
                   .Born(DateTime.UtcNow)
                   .Build();
            Console.WriteLine(me);
            */
            #endregion
            #region FunctionalBuilder
            // var pb = new Functional.PersonBuilder();
            // var person = pb.Called("Dmitri").WorksAsA("Programmer").Build();
            // var person2 = Functional.PersonBuilderExtensions.WorksAsA(pb, "Developer").Called("Dmitri").Build();
            // Console.WriteLine(person2.Name);
            // Console.WriteLine(person2.Position);
            #endregion
            #region FacetedBuilder
            /*
            var pb = new Facaded.PersonBuilder();
            Facaded.Person person = pb
              .Lives
                .At("123 London Road")
                .In("London")
                .WithPostcode("SW12BC")
              .Works
                .At("Fabrikam")
                .AsA("Engineer")
                .Earning(123000);

            WriteLine(person);
            */

            #endregion
            #region FinalBuilder
            /*
            var builder = new CodeBuilder("Date");
            builder.AddField("year", "int").AddField("month", "string");
            Console.WriteLine(builder.ToString());
            */
            #endregion
            #endregion
            #region Factory
            /*
            var machine = new HotDrinkMachine();
            //var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 300);
            //drink.Consume();

            IHotDrink drink = machine.MakeDrink();
            drink.Consume();
            */
            #endregion
            #region Prototype
            /*
            var line1 = new Line
            {
                Start = new Point { X = 3, Y = 3 },
                End = new Point { X = 10, Y = 10 }
            };
            */
            #endregion
            #region Singleton
            /*
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            WriteLine($"{city} has population {db.GetPopulation(city)}");
            */
            #endregion
            #endregion

            #region Structurals

            #region Adapter
            #region NoCaching
            /*
            DesignPatterns.Structurals.Demo.Draw();
            DesignPatterns.Structurals.Demo.Draw();
            */
            #endregion

            #region Caching
            /*
            DesignPatterns.Structurals.WithCaching.Demo.Draw();
            DesignPatterns.Structurals.WithCaching.Demo.Draw();
            */
            #endregion

            #region Generic
            /*
            var v = new DesignPatterns.Structurals.Generic.Vector2i(1, 2);
            v[0] = 0;

            var vv = new DesignPatterns.Structurals.Generic.Vector2i(3, 2);

            var result = v + vv;

            DesignPatterns.Structurals.Generic.Vector3f u = DesignPatterns.Structurals.Generic.Vector3f.Create(3.5f, 2.2f, 1);
            */
            #endregion

            #region DI
            // for each ICommand, a ToolbarButton is created to wrap it, and all
            // are passed to the editor
            /*
            var b = new ContainerBuilder();
            b.RegisterType<OpenCommand>()
              .As<ICommand>()
              .WithMetadata("Name", "Open");
            b.RegisterType<SaveCommand>()
              .As<ICommand>()
              .WithMetadata("Name", "Save");
            //b.RegisterType<Button>();
            b.RegisterAdapter<ICommand, Button>(cmd => new Button(cmd, ""));
            b.RegisterAdapter<Meta<ICommand>, Button>(cmd =>
              new Button(cmd.Value, (string)cmd.Metadata["Name"]));
            b.RegisterType<Editor>();
            using (var c = b.Build())
            {
                var editor = c.Resolve<Editor>();
                editor.ClickAll();

                // problem: only one button

                foreach (var btn in editor.Buttons)
                    btn.PrintMe();
            }
            */
            #endregion
            #endregion

            #region Bridge
            Console.WriteLine(new DesignPatterns.Structurals.Bridge.Square(new DesignPatterns.Structurals.Bridge.VectorRenderer()).ToString());
            Console.WriteLine(new DesignPatterns.Structurals.Bridge.Triangle(new DesignPatterns.Structurals.Bridge.RasterRenderer()).ToString());
            #endregion

            #endregion
            Console.ReadKey();
        }
    }
}
