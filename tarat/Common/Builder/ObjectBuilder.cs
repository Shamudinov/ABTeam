using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Builder
{
    public class ObjectBuilder<T> where T : new()
    {
        static T obj;

        public static T Build()
        {
            if (obj == null)
            {
                obj = new T();
            }

            return obj;
        }
    }
}
