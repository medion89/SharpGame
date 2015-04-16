namespace GameFramework.Internal
{
    public interface IComposed<TParent> where TParent : class
    {
        TParent Parent { get; set; }
    }
}
