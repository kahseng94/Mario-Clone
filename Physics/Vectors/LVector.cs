namespace Sprint5.Physics.Vectors
{
    public interface LVector<T>
    {
        T Vector { get; set; }

        void Add(T vector);

        void Scl(T vector);

        void Limit();
    }
}
