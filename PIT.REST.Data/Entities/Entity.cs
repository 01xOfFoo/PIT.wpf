using System;
using System.Globalization;

namespace PIT.REST.Data.Entities
{
    public class Entity
    {
        protected Entity()
        {
            CreatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }

        public bool Exists()
        {
            return (Id != 0);
        }

        public int Id { get; set; }
        public string CreatedAt { get; set; }
    }
}