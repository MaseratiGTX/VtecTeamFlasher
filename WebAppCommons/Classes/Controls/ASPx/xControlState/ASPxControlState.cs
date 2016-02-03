using System.Collections.Generic;
using Commons.Helpers.Objects;
using Commons.Serialization;

namespace WebAppCommons.Classes.Controls.ASPx.xControlState
{
    public class ASPxControlState
    {
        private Dictionary<string, object> StateRepository { get; set; }



        public ASPxControlState()
        {
            StateRepository = new Dictionary<string, object>();
        }

        public ASPxControlState(Dictionary<string, object> stateRepository)
        {
            StateRepository = stateRepository;
        }

        public ASPxControlState(string state)
        {
            Load(state);
        }



        public void Clear()
        {
            StateRepository.Clear();
        }


        public T Get<T>(string key)
        {
            return Get(key, default(T));
        }

        public T Get<T>(string key, T defaultValue)
        {
            if (StateRepository.ContainsKey(key) == false)
            {
                Put(key, defaultValue);
            }

            return StateRepository[key].As<T>();
        }

        public void Put(string key, object value)
        {
            StateRepository[key] = value;
        }

        
        public string Save()
        {
            return StateRepository.SerializeToJSON();
        }

        public void Load(string state)
        {
            StateRepository = state.DeserializeFromJSON<Dictionary<string, object>>();
        }
    }
}