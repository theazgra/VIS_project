using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistilleryDbLib
{
    public class DatabaseException : Exception
    {
        public string exceptionText { get; private set; }
        public DatabaseException(string msg)
        {
            exceptionText = msg;
        }

        public DatabaseException(int errorCode = 0)
        {
            switch (errorCode)
            {
                case 0:
                    exceptionText = "No connection to database was open!";
                    break;
                case 1:
                    exceptionText = "Can not open connection to the database!";
                    break;
            }
            
        }

        public override string Message
        {
            get
            {
                return exceptionText;
            }
        }
    }
}
