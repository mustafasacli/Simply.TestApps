using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;

namespace Mst.Project.BusinessCore.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IOrderdetailsBusiness"/>.
    /// </summary>
    public interface IOrderdetailsBusiness
    {
        /// <summary>
        /// The Creates entity for OrderdetailsViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OrderdetailsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{OrderdetailsViewModel}"/>.</returns>
        SimpleResponse<OrderdetailsViewModel> Create(OrderdetailsViewModel viewModel);

        /// <summary>
        /// The Reads for OrderdetailsViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{OrderdetailsViewModel}"/>.</returns>
        SimpleResponse<OrderdetailsViewModel> Read(int orderNumber, string productCode);

        /// <summary>
        /// Updates entity for OrderdetailsViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OrderdetailsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(OrderdetailsViewModel viewModel);

        /// <summary>
        /// Deletes entity for OrderdetailsViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OrderdetailsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(OrderdetailsViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int orderNumber, string productCode);

        /// <summary>
        /// Reads All records for OrderdetailsViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{OrderdetailsViewModel}}"/>.</returns>
        SimpleResponse<List<OrderdetailsViewModel>> ReadAll();
    }
}