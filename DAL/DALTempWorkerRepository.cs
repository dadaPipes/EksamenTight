using EksamenFinish.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace EksamenFinish.DAL
{
    public class DALTempWorkerRepository : IDisposable, IDALTempWorker
    {
        private readonly DbConnection _connection;
        private readonly DALDatabaseConnection dbConnection;

        public DALTempWorkerRepository(DALDatabaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;

            string connectionString = dbConnection.GetConnectionString();
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        #region CreateTempWorker

        public void CreateTempWorker(MTempWorker mTempWorker)
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO TempWorker (Id, FirstName, LastName, Address, City, ZipCode, PersonalNumber, IsActive) " +
                                      "VALUES (@Id, @FirstName, @LastName, @Address, @City, @ZipCode, @PersonalNumber, @IsActive)";
                command.Parameters.Add(new SqlParameter("@Id", Guid.NewGuid()));
                command.Parameters.Add(new SqlParameter("@FirstName", mTempWorker.FirstName));
                command.Parameters.Add(new SqlParameter("@LastName", mTempWorker.LastName));
                command.Parameters.Add(new SqlParameter("@Address", mTempWorker.Address));
                command.Parameters.Add(new SqlParameter("@City", mTempWorker.City));
                command.Parameters.Add(new SqlParameter("@ZipCode", mTempWorker.ZipCode));
                command.Parameters.Add(new SqlParameter("@PersonalNumber", mTempWorker.PersonalNumber));
                command.Parameters.Add(new SqlParameter("@IsActive", mTempWorker.IsActive));
                command.ExecuteNonQuery();
            }
        }

        #endregion CreateTempWorker

        #region SearchTempWorkers

        public List<MTempWorker> SearchTempWorkers(MTempWorker mTempWorker)
        {
            var mTempWorkers = new List<MTempWorker>();

            using (DbCommand command = _connection.CreateCommand())
            {
                command.Connection = _connection;

                // Start building the query
                var query = "SELECT * FROM TempWorker WHERE 1=1";

                if (!string.IsNullOrEmpty(mTempWorker.FirstName))
                {
                    query += " AND FirstName = @FirstName";
                    command.Parameters.Add(new SqlParameter("@FirstName", mTempWorker.FirstName));
                }

                if (!string.IsNullOrEmpty(mTempWorker.LastName))
                {
                    query += " AND LastName = @LastName";
                    command.Parameters.Add(new SqlParameter("@LastName", mTempWorker.LastName));
                }

                if (!string.IsNullOrEmpty(mTempWorker.City))
                {
                    query += " AND City = @City";
                    command.Parameters.Add(new SqlParameter("@City", mTempWorker.City));
                }

                if (mTempWorker.ZipCode != 0)
                {
                    query += " AND ZipCode = @ZipCode";
                    command.Parameters.Add(new SqlParameter("@ZipCode", mTempWorker.ZipCode));
                }

                if (!string.IsNullOrEmpty(mTempWorker.PersonalNumber))
                {
                    query += " AND PersonalNumber = @PersonalNumber";
                    command.Parameters.Add(new SqlParameter("@PersonalNumber", mTempWorker.PersonalNumber));
                }

                if (mTempWorker.IsActive != null)
                {
                    query += " AND IsActive = @IsActive";
                    command.Parameters.Add(new SqlParameter("@IsActive", mTempWorker.IsActive));
                }

                command.CommandText = query;
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mTempWorkers.Add(new MTempWorker
                        {
                            Id = (Guid)reader["Id"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            Address = (string)reader["Address"],
                            City = (string)reader["City"],
                            ZipCode = (int)reader["ZipCode"],
                            PersonalNumber = (string)reader["PersonalNumber"],
                            IsActive = (bool)reader["IsActive"],
                        });
                    }
                }
            }
            return mTempWorkers;
        }

        #endregion SearchTempWorkers

        #region UpdateWorker

        public void UpdateWorker(MTempWorker mTempWorker)
        {
            try
            {
                using (DbCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "UPDATE TempWorker SET FirstName = @FirstName, LastName = @LastName, Address = @Address, City = @City, ZipCode = @ZipCode, PersonalNumber = @PersonalNumber, IsActive = @IsActive WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@FirstName", mTempWorker.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", mTempWorker.LastName));
                    command.Parameters.Add(new SqlParameter("@Address", mTempWorker.Address));
                    command.Parameters.Add(new SqlParameter("@City", mTempWorker.City));
                    command.Parameters.Add(new SqlParameter("@ZipCode", mTempWorker.ZipCode));
                    command.Parameters.Add(new SqlParameter("@PersonalNumber", mTempWorker.PersonalNumber));
                    command.Parameters.Add(new SqlParameter("@IsActive", mTempWorker.IsActive));
                    command.Parameters.Add(new SqlParameter("@Id", mTempWorker.Id));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion UpdateWorker

        #region DeleteTempWorker

        public void DeleteTempWorker(MTempWorker mTempWorker)
        {
            try
            {
                using (DbCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM TempWorker WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", mTempWorker.Id));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion DeleteTempWorker

        #region Helper Exeption

        private void HandleException(Exception ex)
        {
            // Error message
        }

        #endregion Helper Exeption

        #region Helper Dispose

        
        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        #endregion Helper Dispose
    }
}