using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;

namespace Mst.Project.BusinessCore.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IOrdersBusiness"/>.
    /// </summary>
    public interface IOrdersBusiness
    {
        /// <summary>
        /// The Creates entity for OrdersViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OrdersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{OrdersViewModel}"/>.</returns>
        SimpleResponse<OrdersViewModel> Create(OrdersViewModel viewModel);

        /// <summary>
        /// The Reads for OrdersViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{OrdersViewModel}"/>.</returns>
        SimpleResponse<OrdersViewModel> Read(int orderNumber);

        /// <summary>
        /// Updates entity for OrdersViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OrdersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(OrdersViewModel viewModel);

        /// <summary>
        /// Deletes entity for OrdersViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="OrdersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(OrdersViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int orderNumber);

        /// <summary>
        /// Reads All records for OrdersViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{OrdersViewModel}}"/>.</returns>
        SimpleResponse<List<OrdersViewModel>> ReadAll();
    }
}