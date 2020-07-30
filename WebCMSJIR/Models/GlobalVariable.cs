using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCMSJIR.Models
{
    public static class GlobalVariable
    {
        static string _importantData = null;
        static string m_globalVar = "";
        public static string GlobalVar
        {
            get { return m_globalVar; }
            set { m_globalVar = value; }
        }
        public static string ImportantData
        {
            get
            {
                return _importantData;
            }
            set
            {
                _importantData = value;
            }
        }
    }
}
