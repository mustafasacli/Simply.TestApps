using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;

namespace Mst.Project.Business.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IOfficesBusiness"/>.
    /// </summary>
    public interface IOfficesBusiness
    {
        /// <summary>
        /// The Creates entity for OfficesViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="OfficesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{OfficesViewModel}"/>.</returns>
        SimpleResponse<OfficesViewModel> Create(OfficesViewModel model);

        /// <summary>
        /// The Reads for OfficesViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{OfficesViewModel}"/>.</returns>
        SimpleResponse<OfficesViewModel> Read(string officeCode);

        /// <summary>
        /// Updates entity for OfficesViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="OfficesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(OfficesViewModel model);

        /// <summary>
        /// Deletes entity for OfficesViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="OfficesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(OfficesViewModel model);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(string officeCode);

        /// <summary>
        /// Reads All records for OfficesViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{OfficesViewModel}}"/>.</returns>
        SimpleResponse<List<OfficesViewModel>> ReadAll();
    }
}