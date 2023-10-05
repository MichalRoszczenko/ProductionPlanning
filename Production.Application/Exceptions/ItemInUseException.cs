namespace Production.Application.Exceptions
{
	internal sealed class ItemInUseException : Exception
	{
        public ItemInUseException(string message) : base(message)
        {
            
        }
    }
}
