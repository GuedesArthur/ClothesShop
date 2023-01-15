
/// <summary>
/// Collection exceeded its maximum capacity!
/// </summary>
public class FullCollectionException : System.Exception
{
    public readonly int maxCapacity;
    public FullCollectionException(string collectionName, int maxCapacity)
        : base($"Collection {collectionName} is Full [{maxCapacity}]!")
            => this.maxCapacity = maxCapacity;
}
