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
    /// Defines the <see cref="PaymentsBusiness"/>.
    /// </summary>
    public class PaymentsBusiness : SimpleBaseBusiness, IPaymentsBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsBusiness"/> class.
        /// </summary>
        public PaymentsBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for PaymentsViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="PaymentsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{PaymentsViewModel}"/>.</returns>
        public SimpleResponse<PaymentsViewModel> Create(PaymentsViewModel model)
        {
            var response = new SimpleResponse<PaymentsViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<PaymentsViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = Map<PaymentsViewModel, Payments>(model);
                    context.Payments.Add(entity);
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
        /// The Reads for PaymentsViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{PaymentsViewModel}"/>.</returns>
        public SimpleResponse<PaymentsViewModel> Read(int customerNumber, string checkNumber)
        {
            var response = new SimpleResponse<PaymentsViewModel>();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = context.Payments
                        .AsNoTracking()
                        .SingleOrDefault(q => q.CustomerNumber == customerNumber && q.CheckNumber == checkNumber);

                    if (entity == null || entity == default(Payments))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kay�t bulunamad�.";
                        return response;
                    }

                    response.Data = Map<Payments, PaymentsViewModel>(entity);
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
        /// Updates entity for PaymentsViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="PaymentsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(PaymentsViewModel model)
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
                    var entity = context.Payments.SingleOrDefault(q => q.CustomerNumber == model.CustomerNumber && q.CheckNumber == model.CheckNumber);
                    if (entity == null || entity == default(Payments))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kay�t bulunamad�.";
                        return response;
                    }

                    MapTo(model, entity);
                    // context.Payments.Attach(entity);
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
        /// Deletes entity for PaymentsViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="PaymentsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(PaymentsViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = context.Payments.FirstOrDefault(q => q.CustomerNumber == model.CustomerNumber && q.CheckNumber == model.CheckNumber);
                    if (entity == null || entity == default(Payments))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kay�t bulunamad�.";
                        return response;
                    }

                    context.Payments.Remove(entity);
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
        public SimpleResponse Delete(int customerNumber, string checkNumber)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = context.Payments.SingleOrDefault(q => q.CustomerNumber == customerNumber && q.CheckNumber == checkNumber);
                    if (entity == null || entity == default(Payments))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kay�t bulunamad�.";
                        return response;
                    }

                    context.Payments.Remove(entity);
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
        /// Reads All records for PaymentsViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{PaymentsViewModel}}"/>.</returns>
        public SimpleResponse<List<PaymentsViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<PaymentsViewModel>>();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entities = context.Payments
                        .AsNoTracking()
                        .ToList() ?? new List<Payments>();

                    response.Data = MapList<Payments, PaymentsViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma i�leminde hata olu�tu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<PaymentsViewModel>();
            return response;
        }
    }
}