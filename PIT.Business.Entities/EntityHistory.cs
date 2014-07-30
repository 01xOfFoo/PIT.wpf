using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PIT.Business.Entities
{
    public class EntityHistory<T> where T : class
    {
        private readonly Dictionary<PropertyInfo, object> _values = new Dictionary<PropertyInfo, object>();
        private T _entity;

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

            IEnumerable<PropertyInfo> properties =
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite);
            foreach (PropertyInfo prop in properties)
                _values[prop] = prop.GetValue(_entity, null);
        }

        public void Restore()
        {
            foreach (var pair in _values)
                pair.Key.SetValue(_entity, pair.Value, null);
        }
    }
}