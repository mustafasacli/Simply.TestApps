using Mst.Project.BusinessCore.Interfaces;
using Mst.Project.CoreContext;
using Mst.Project.Entity;
using Mst.Project.ViewModel;
using Gsb.Common.Core;
using SimpleFileLogging;
using Microsoft.EntityFrameworkCore;
using SimpleInfra.Common.Response;
using SimpleInfra.Mapping;
using SimpleInfra.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mst.Project.BusinessCore
{
    /// <summary>
    /// Defines the <see cref="EmployeesBusiness"/>.
    /// </summary>
    public class EmployeesBusiness : SimpleBaseBusiness, IEmployeesBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesBusiness"/> class.
        /// </summary>
        public EmployeesBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for EmployeesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="EmployeesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{EmployeesViewModel}"/>.</returns>
        public SimpleResponse<EmployeesViewModel> Create(EmployeesViewModel model)
        {
            var response = new SimpleResponse<EmployeesViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<EmployeesViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = Map<EmployeesViewModel, Employees>(model);
                    context.Employees.Add(entity);
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Ekleme iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// The Reads for EmployeesViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{EmployeesViewModel}"/>.</returns>
        public SimpleResponse<EmployeesViewModel> Read(int employeeNumber)
        {
            var response = new SimpleResponse<EmployeesViewModel>();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = context.Employees
                        .AsNoTracking()
                        .FirstOrDefault(q => q.EmployeeNumber == employeeNumber);

                    if (entity == null || entity == default(Employees))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Employees, EmployeesViewModel>(entity);
                    response.ResponseCode = 1;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Updates entity for EmployeesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="EmployeesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(EmployeesViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse
                    {
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = context.Employees.SingleOrDefault(q => q.EmployeeNumber == model.EmployeeNumber);
                    if (entity == null || entity == default(Employees))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    context.Employees.Attach(entity);
                    // context.Entry(entity).State = EntityState.Modified;
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Deletes entity for EmployeesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="EmployeesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(EmployeesViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = context.Employees.SingleOrDefault(q => q.EmployeeNumber == model.EmployeeNumber);
                    if (entity == null || entity == default(Employees))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Employees.Remove(entity);
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(int employeeNumber)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = context.Employees.SingleOrDefault(q => q.EmployeeNumber == employeeNumber);
                    if (entity == null || entity == default(Employees))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Employees.Remove(entity);
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Reads All records for EmployeesViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{EmployeesViewModel}}"/>.</returns>
        public SimpleResponse<List<EmployeesViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<EmployeesViewModel>>();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entities = context.Employees
                        .AsNoTracking()
                        .ToList() ?? new List<Employees>();

                    response.Data = MapList<Employees, EmployeesViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<EmployeesViewModel>();
            return response;
        }
    }
}