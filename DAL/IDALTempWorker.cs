using EksamenFinish.Models;
using System;
using System.Collections.Generic;

namespace EksamenFinish.DAL
{
    public interface IDALTempWorker
    {
        void CreateTempWorker(MTempWorker mTempWorker);

        List<MTempWorker> SearchTempWorkers(MTempWorker mTempWorker);

        void UpdateWorker(MTempWorker mTempWorker);

        void DeleteTempWorker(MTempWorker mTempWorker);
    }
}