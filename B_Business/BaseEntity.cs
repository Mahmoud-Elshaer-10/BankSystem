using System;

namespace B_Business
{
    public abstract class BaseEntity<T>
    {
        public EntityMode Mode { get; set; } = EntityMode.AddNew;

        public abstract T ToDTO();
        protected abstract bool AddNew();
        protected abstract bool Update();

        public bool Save()
        {
            try
            {
                Validate();
                switch (Mode)
                {
                    case EntityMode.AddNew:
                        if (AddNew())
                        {
                            Mode = EntityMode.Update;
                            return true;
                        }
                        return false;
                    case EntityMode.Update:
                        return Update();
                    default:
                        throw new InvalidOperationException("Invalid entity mode.");
                }
            }
            catch (Exception ex)
            {
                throw new EntityOperationException("Failed to save entity.", ex);
            }
        }

        protected virtual void Validate()
        {
            // Derived classes override for specific validation
        }
    }

    public class EntityOperationException : Exception
    {
        public EntityOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}