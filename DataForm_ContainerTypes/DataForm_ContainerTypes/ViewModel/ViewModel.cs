using System;
using System.Collections.Generic;
using System.Text;

namespace DataForm_ContainerTypes
{
    /// <summary>
    /// Represents the employee form information of the data form in this sample.
    /// </summary>
    public class ViewModel
    {
        private EmployeeForm employeeForm;
        public EmployeeForm EmployeeForm
        {
            get { return this.employeeForm; }
            set { this.employeeForm = value; }
        }
        public ViewModel()
        {
            this.employeeForm = new EmployeeForm();
        }
    }
}
