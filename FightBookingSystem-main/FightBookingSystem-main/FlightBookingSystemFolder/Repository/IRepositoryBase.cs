using System.Collections.Generic;


namespace FlightBookingSystemFolder.Repository
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetModel();
        T GetModelbyID(int modelId);
        void InsertModel(T model);
        void UpdateModel(T model);
    }
}
