using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataForm_ContainerTypes
{
    public class ContactInfo : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Represents the contact name of the contact information.
        /// </summary>
        private string contactName;

        /// <summary>
        /// Represents the middle name of the contact information.
        /// </summary>
        private string middelName;

        /// <summary>
        /// Represents the last name of the contact information.
        /// </summary>
        private string lastname;

        /// <summary>
        /// Represents the contact number of the contact information.
        /// </summary>
        private string contactNo;

        /// <summary>
        /// Represents the email field of the contact information.
        /// </summary>
        private string email;

        /// <summary>
        /// Represents the adress of the contact information.
        /// </summary>
        private string address;

        /// <summary>
        /// Represents the notes of the contact information.
        /// </summary>
        private string notes;

        /// <summary>
        /// Represents the birth date of the contact information.
        /// </summary>
        private DateTime birthDate;

        /// <summary>
        /// Represents the group name of the contact information.
        /// </summary>
        private string groupName;

        /// <summary>
        /// Represents the save field of the contact information.
        /// </summary>
        private Save saveTo;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInfo"/> class.
        /// </summary>
        public ContactInfo()
        {
        }

        /// <summary>
        /// Represents a method that will handle when a property is changed on a component.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Describes the possible types to save.
        /// </summary>
        public enum Save
        {
            /// <summary>
            /// Represents sim.
            /// </summary>
            Sim,

            /// <summary>
            /// Represents phone.
            /// </summary>
            Phone
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the contact field in the contacts information.
        /// </summary>
        [DisplayOptions(ColumnSpan = 2)]
        [Display(ShortName = "Contact name")]
        public string ContactName
        {
            get
            {
                return this.contactName;
            }

            set
            {
                this.contactName = value;
                this.RaisePropertyChanged("ContactName");
            }
        }

        /// <summary>
        /// Gets or sets the last name in the contacts information.
        /// </summary>
        [DisplayOptions(ColumnSpan = 2)]
        [Display(ShortName = "Last name")]
        public string LastName
        {
            get
            {
                return this.lastname;
            }

            set
            {
                this.lastname = value;
                this.RaisePropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Gets or sets the contact number field in the contacts information.
        /// </summary>
        [Display(ShortName = "Contact number")]
        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "Phone number should not exceed 10 digits.")]
        public string ContactNumber
        {
            get
            {
                return this.contactNo;
            }

            set
            {
                this.contactNo = value;
                this.RaisePropertyChanged("ContactNumber");
            }
        }

        /// <summary>
        /// Gets or sets the email field in the contacts information.
        /// </summary>
        [DisplayOptions(ColumnSpan = 2)]
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
                this.RaisePropertyChanged("Email");
            }
        }

        /// <summary>
        /// Gets or sets the birth date field in the contacts information.
        /// </summary>
        [Display(ShortName = "Birth date")]
        [DisplayOptions(ColumnSpan = 4)]
        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }

            set
            {
                this.birthDate = value;
                this.RaisePropertyChanged("BirthDate");
            }
        }

        /// <summary>
        /// Gets or sets the address field in the contacts information.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4)]
        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
                this.RaisePropertyChanged("Address");
            }
        }

        /// <summary>
        /// Gets or sets the notes field in the contacts information.
        /// </summary>
        [DataType(DataType.MultilineText)]
        [DisplayOptions(ColumnSpan = 4)]
        public string Notes
        {
            get
            {
                return this.notes;
            }

            set
            {
                this.notes = value;
                this.RaisePropertyChanged("Notes");
            }
        }

        /// <summary>
        /// Gets or sets the group name field in the contacts information.
        /// </summary>
        [Display(ShortName = "Group name")]
        [DisplayOptions(ColumnSpan = 4)]
        public string GroupName
        {
            get
            {
                return this.groupName;
            }

            set
            {
                this.groupName = value;
                this.RaisePropertyChanged("GroupName");
            }
        }

        /// <summary>
        /// Gets or sets the save field in the contacts information.
        /// </summary>
        [Display(ShortName = "Save To")]
        [DisplayOptions(ColumnSpan = 5)]
        public Save SaveTo
        {
            get
            {
                return this.saveTo;
            }

            set
            {
                this.saveTo = value;
                this.RaisePropertyChanged("SaveTo");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Occurs when propery value is changed.
        /// </summary>
        /// <param name="name">Property name</param>
        private void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}

