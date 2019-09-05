using System;
using System.Collections.Generic;

namespace GOAP
{
    public interface IState     
    {
        void Set(string key, bool value);

        void Set(IState otherState);

        bool Get(string key);

        ICollection<string> GetKeys();

        void AddStateChangeListener(Action onChange);
    }

    public class State:IState
    {
        private Dictionary<string, bool> dataTable;

        private Action onChange;

        public State()
        {
            dataTable = new Dictionary<string, bool>();
        }

        public void Set(string key, bool value)
        {
            if(dataTable.ContainsKey(key) && dataTable[key] != value)
            {
                ChangeValue(key, value);
            }
            else if(!dataTable.ContainsKey(key))
            {
                ChangeValue(key, value);
            }
        }

        public void Set(IState otherState)
        {
            foreach (string key in otherState.GetKeys())
            {
                Set(key, Get(key));
            }
        }

        public bool Get(string key)
        {
            if(!dataTable.ContainsKey(key))
            {
                //报错
                DebugMsg.LogError("当前状态不包含此键值:" + key);
                return false;
            }
            else
            {
                return dataTable[key];
            }
        }

        public ICollection<string> GetKeys()
        {
            return dataTable.Keys;
        }

        public void ChangeValue(string key, bool value)
        {
            dataTable[key] = value;
            onChange?.Invoke();
        }  

        public void AddStateChangeListener(Action onChange)
        {
            this.onChange = onChange;
        }

    }
}
