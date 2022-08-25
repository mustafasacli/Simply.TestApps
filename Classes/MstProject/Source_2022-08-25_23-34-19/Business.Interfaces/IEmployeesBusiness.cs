using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;

namespace Mst.Project.Business.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IEmployeesBusiness"/>.
    /// </summary>
    public interface IEmployeesBusiness
    {
        /// <summary>
        /// The Creates entity for EmployeesViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="EmployeesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{EmployeesViewModel}"/>.</returns>
        SimpleResponse<EmployeesViewModel> Create(EmployeesViewModel model);

        /// <summary>
        /// The Reads for EmployeesViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{EmployeesViewModel}"/>.</returns>
        SimpleResponse<EmployeesViewModel> Read(int employeeNumber);

        /// <summary>
        /// Updates entity for EmployeesViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="EmployeesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(EmployeesViewModel model);

        /// <summary>
        /// Deletes entity for EmployeesViewModel.
        /// </summary>
        /// <param name="model">The model <see cref="EmployeesViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(EmployeesViewModel model);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int employeeNumber);

        /// <summary>
        /// Reads All records for EmployeesViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{EmployeesViewModel}}"/>.</returns>
        SimpleResponse<List<EmployeesViewModel>> ReadAll();
    }
}