using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PIT.Business
{
    public class EntityHistory<T> where T : class
    {
        private T _entity;
        private readonly Dictionary<PropertyInfo, object> _values = new Dictionary<PropertyInfo, object>(); 

        public EntityHistory(T entity)
        {
            Initialize(entity);
        }

        private void Initialize(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity", "Entity cannot be null");

            _entity = entity;
            _values.Clear();

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite);
            foreach (var prop in properties)
                _values[prop] = prop.GetValue(_entity, null);
        }

        public void Restore()
        {
            foreach (var pair in _values)
                pair.Key.SetValue(_entity, pair.Value, null);   
        }

        public bool ValueChanged(string propertyName)
        {
            var prop = _values.FirstOrDefault(k => k.Key.Name == propertyName);
            var prop2 = typeof (T).GetProperty(propertyName);

            return !prop.Value.Equals(prop2.GetValue(_entity, null));
        }
    }
}