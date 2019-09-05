using System;
using System.Collections.Generic;
using System.Text;

namespace GOAP
{
    public interface IState     
    {
        void Set(string key, bool value);

        void Set(IState otherState);

        bool Get(string key);

        ICollection<string> GetKeys();

        bool ContainsKey(string key);

        bool ContainState(IState otherState);

        void Clear();

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
                //����
                DebugMsg.LogError("��ǰ״̬�������˼�ֵ:" + key);
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

        public bool ContainsKey(string key)
        {
            return dataTable.ContainsKey(key);
        }

        public bool ContainState(IState otherState)
        {
            foreach (string key in otherState.GetKeys())
            {
                if(!ContainsKey(key) || dataTable[key] != otherState.Get(key))
                {
                    return false;
                }
            }

            return true;
        }

        public void Clear()
        {
            dataTable.Clear();
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

        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            foreach (KeyValuePair<string,bool> pair in dataTable)
            {
                temp.Append("key :");
                temp.Append(pair.Key);
                temp.Append("    Value:");
                temp.Append(pair.Value);
                temp.Append("\r\n");
            }

            return temp.ToString();
        }
    }

    public class State<TKey> : State
    {
        public State() : base() { }

        public void Set(TKey key,bool value)
        {
            base.Set(key.ToString(),value);
        }

        public bool Get(TKey key)
        {
            return base.Get(key.ToString());
        }
        
        public bool ContainsKey(TKey key)
        {
            return base.ContainsKey(key.ToString());
        }

    }
}
