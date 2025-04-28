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
                        return false;
                }
            }
            catch 
            {
                return false;
            }
        }
    }
}