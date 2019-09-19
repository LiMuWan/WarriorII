﻿using System;
using System.Collections.Generic;

namespace GOAP
{
    public class ObjectPool    
    {
        private Dictionary<Type, List<object>> _activeDic;
        private Dictionary<Type, List<object>> _inactiveDic;

        private static ObjectPool _instance;

        public static ObjectPool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ObjectPool();
                return _instance;
            }
        }

        public T Spaw<T> (params object[] args) where T : class
        {
            Type type = typeof(T);
            object temp = null;
            if(_inactiveDic.ContainsKey(type))
            {
                if(_inactiveDic[type].Count > 0)
                {
                    temp = _inactiveDic[type][0];
                    _inactiveDic[type].Remove(temp);
                }
            }
            else
            {
                _inactiveDic[type] = new List<object>();
            }

            temp = SpawNew(type, args);

            if (!_activeDic.ContainsKey(type))
                _activeDic[type] = new List<object>();
            _activeDic[type].Add(temp);

            return temp as T;
        }

        public void Despawn<T>(T obj)
        {
            Type type = typeof(T);

            if(_activeDic.ContainsKey(type))
            {
                if(_activeDic[type].Contains(obj))
                {
                    _activeDic[type].Remove(obj);
                    _inactiveDic[type].Add(obj);
                }
                else
                {
                    DebugMsg.LogError(obj + "此对象不在当前活跃对象缓存中");
                }
            }
            else
            {
                DebugMsg.LogError(type + "此类型不在当前活跃对象缓存中");
            }
        }

        private object SpawNew(Type type,params object[] args)
        {
            return Activator.CreateInstance(type, args);
        }
    }
}
