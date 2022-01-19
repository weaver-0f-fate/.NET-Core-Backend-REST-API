namespace Services.Interfaces {
    public interface IServiceWrapper {
        public IOperationsService OperationsService { get; }
        public IOperationTypesService OperationTypesService { get; }
    }
}
