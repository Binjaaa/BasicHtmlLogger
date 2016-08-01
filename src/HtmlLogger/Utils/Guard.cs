namespace HtmlLogger.Utils
{
    using System;

    internal class Guard
    {
        #region Fields

        private static Guard _against;

        #endregion Fields

        #region Properties

        public static Guard Against
        {
            get
            {
                _against = _against ?? new Guard();

                return _against;
            }
        }

        #endregion Properties

        #region Methods

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

        #endregion Methods
    }
}