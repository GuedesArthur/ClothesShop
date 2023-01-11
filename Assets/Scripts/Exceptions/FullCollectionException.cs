public class FullCollectionException : System.Exception
{
    public readonly int maxQuantity;
    public FullCollectionException(string collectionName, int maxQuantity)
        : base($"Collection {collectionName} is Full [{maxQuantity}]!")
            => this.maxQuantity = maxQuantity;
}
