namespace Parsian.DomainModel.Seedworks;

public class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
        this.Messages = new List<string>()
        {
            message
        };
    }

    public IList<string> Messages { get; private set; }

    public void AddMessage(string message)
    {
        this.Messages.Add(message);
    }
}