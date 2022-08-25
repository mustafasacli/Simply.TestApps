using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;

namespace Mst.Project.Business.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IOrdersBusiness"/>.
    /// </summary>
    public interface IOrdersBusiness
    {
        /// <summary>
        /// The Creates entity for OrdersViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="OrdersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{OrdersViewModel}"/>.</returns>
        SimpleResponse<OrdersViewModel> Create(OrdersViewModel model);

        /// <summary>
        /// The Reads for OrdersViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{OrdersViewModel}"/>.</returns>
        SimpleResponse<OrdersViewModel> Read(int orderNumber);

        /// <summary>
        /// Updates entity for OrdersViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="OrdersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(OrdersViewModel model);

        /// <summary>
        /// Deletes entity for OrdersViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="OrdersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(OrdersViewModel model);

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