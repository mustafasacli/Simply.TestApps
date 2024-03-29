using Mst.Project.Business.Interfaces;
using Mst.Project.Context;
using Mst.Project.Entity;
using Mst.Project.ViewModel;
using SimpleFileLogging;
using SimpleInfra.Common.Core;
using SimpleInfra.Common.Response;
using SimpleInfra.Business.Core;
using SimpleInfra.Mapping;
using SimpleInfra.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Mst.Project.Business
{
    /// <summary>
    /// Defines the <see cref="CustomersBusiness"/>.
    /// </summary>
    public class CustomersBusiness : SimpleBaseBusiness, ICustomersBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersBusiness"/> class.
        /// </summary>
        public CustomersBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for CustomersViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="CustomersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{CustomersViewModel}"/>.</returns>
        public SimpleResponse<CustomersViewModel> Create(CustomersViewModel model)
        {
            var response = new SimpleResponse<CustomersViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<CustomersViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = Map<CustomersViewModel, Customers>(model);
                    context.Customers.Add(entity);
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Ekleme i�leminde hata olu�tu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// The Reads for CustomersViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{CustomersViewModel}"/>.</returns>
        public SimpleResponse<CustomersViewModel> Read(int customerNumber)
        {
            var response = new SimpleResponse<CustomersViewModel>();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = context.Customers
                        .AsNoTracking()
                        .SingleOrDefault(q => q.CustomerNumber == customerNumber);

                    if (entity == null || entity == default(Customers))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kay�t bulunamad�.";
                        return response;
                    }

                    response.Data = Map<Customers, CustomersViewModel>(entity);
                    response.ResponseCode = 1;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma i�leminde hata olu�tu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Updates entity for CustomersViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="CustomersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(CustomersViewModel model)
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

                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = context.Customers.SingleOrDefault(q => q.CustomerNumber == model.CustomerNumber);
                    if (entity == null || entity == default(Customers))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kay�t bulunamad�.";
                        return response;
                    }

                    MapTo(model, entity);
                    // context.Customers.Attach(entity);
                    // context.Entry(entity).State = EntityState.Modified;
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "G�ncelleme i�leminde hata olu�tu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Deletes entity for CustomersViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="CustomersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(CustomersViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = context.Customers.FirstOrDefault(q => q.CustomerNumber == model.CustomerNumber);
                    if (entity == null || entity == default(Customers))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kay�t bulunamad�.";
                        return response;
                    }

                    context.Customers.Remove(entity);
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme i�leminde hata olu�tu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(int customerNumber)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = context.Customers.SingleOrDefault(q => q.CustomerNumber == customerNumber);
                    if (entity == null || entity == default(Customers))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kay�t bulunamad�.";
                        return response;
                    }

                    context.Customers.Remove(entity);
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme i�leminde hata olu�tu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Reads All records for CustomersViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{CustomersViewModel}}"/>.</returns>
        public SimpleResponse<List<CustomersViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<CustomersViewModel>>();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entities = context.Customers
                        .AsNoTracking()
                        .ToList() ?? new List<Customers>();

                    response.Data = MapList<Customers, CustomersViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma i�leminde hata olu�tu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<CustomersViewModel>();
            return response;
        }
    }
}