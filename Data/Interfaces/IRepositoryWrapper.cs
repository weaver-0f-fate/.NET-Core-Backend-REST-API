namespace Data.Interfaces {
    public interface IRepositoryWrapper {
        public IOperationsRepository Operations { get; }
        public IOperationTypesRepository OperationTypes { get; }
    }
}
