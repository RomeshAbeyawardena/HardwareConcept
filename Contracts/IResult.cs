namespace sInference.Contracts
{
    public interface IResult
    {
        byte Pin { get; }
        long Code { get; }
        long Result { get; }
    }
}
