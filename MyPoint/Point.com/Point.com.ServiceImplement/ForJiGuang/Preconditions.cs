using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.ServiceImplement.ForJiGuang
{
    class Preconditions
    {
        public static void checkArgument(bool expression)
        {
            if (!expression)
            {
                throw new ArgumentNullException();
            }
        }
        public static void checkArgument(bool expression, object errorMessage)
        {
            if (!expression)
            {
                throw new ArgumentException(errorMessage.ToString());
            }
        }
    }
}
