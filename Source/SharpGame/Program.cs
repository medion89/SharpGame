using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Reflection;

namespace SharpGame
{
    class Program
    {
        struct TestStruct
        {
            public string nameField;
            public string stringProp { get; set; }
            public int intField;
            public int intProp { get; set; }
            public bool boolField;
            public bool boolProp { get; set; }
            public Vector3 vec;
        }

        static void Main(string[] args)
        {
            TestActorsSearching();

            //***** Actor A *****//
            Actor actorA = new Actor("ActorB");
            ColoredText coloredTextA = new ColoredText();
            coloredTextA.Text = new char[,] {
                { '#', '#', '#'},
                { '#', 'A', '#'},
                { '#', '#', '#'}
            };
            coloredTextA.ForegroundColor = System.ConsoleColor.Cyan;
            coloredTextA.BackgroundColor = System.ConsoleColor.DarkGray;

            TestComponentB testComponentA = new TestComponentB();
            testComponentA.Direction = new Vector3(1, 1, 0).Normalized;
            testComponentA.Speed = 1f;

            actorA.AddComponent(coloredTextA);
            actorA.AddComponent(testComponentA);
            actorA.LocalPosition = new Vector3(5, 5, 0);

            //***** Actor B *****//
            Actor actorB = new Actor("ActorB");
            ColoredText coloredTextB = new ColoredText();
            coloredTextB.Text = new char[,] {
                { '#', '#', '#'},
                { '#', 'B', '#'},
                { '#', '#', '#'}
            };
            coloredTextB.ForegroundColor = System.ConsoleColor.DarkGray;
            coloredTextB.BackgroundColor = System.ConsoleColor.Cyan;

            TestComponentB testComponentB = new TestComponentB();
            testComponentB.Direction = new Vector3(1, 1, 0).Normalized;
            testComponentB.Speed = 1f;

            actorB.AddComponent(coloredTextB);
            actorB.AddComponent(testComponentB);
            actorB.LocalPosition = new Vector3(10, 10, 0);

            TestStruct obj = new TestStruct()
            {
                nameField = "Genrih",
                stringProp = "Venna",
                intField = 42,
                intProp = 33,
                boolField = true,
                boolProp = false,
                vec = new Vector3(3, 2, 1)
            };

            File.WriteAllText("./actorB.actor", SerializeObject(obj));

            //***** Scene Setup *****//
            Scene scene = new Scene();
            actorA.AddChild(actorB);
            scene.AddActor(actorA);

            actorB.WorldPosition = Vector3.Zero;


            //***** Game Setup *****//
            Game game = new Game();
            game.TargetFPS = 60;
            game.Initialize();
            game.Run(scene);
        }

        public static string SerializeObject(object obj)
        {
            if (obj == null)
                return "null";

            Type type = obj.GetType();

            if (type == typeof(bool))
                return ((bool)obj) ? "true" : "false";
            else if (type.IsPrimitive)
                return obj.ToString();
            else if (type == typeof(string))
                return string.Format("\"{0}\"", obj.ToString());

            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (var field in fields)
            {
                sb.AppendFormat("\"{0}\": {1}, ", field.Name, SerializeObject(field.GetValue(obj)));
            }

            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
            {
                if (property.CanRead && property.CanWrite)
                    sb.AppendFormat("\"{0}\": {1}, ", property.Name, SerializeObject(property.GetValue(obj)));
            }

            // remove trailing comma, if object has no members to serialize - harmless whitespace will get deleted
            sb.Remove(sb.Length - 2, 1);
            sb.Append(" }");
            return sb.ToString();
        }

        public static TObject DeserializeObject<TObject>(string data) where TObject : class, new()
        {
            return null;
        }

        public static void TestActorsSearching()
        {
            const int TEST_ACTORS_CNT = 5;
            Actor nodeI = new Actor("Node I");
            Actor nodeIIA = new Actor("Node II A");
            Actor nodeIIB = new Actor("Node II B");
            Actor nodeIIIA = new Actor("Node III A");
            Actor nodeIIIB = new Actor("Node III B");

            Scene scene = new Scene();

            nodeIIB.AddChild(nodeIIIA);
            nodeIIB.AddChild(nodeIIIB);
            nodeI.AddChild(nodeIIA);
            nodeI.AddChild(nodeIIB);
            scene.AddActor(nodeI);

            Debug.Assert(scene.FindActor(actor => actor.Name == nodeIIIB.Name) == nodeIIIB);
            Debug.Assert(scene.FindActor(actor => actor.Name == nodeIIA.Name) == nodeIIA);
            Debug.Assert(scene.FindAllActors(actor => actor.Name.Contains("Node")).Count == TEST_ACTORS_CNT);
            var foundActors = scene.FindAllActors(actor => actor.Name.Contains("A"));
            Debug.Assert(foundActors.Count == 2 && foundActors.Contains(nodeIIA) && foundActors.Contains(nodeIIIA));
        }
    }
}
