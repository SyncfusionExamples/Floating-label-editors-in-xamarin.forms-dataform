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
        private ContactsInfo contactform;
        public ContactsInfo ContactForm
        {
            get { return this.contactform; }
            set { this.contactform = value; }
        }
        public ViewModel()
        {
            this.contactform = new ContactsInfo();
        }
    }
}
