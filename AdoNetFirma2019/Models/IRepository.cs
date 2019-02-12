using System.Collections.Generic;

namespace AdoNetFirma2019.Models {
    public interface IRepository {
        List<Worker> GetWorkers();
        Worker GetWorker(int id);
        void InsertWorker(Worker worker);
    }
}