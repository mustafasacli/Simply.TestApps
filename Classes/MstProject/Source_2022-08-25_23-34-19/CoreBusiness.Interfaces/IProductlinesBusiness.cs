using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;

namespace Mst.Project.BusinessCore.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IProductlinesBusiness"/>.
    /// </summary>
    public interface IProductlinesBusiness
    {
        /// <summary>
        /// The Creates entity for ProductlinesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ProductlinesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{ProductlinesViewModel}"/>.</returns>
        SimpleResponse<ProductlinesViewModel> Create(ProductlinesViewModel viewModel);

        /// <summary>
        /// The Reads for ProductlinesViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{ProductlinesViewModel}"/>.</returns>
        SimpleResponse<ProductlinesViewModel> Read(string productLine);

        /// <summary>
        /// Updates entity for ProductlinesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ProductlinesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(ProductlinesViewModel viewModel);

        /// <summary>
        /// Deletes entity for ProductlinesViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ProductlinesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(ProductlinesViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(string productLine);

        /// <summary>
        /// Reads All records for ProductlinesViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{ProductlinesViewModel}}"/>.</returns>
        SimpleResponse<List<ProductlinesViewModel>> ReadAll();
    }
}