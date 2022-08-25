using Mst.Project.BusinessCore.Interfaces;
using Mst.Project.CoreContext;
using Mst.Project.Entity;
using Mst.Project.ViewModel;
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
    /// Defines the <see cref="OrderdetailsBusiness"/>.
    /// </summary>
    public class OrderdetailsBusiness : SimpleBaseBusiness, IOrderdetailsBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderdetailsBusiness"/> class.
        /// </summary>
        public OrderdetailsBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for OrderdetailsViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OrderdetailsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{OrderdetailsViewModel}"/>.</returns>
        public SimpleResponse<OrderdetailsViewModel> Create(OrderdetailsViewModel model)
        {
            var response = new SimpleResponse<OrderdetailsViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<OrderdetailsViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = Map<OrderdetailsViewModel, Orderdetails>(model);
                    context.Orderdetails.Add(entity);
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
        /// The Reads for OrderdetailsViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{OrderdetailsViewModel}"/>.</returns>
        public SimpleResponse<OrderdetailsViewModel> Read(int orderNumber, string productCode)
        {
            var response = new SimpleResponse<OrderdetailsViewModel>();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = context.Orderdetails
                        .AsNoTracking()
                        .FirstOrDefault(q => q.OrderNumber == orderNumber && q.ProductCode == productCode);

                    if (entity == null || entity == default(Orderdetails))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Orderdetails, OrderdetailsViewModel>(entity);
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
        /// Updates entity for OrderdetailsViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OrderdetailsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(OrderdetailsViewModel model)
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
                    var entity = context.Orderdetails.SingleOrDefault(q => q.OrderNumber == model.OrderNumber && q.ProductCode == model.ProductCode);
                    if (entity == null || entity == default(Orderdetails))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    context.Orderdetails.Attach(entity);
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
        /// Deletes entity for OrderdetailsViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OrderdetailsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(OrderdetailsViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = context.Orderdetails.SingleOrDefault(q => q.OrderNumber == model.OrderNumber && q.ProductCode == model.ProductCode);
                    if (entity == null || entity == default(Orderdetails))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Orderdetails.Remove(entity);
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
        public SimpleResponse Delete(int orderNumber, string productCode)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = context.Orderdetails.SingleOrDefault(q => q.OrderNumber == orderNumber && q.ProductCode == productCode);
                    if (entity == null || entity == default(Orderdetails))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Orderdetails.Remove(entity);
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
        /// Reads All records for OrderdetailsViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{OrderdetailsViewModel}}"/>.</returns>
        public SimpleResponse<List<OrderdetailsViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<OrderdetailsViewModel>>();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entities = context.Orderdetails
                        .AsNoTracking()
                        .ToList() ?? new List<Orderdetails>();

                    response.Data = MapList<Orderdetails, OrderdetailsViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<OrderdetailsViewModel>();
            return response;
        }
    }
}