using System;
using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public interface IState     
    {
        void SetState(string key, bool value);

        bool GetValue(string key);

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

        public void SetState(string key, bool value)
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

        public bool GetValue(string key)
        {
            if(!dataTable.ContainsKey(key))
            {
                //±¨´í
                return false;
            }
            else
            {
                return dataTable[key];
            }
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
