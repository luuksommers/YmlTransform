using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YmlTransform.Exceptions
{
    public class IncompleteTransformationException : Exception
    {
        public IncompleteTransformationException()
        { }

        public IncompleteTransformationException(string message) : base(message)
        { }
    }
}
