using System;
using System.Globalization;

namespace PIT.Business.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public string CreatedAt { get; set; }

        public Entity()
        {
            CreatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }
    }
}
