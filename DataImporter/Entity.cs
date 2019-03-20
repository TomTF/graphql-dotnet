using System;

namespace DataImporter
{
    internal class Entity : IEquatable<Entity>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return (obj as Entity)?.Id == this.Id;
        }

        public bool Equals(Entity other)
        {
            return other.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}