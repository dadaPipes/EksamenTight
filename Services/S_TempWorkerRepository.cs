using EksamenFinish.DAL;
using EksamenFinish.Models;
using EksamenFinish.ViewModels;
using System.Collections.Generic;


namespace EksamenFinish.Services
{
    // Responsible for interacting with the DAL_TempWorkerRepository class for data access and CRUD operations on TempWorker data.

    public class S_TempWorkerRepository
    {
        #region Fields

        private DAL_TempWorkerRepository _dal;
        private VM_TempWorkerValidation vm_TempWorkerValidation;
        private M_TempWorker m_tempWorker;

        private S_TempWorkerMapper s_tempWorkerMapper;

        #endregion Fields

        public S_TempWorkerRepository()
        {
            _dal = new DAL_TempWorkerRepository();
            s_tempWorkerMapper = new S_TempWorkerMapper(vm_TempWorkerValidation);
        }

        #region SearchTempWorkers

        public List<VM_TempWorker> SearchTempWorkers(VM_TempWorker vm_tempWorker)
        {
            m_tempWorker = s_tempWorkerMapper.MapViewModelToModel(vm_tempWorker);

            // Search for temp workers using the dto_tempWorker
            List<M_TempWorker> m_tempWorkers = _dal.SearchTempWorkers(m_tempWorker);

            // Map the dto_tempWorkers to a list of vm_tempWorkers
            List<VM_TempWorker> vm_tempWorkers = s_tempWorkerMapper.MapModelListToViewModelList(m_tempWorkers);

            return vm_tempWorkers;
        }


        #endregion SearchTempWorkers

        #region CreateTempWorker

        /// <summary>
        /// Takes an object of type DTO_TempWorker as an input and creates a new TempWorker record in the database
        /// using the _dal object's CreateTempWorker method.
        /// </summary>

        public void CreateTempWorker(VM_TempWorker vm_tempWorker)
        {
            // Map the TempWorkerViewModel properties to the tempWorkerDTO object
            m_tempWorker = s_tempWorkerMapper.MapViewModelToModel(vm_tempWorker);

            _dal.CreateTempWorker(m_tempWorker);
        }

        #endregion CreateTempWorker

        #region UpdateTempWorker

        /// <summary>
        /// Takes an object of type DTO_TempWorker as an input and
        /// updates an existing TempWorker record in the database using the _dal object's UpdateWorker method.
        /// </summary>

        public void UpdateTempWorker(VM_TempWorker vm_tempWorker)
        {
            // Map the TempWorkerViewModel properties to the tempWorkerDTO object
            m_tempWorker = s_tempWorkerMapper.MapViewModelToModel(vm_tempWorker);

            _dal.UpdateWorker(m_tempWorker);
        }

        #endregion UpdateTempWorker

        #region DeleteTempWorker

        /// <summary>
        /// Takes the id of a TempWorker as an input and deletes the corresponding worker record from the database
        /// using the _dal object's DeleteTempWorker method.
        /// </summary>

        public void DeleteTempWorker(VM_TempWorker vm_tempWorker)
        {
            m_tempWorker = s_tempWorkerMapper.MapViewModelToModel(vm_tempWorker);

            _dal.DeleteTempWorker(m_tempWorker);
        }

        #endregion DeleteTempWorker
    }
}