using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;

namespace Mst.Project.BusinessCore.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IProductsBusiness"/>.
    /// </summary>
    public interface IProductsBusiness
    {
        /// <summary>
        /// The Creates entity for ProductsViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ProductsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{ProductsViewModel}"/>.</returns>
        SimpleResponse<ProductsViewModel> Create(ProductsViewModel viewModel);

        /// <summary>
        /// The Reads for ProductsViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{ProductsViewModel}"/>.</returns>
        SimpleResponse<ProductsViewModel> Read(string productCode);

        /// <summary>
        /// Updates entity for ProductsViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ProductsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(ProductsViewModel viewModel);

        /// <summary>
        /// Deletes entity for ProductsViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ProductsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(ProductsViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(string productCode);

        /// <summary>
        /// Reads All records for ProductsViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{ProductsViewModel}}"/>.</returns>
        SimpleResponse<List<ProductsViewModel>> ReadAll();
    }
}