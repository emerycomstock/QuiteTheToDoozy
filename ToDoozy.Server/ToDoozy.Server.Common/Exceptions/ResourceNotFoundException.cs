namespace ToDoozy.Server.Common.Exceptions
{
    /**
     * Indicates a resource could not be located, results in 404 response when API handler catches.
     */
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message) : base(message)
        { }
    }
}
