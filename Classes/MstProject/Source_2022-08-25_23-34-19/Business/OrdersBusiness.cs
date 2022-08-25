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
    /// Defines the <see cref="OrdersBusiness"/>.
    /// </summary>
    public class OrdersBusiness : SimpleBaseBusiness, IOrdersBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersBusiness"/> class.
        /// </summary>
        public OrdersBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for OrdersViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="OrdersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{OrdersViewModel}"/>.</returns>
        public SimpleResponse<OrdersViewModel> Create(OrdersViewModel model)
        {
            var response = new SimpleResponse<OrdersViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<OrdersViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = Map<OrdersViewModel, Orders>(model);
                    context.Orders.Add(entity);
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
        /// The Reads for OrdersViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{OrdersViewModel}"/>.</returns>
        public SimpleResponse<OrdersViewModel> Read(int orderNumber)
        {
            var response = new SimpleResponse<OrdersViewModel>();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = context.Orders
                        .AsNoTracking()
                        .SingleOrDefault(q => q.OrderNumber == orderNumber);

                    if (entity == null || entity == default(Orders))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Orders, OrdersViewModel>(entity);
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
        /// Updates entity for OrdersViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="OrdersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(OrdersViewModel model)
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
                    var entity = context.Orders.SingleOrDefault(q => q.OrderNumber == model.OrderNumber);
                    if (entity == null || entity == default(Orders))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    // context.Orders.Attach(entity);
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
        /// Deletes entity for OrdersViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="OrdersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(OrdersViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = context.Orders.FirstOrDefault(q => q.OrderNumber == model.OrderNumber);
                    if (entity == null || entity == default(Orders))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Orders.Remove(entity);
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
        public SimpleResponse Delete(int orderNumber)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = context.Orders.SingleOrDefault(q => q.OrderNumber == orderNumber);
                    if (entity == null || entity == default(Orders))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Orders.Remove(entity);
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
        /// Reads All records for OrdersViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{OrdersViewModel}}"/>.</returns>
        public SimpleResponse<List<OrdersViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<OrdersViewModel>>();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entities = context.Orders
                        .AsNoTracking()
                        .ToList() ?? new List<Orders>();

                    response.Data = MapList<Orders, OrdersViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<OrdersViewModel>();
            return response;
        }
    }
}