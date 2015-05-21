using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpGame
{
    public class SceneLoader : IResourceLoader
    {
        public object LoadResource(string path)
        {
            Scene scene = new Scene();

            JObject contents = JObject.Parse(File.ReadAllText(path));
            var actors = from actor in contents["__actors"]
                         select DeserializeActor(actor as JObject);
            actors.ToList().ForEach(actor => scene.AddActor(actor));

            return scene;
        }

        private Actor DeserializeActor(JObject jobj)
        {
            Actor actor = jobj.ToObject<Actor>();

            var components = from component in jobj["__components"]
                             select DeserializeComponent(component as JObject);
            components.ToList().ForEach(component => actor.AddComponent(component));

            var children = from child in jobj["__children"]
                           select DeserializeActor(child as JObject);
            children.ToList().ForEach(child => actor.AddChild(child));

            return actor;
        }

        private ActorComponent DeserializeComponent(JObject jobj)
        {
            Type componentType = Type.GetType((string)jobj["__type"]);
            return jobj.ToObject(componentType) as ActorComponent;
        }
    }
}
