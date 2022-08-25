using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;

namespace Mst.Project.BusinessCore.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IOfficesBusiness"/>.
    /// </summary>
    public interface IOfficesBusiness
    {
        /// <summary>
        /// The Creates entity for OfficesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OfficesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{OfficesViewModel}"/>.</returns>
        SimpleResponse<OfficesViewModel> Create(OfficesViewModel viewModel);

        /// <summary>
        /// The Reads for OfficesViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{OfficesViewModel}"/>.</returns>
        SimpleResponse<OfficesViewModel> Read(string officeCode);

        /// <summary>
        /// Updates entity for OfficesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OfficesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(OfficesViewModel viewModel);

        /// <summary>
        /// Deletes entity for OfficesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OfficesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(OfficesViewModel viewModel);

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