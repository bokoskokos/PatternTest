using MyPegasus.Common.Common;

namespace MyPegasus.DomainModel.Factories
{
    public abstract class FactoryBase
    {
        protected T Return<T>(IOperationResponse<T> response)
            where T : class
        {
            if (!response.IsOk)
            {
                throw new MyPegasusFactoryException<T>(response.Message);
            }

            return response.Payload;
        }
    }
}
