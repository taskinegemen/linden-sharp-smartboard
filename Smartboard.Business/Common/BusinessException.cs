using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartboard.Business.Common
{
    public class BusinessException: Exception
    {
        private List<string> errorList = new List<string>();

        public BusinessException()
        {
        }

        public BusinessException(string error)
        {
            this.errorList.Add(error);
        }

        public BusinessException(List<string> errorList)
        {
            this.errorList = errorList;
        }

        public List<string> Messages
        {
            get { return errorList; }
        }

        public string Message
        {
            get
            {
                if(this.errorList.Count > 0)
                {
                    return errorList[0];
                }
                return String.Empty;
            }
        }

    }
}
