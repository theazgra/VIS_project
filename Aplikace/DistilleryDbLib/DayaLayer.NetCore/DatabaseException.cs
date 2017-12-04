using System;
namespace DataLayerNetCore
{
    public class DatabaseException : Exception
    {
        public string ExceptionText { get; private set; }
        public DatabaseException(string msg)
        {
            ExceptionText = msg;
        }

        public DatabaseException(int errorCode = 0)
        {
            switch (errorCode)
            {
                case 0:
                    ExceptionText = "No connection to database was open!";
                    break;
                case 1:
                    ExceptionText = "Can not open connection to the database!";
                    break;
            }
            
        }

        public override string Message
        {
            get
            {
                return ExceptionText;
            }
        }
    }
}
