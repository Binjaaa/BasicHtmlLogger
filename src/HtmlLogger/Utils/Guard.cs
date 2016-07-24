namespace HtmlLogger.Utils
{
    using System;

    internal class Guard
    {
        private static Guard _against;

        public static Guard Against
        {
            get
            {
                if (_against == null)
                {
                    _against = new Guard();
                }

                return _against;
            }
        }

        public void Null(string name, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        public void NullOrEmpty(string name, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException($"string value is null or empty: {name}");
            }
        }
    }
}