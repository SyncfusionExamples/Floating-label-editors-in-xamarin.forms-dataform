using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Internals;

namespace DataForm_ContainerTypes
{
    /// <summary>
    /// Represents the view model of the list view in the contact forms.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ContactListViewModel : INotifyPropertyChanged
    {
        #region Fields  

        /// <summary>
        /// Represents the contact information.
        /// </summary>
        private ContactInfo contactInfo;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactListViewModel"/> class.
        /// </summary>
        public ContactListViewModel()
        {
            this.contactInfo = new ContactInfo();
        }

        #endregion

        /// <summary>
        /// Represents the method that will handle when a property is changed on a component.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        /// <summary>
        /// Gets or sets the contact information.
        /// </summary>
        public ContactInfo ContactInfo
        {
            get
            {
                return this.contactInfo;
            }

            set
            {
                this.contactInfo = value;
                this.OnPropertyChanged("ContactInfo");
            }
        }
        #endregion

        /// <summary>
        /// Occurs when property value is changed.
        /// </summary>
        /// <param name="propertyName">Represents the proeprty name.</param>
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
