﻿using Dapper;
using EmployeeCashAdvance.Dapper.Interface;
using EmployeeCashAdvanceApp.Domain.Models;
using EmployeeCashAdvanceApp.Domain.Shared.Constants;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCashAdvance.Dapper.DapperRepository
{
    public class EmployeeDetailsRepository : IEmployeeDetails
    {
        public async  Task<IEnumerable<EmployeeDetails>> GetAll()
        {
            try
            {
                using SqlConnection connection = new(Constants.DB_CONNECTION);
                await connection.OpenAsync();
                var list = await connection.QueryAsync<EmployeeDetails>("dbo.spGetEmployee");
                

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
