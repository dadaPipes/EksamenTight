using EksamenFinish.Models;
using System;
using System.Collections.Generic;

namespace EksamenFinish.DAL
{
    public interface IDAL_TempWorker
    {
        void CreateTempWorker(M_TempWorker m_tempWorker);

        List<M_TempWorker> SearchTempWorkers(M_TempWorker dto_tempWorker);

        void UpdateWorker(M_TempWorker dto_tempWorker);

        void DeleteTempWorker(M_TempWorker dto_tempWorker);
    }
}