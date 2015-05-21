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
            var actors = from actor in contents["actors"]
                         select DeserializeActor(actor as JObject);
            actors.ToList().ForEach(actor => scene.AddActor(actor));

            return scene;
        }

        private Actor DeserializeActor(JObject jobj)
        {
            Actor actor = new Actor((string)jobj["Name"]);

            actor.LocalPosition = jobj["LocalPosition"].ToObject<Vector3>();
            var components = from component in jobj["components"]
                             select DeserializeComponent(component as JObject);
            components.ToList().ForEach(component => actor.AddComponent(component));

            return actor;
        }

        private ActorComponent DeserializeComponent(JObject jobj)
        {
            Type componentType = Type.GetType((string)jobj["__type"]);
            return jobj.ToObject(componentType) as ActorComponent;
        }
    }
}
