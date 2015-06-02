using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGame
{
    class serialisation
    {
        public static JObject ToJson (Scene scene)
        {
            var array = new JArray();
            foreach (var actor in scene.Actors)
                array.Add(ToJson(actor));
            var Jscene = JObject.FromObject(scene);
            Jscene.Add("__actors", array);
            return Jscene;
        }

        public static JObject ToJson(Actor actor)
        {
            var Jactor = JObject.FromObject(actor);

            if (actor.Children.Count > 0)
            {
                var array = new JArray();
                foreach (var actchild in actor.Children)
                    array.Add(ToJson(actchild));
                Jactor.Add("__childrens", array);
            }

            if(actor.Component.Count>0)
            {
                var array = new JArray();
                foreach (var comp in actor.Component)
                    array.Add(ToJson(comp));
                Jactor.Add("__components", array);
            }
            return Jactor;
        }

        public static JObject ToJson(ActorComponent comp)
        {
            var Jtype = new JObject();
            Jtype.Add("__type", comp.GetType().FullName);
            Jtype.Merge(JObject.FromObject(comp));
            return Jtype;
        }
        
    }
}
