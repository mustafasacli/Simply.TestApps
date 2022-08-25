using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;

namespace Mst.Project.BusinessCore.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IPaymentsBusiness"/>.
    /// </summary>
    public interface IPaymentsBusiness
    {
        /// <summary>
        /// The Creates entity for PaymentsViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="PaymentsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{PaymentsViewModel}"/>.</returns>
        SimpleResponse<PaymentsViewModel> Create(PaymentsViewModel viewModel);

        /// <summary>
        /// The Reads for PaymentsViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{PaymentsViewModel}"/>.</returns>
        SimpleResponse<PaymentsViewModel> Read(int customerNumber, string checkNumber);

        /// <summary>
        /// Updates entity for PaymentsViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="PaymentsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(PaymentsViewModel viewModel);

        /// <summary>
        /// Deletes entity for PaymentsViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="PaymentsViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(PaymentsViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int customerNumber, string checkNumber);

        /// <summary>
        /// Reads All records for PaymentsViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{PaymentsViewModel}}"/>.</returns>
        SimpleResponse<List<PaymentsViewModel>> ReadAll();
    }
}