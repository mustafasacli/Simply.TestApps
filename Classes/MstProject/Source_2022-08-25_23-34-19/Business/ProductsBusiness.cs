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
    /// Defines the <see cref="ProductsBusiness"/>.
    /// </summary>
    public class ProductsBusiness : SimpleBaseBusiness, IProductsBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsBusiness"/> class.
        /// </summary>
        public ProductsBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for ProductsViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="ProductsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{ProductsViewModel}"/>.</returns>
        public SimpleResponse<ProductsViewModel> Create(ProductsViewModel model)
        {
            var response = new SimpleResponse<ProductsViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<ProductsViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = Map<ProductsViewModel, Products>(model);
                    context.Products.Add(entity);
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
        /// The Reads for ProductsViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{ProductsViewModel}"/>.</returns>
        public SimpleResponse<ProductsViewModel> Read(string productCode)
        {
            var response = new SimpleResponse<ProductsViewModel>();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = context.Products
                        .AsNoTracking()
                        .SingleOrDefault(q => q.ProductCode == productCode);

                    if (entity == null || entity == default(Products))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Products, ProductsViewModel>(entity);
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
        /// Updates entity for ProductsViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="ProductsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(ProductsViewModel model)
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
                    var entity = context.Products.SingleOrDefault(q => q.ProductCode == model.ProductCode);
                    if (entity == null || entity == default(Products))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    // context.Products.Attach(entity);
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
        /// Deletes entity for ProductsViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="ProductsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(ProductsViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = context.Products.FirstOrDefault(q => q.ProductCode == model.ProductCode);
                    if (entity == null || entity == default(Products))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Products.Remove(entity);
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
        public SimpleResponse Delete(string productCode)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entity = context.Products.SingleOrDefault(q => q.ProductCode == productCode);
                    if (entity == null || entity == default(Products))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Products.Remove(entity);
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
        /// Reads All records for ProductsViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{ProductsViewModel}}"/>.</returns>
        public SimpleResponse<List<ProductsViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<ProductsViewModel>>();

            try
            {
                using (var context = new ClassicmodelsDbContext())
                {
                    var entities = context.Products
                        .AsNoTracking()
                        .ToList() ?? new List<Products>();

                    response.Data = MapList<Products, ProductsViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<ProductsViewModel>();
            return response;
        }
    }
}