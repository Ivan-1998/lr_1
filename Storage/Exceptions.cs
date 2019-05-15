namespace lab1.Storage
{
    [System.Serializable]
    public class IncorrectLab1DataException : System.Exception
    {
        public IncorrectLab1DataException() { }
        public IncorrectLab1DataException(string message) : base(message) { }
        public IncorrectLab1DataException(string message, System.Exception inner) : base(message, inner) { }
        protected IncorrectLab1DataException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}