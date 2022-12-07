using System;

namespace Utilities
{
    public class ObjectAbstract
    {
        public int Id { set; get; }

        public object Objeto { set; get; }

        public ObjectAbstract()
        {
            this.Id = 0;
            this.Objeto = null;
        }
    }
}