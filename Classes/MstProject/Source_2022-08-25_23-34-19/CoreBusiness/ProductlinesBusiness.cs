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
    /// Defines the <see cref="ProductlinesBusiness"/>.
    /// </summary>
    public class ProductlinesBusiness : SimpleBaseBusiness, IProductlinesBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductlinesBusiness"/> class.
        /// </summary>
        public ProductlinesBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for ProductlinesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ProductlinesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{ProductlinesViewModel}"/>.</returns>
        public SimpleResponse<ProductlinesViewModel> Create(ProductlinesViewModel model)
        {
            var response = new SimpleResponse<ProductlinesViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<ProductlinesViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = Map<ProductlinesViewModel, Productlines>(model);
                    context.Productlines.Add(entity);
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
        /// The Reads for ProductlinesViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{ProductlinesViewModel}"/>.</returns>
        public SimpleResponse<ProductlinesViewModel> Read(string productLine)
        {
            var response = new SimpleResponse<ProductlinesViewModel>();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = context.Productlines
                        .AsNoTracking()
                        .FirstOrDefault(q => q.ProductLine == productLine);

                    if (entity == null || entity == default(Productlines))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Productlines, ProductlinesViewModel>(entity);
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
        /// Updates entity for ProductlinesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ProductlinesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(ProductlinesViewModel model)
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
                    var entity = context.Productlines.SingleOrDefault(q => q.ProductLine == model.ProductLine);
                    if (entity == null || entity == default(Productlines))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    context.Productlines.Attach(entity);
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
        /// Deletes entity for ProductlinesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ProductlinesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(ProductlinesViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = context.Productlines.SingleOrDefault(q => q.ProductLine == model.ProductLine);
                    if (entity == null || entity == default(Productlines))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Productlines.Remove(entity);
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
        public SimpleResponse Delete(string productLine)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = context.Productlines.SingleOrDefault(q => q.ProductLine == productLine);
                    if (entity == null || entity == default(Productlines))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Productlines.Remove(entity);
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
        /// Reads All records for ProductlinesViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{ProductlinesViewModel}}"/>.</returns>
        public SimpleResponse<List<ProductlinesViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<ProductlinesViewModel>>();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entities = context.Productlines
                        .AsNoTracking()
                        .ToList() ?? new List<Productlines>();

                    response.Data = MapList<Productlines, ProductlinesViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<ProductlinesViewModel>();
            return response;
        }
    }
}