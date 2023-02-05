using EksamenFinish.DAL;
using EksamenFinish.Models;
using EksamenFinish.ViewModels;
using System.Collections.Generic;

namespace EksamenFinish.Services
{
    // Responsible for interacting with the DAL_TempWorkerRepository class for data access and CRUD operations on TempWorker data.

    public class STempWorkerRepository
    {
        private DALTempWorkerRepository _dalRepo;
        private IMapViewModelToModel<MTempWorker, VMTempWorker> _mapToModel;
        private IMapModelToViewModel<MTempWorker, VMTempWorker> _mapToViewModel;

        public STempWorkerRepository(DALTempWorkerRepository dal, IMapModelToViewModel<MTempWorker, VMTempWorker> mapToViewModel, IMapViewModelToModel<MTempWorker, VMTempWorker> mapToModel)
        {
            _dalRepo = dal;
            _mapToModel = mapToModel;
            _mapToViewModel = mapToViewModel;
        }

        public void CreateTempWorker(VMTempWorker vmTempWorker)
        {
            MTempWorker mTempWorker = _mapToModel.MapToModel(vmTempWorker);

            _dalRepo.CreateTempWorker(mTempWorker);
        }

        public List<VMTempWorker> SearchTempWorkers(VMTempWorker vmTempWorker)
        {
            MTempWorker m_tempWorker = _mapToModel.MapToModel(vmTempWorker);

            List<MTempWorker> mTempWorkers = _dalRepo.SearchTempWorkers(m_tempWorker);

            return _mapToViewModel.MapToViewModelList(mTempWorkers);
        }

        public void UpdateTempWorker(VMTempWorker vmTempWorker)
        {
            MTempWorker mTempWorker = _mapToModel.MapToModel(vmTempWorker);

            _dalRepo.UpdateWorker(mTempWorker);
        }

        public void DeleteTempWorker(VMTempWorker vmTempWorker)
        {
            MTempWorker mTempWorker = _mapToModel.MapToModel(vmTempWorker);

            _dalRepo.DeleteTempWorker(mTempWorker);
        }
    }
}