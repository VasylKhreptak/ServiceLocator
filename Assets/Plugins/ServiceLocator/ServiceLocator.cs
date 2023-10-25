using System;
using System.Collections.Generic;

namespace Plugins.ServiceLocator
{
    public class ServiceLocator<T> : IServiceLocator<T>
    {
        private readonly Dictionary<Type, T> _itemsMap = new Dictionary<Type, T>();

        public TS Register<TS>(TS service) where TS : T
        {
            Type type = service.GetType();

            if (_itemsMap.ContainsKey(type))
                throw new ArgumentException($"Service of type {type} already registered");

            _itemsMap.Add(type, service);
            return service;
        }

        public void Unregister<TS>(TS service) where TS : T
        {
            Type type = service.GetType();

            if (_itemsMap.ContainsKey(type))
                _itemsMap.Remove(type);
        }

        public TS Get<TS>() where TS : T
        {
            Type type = typeof(TS);

            if (_itemsMap.TryGetValue(type, out T service))
                return (TS)service;

            throw new Exception($"There is no service of type {type} in service locator");
        }

        public bool TryGet<TS>(out TS service) where TS : T
        {
            Type type = typeof(TS);

            if (_itemsMap.TryGetValue(type, out T baseService))
            {
                service = (TS)baseService;
                return true;
            }

            service = default;
            return false;
        }
    }
}