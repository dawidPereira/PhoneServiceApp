using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneService.Infrastructure.Common
{
    public class NullCheckMethod
    {
        public void CheckIfRequestIsNull(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("The Request can not be empty");
        }

        public void CheckIfResponseIsNull(object obj)
        {
            if (obj == null)
                throw new KeyNotFoundException("The Object does not exist");
        }

        public void CheckIfResponseListIsEmpty(IEnumerable<object> obj)
        {
            if (!obj.Any())
                throw new ArgumentNullException("The item list is empty");
        }

        public void CheckIFObjectAlreadyExist(object obj)
        {
            if (obj != null)
                throw new ArgumentException("This object already exist");
        }
    }
}
