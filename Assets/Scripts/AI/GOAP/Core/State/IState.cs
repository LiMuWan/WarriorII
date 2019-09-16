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

        void Copy(IState otherState);

        ICollection<string> GetKeys();

        ICollection<string> GetNotExistKeys(IState otherState);

        ICollection<string> GetValueDifference(IState otherState);

        bool ContainsKey(string key);

        bool ContainState(IState otherState);

        void Clear();

        void AddStateChangeListener(Action onChange);

        IState InversionValue();
    }

    public class State:IState
    {
        private Dictionary<string, bool> _dataTable;

        private Action _onChange;

        public State()
        {
            _dataTable = new Dictionary<string, bool>();
        }

        public void Set(string key, bool value)
        {
            if(_dataTable.ContainsKey(key) && _dataTable[key] != value)
            {
                ChangeValue(key, value);
            }
            else if(!_dataTable.ContainsKey(key))
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
            if(!_dataTable.ContainsKey(key))
            {
                //报错
                DebugMsg.LogError("当前状态不包含此键值:" + key);
                return false;
            }
            else
            {
                return _dataTable[key];
            }
        }

        public ICollection<string> GetKeys()
        {
            return _dataTable.Keys;
        }

        public ICollection<string> GetNotExistKeys(IState otherState)
        {
            List<string> keys = new List<string>();
            foreach (var key in otherState.GetKeys())
            {
                if (!_dataTable.ContainsKey(key))
                {
                    keys.Add(key);
                }
            }

            return keys;
        }

        public ICollection<string> GetValueDifference(IState otherState)
        {
            List<string> keys = new List<string>();
            foreach (var key in otherState.GetKeys())
            {
                if(!_dataTable.ContainsKey(key) || otherState.Get(key) != _dataTable[key])
                {
                    keys.Add(key);
                }
            }

            return keys;
        }

        public bool ContainsKey(string key)
        {
            return _dataTable.ContainsKey(key);
        }

        public bool ContainState(IState otherState)
        {
            foreach (string key in otherState.GetKeys())
            {
                if(!ContainsKey(key) || _dataTable[key] != otherState.Get(key))
                {
                    return false;
                }
            }

            return true;
        }

        public IState InversionValue()
        {
            IState state = new State();
            foreach (KeyValuePair<string,bool> pair in _dataTable)
            {
                state.Set(pair.Key, !pair.Value);
            }
            return state;
        }

        public void Clear()
        {
            _dataTable.Clear();
        }

        public void ChangeValue(string key, bool value)
        {
            _dataTable[key] = value;
            _onChange?.Invoke();
        }

        public void AddStateChangeListener(Action onChange)
        {
            this._onChange = onChange;
        }

        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            foreach (KeyValuePair<string,bool> pair in _dataTable)
            {
                temp.Append("key :");
                temp.Append(pair.Key);
                temp.Append("    Value:");
                temp.Append(pair.Value);
                temp.Append("\r\n");
            }

            return temp.ToString();
        }

        public void Copy(IState otherState)
        {
            Clear();
            Set(otherState);
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

    public static class IStateExtend
    {
        public static IState CreateState(this IState state)
        {
            return new State();
        }
    }
}
