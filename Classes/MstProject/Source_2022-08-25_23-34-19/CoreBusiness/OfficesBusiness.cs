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
    /// Defines the <see cref="OfficesBusiness"/>.
    /// </summary>
    public class OfficesBusiness : SimpleBaseBusiness, IOfficesBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OfficesBusiness"/> class.
        /// </summary>
        public OfficesBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for OfficesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OfficesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{OfficesViewModel}"/>.</returns>
        public SimpleResponse<OfficesViewModel> Create(OfficesViewModel model)
        {
            var response = new SimpleResponse<OfficesViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<OfficesViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = Map<OfficesViewModel, Offices>(model);
                    context.Offices.Add(entity);
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
        /// The Reads for OfficesViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{OfficesViewModel}"/>.</returns>
        public SimpleResponse<OfficesViewModel> Read(string officeCode)
        {
            var response = new SimpleResponse<OfficesViewModel>();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = context.Offices
                        .AsNoTracking()
                        .FirstOrDefault(q => q.OfficeCode == officeCode);

                    if (entity == null || entity == default(Offices))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Offices, OfficesViewModel>(entity);
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
        /// Updates entity for OfficesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OfficesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(OfficesViewModel model)
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
                    var entity = context.Offices.SingleOrDefault(q => q.OfficeCode == model.OfficeCode);
                    if (entity == null || entity == default(Offices))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    context.Offices.Attach(entity);
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
        /// Deletes entity for OfficesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OfficesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(OfficesViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = context.Offices.SingleOrDefault(q => q.OfficeCode == model.OfficeCode);
                    if (entity == null || entity == default(Offices))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Offices.Remove(entity);
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
        public SimpleResponse Delete(string officeCode)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entity = context.Offices.SingleOrDefault(q => q.OfficeCode == officeCode);
                    if (entity == null || entity == default(Offices))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Offices.Remove(entity);
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
        /// Reads All records for OfficesViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{OfficesViewModel}}"/>.</returns>
        public SimpleResponse<List<OfficesViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<OfficesViewModel>>();

            try
            {
                using (var context = new ClassicmodelsCoreDbContext())
                {
                    var entities = context.Offices
                        .AsNoTracking()
                        .ToList() ?? new List<Offices>();

                    response.Data = MapList<Offices, OfficesViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<OfficesViewModel>();
            return response;
        }
    }
}