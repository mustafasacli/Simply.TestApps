using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;

namespace Mst.Project.Business.Interfaces
{
    /// <summary>
    /// Defines the <see cref="ICustomersBusiness"/>.
    /// </summary>
    public interface ICustomersBusiness
    {
        /// <summary>
        /// The Creates entity for CustomersViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="CustomersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{CustomersViewModel}"/>.</returns>
        SimpleResponse<CustomersViewModel> Create(CustomersViewModel model);

        /// <summary>
        /// The Reads for CustomersViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{CustomersViewModel}"/>.</returns>
        SimpleResponse<CustomersViewModel> Read(int customerNumber);

        /// <summary>
        /// Updates entity for CustomersViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="CustomersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(CustomersViewModel model);

        /// <summary>
        /// Deletes entity for CustomersViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="CustomersViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(CustomersViewModel model);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int customerNumber);

        /// <summary>
        /// Reads All records for CustomersViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{CustomersViewModel}}"/>.</returns>
        SimpleResponse<List<CustomersViewModel>> ReadAll();
    }
}