using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataForm_ContainerTypes
{
    public class ContactsInfo : INotifyPropertyChanged
    {
        #region Fields       
        /// <summary>
        /// Represents the name of the person information.
        /// </summary>
        private string name = "John";

        /// <summary>
        /// Represents the last name of the person information.
        /// </summary>
        private string lastname;

        /// <summary>
        /// Represents the phone number of the person information.
        /// </summary>
        private string phonenumber;

        /// <summary>
        /// Represents the country of the person information.
        /// </summary>
        private string country;

        /// <summary>
        /// Represents the address of the person information.
        /// </summary>
        private string address;

        /// <summary>
        /// Represents the city of the person information.
        /// </summary>
        private string city;

        /// <summary>
        /// Represents the first zip of the person information.
        /// </summary>
        private string zip1;

        /// <summary>
        /// Represents the team of the person information.
        /// </summary>
        private string team;

        /// <summary>
        /// Represents the track hours of the person information.
        /// </summary>
        private bool trackhours;

        /// <summary>
        /// Represents the type here of the person information.
        /// </summary>
        private string typehere;
        #endregion

        public ContactsInfo()
        {

        }

        /// <summary>
        /// Represents the method that will handle when a property is changed on a component.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Public Properties  
        /// <summary>
        /// Gets or sets the name field.
        /// </summary>
        [Display(ShortName = "User name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name should not be empty")]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the last name field.
        /// </summary>
        [Display(ShortName = "Last Name", Prompt = "Enter your last name")]
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
        /// Gets or sets the phone number field.
        /// </summary>
        [Display(ShortName = "Phone number", Prompt = "Enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber
        {
            get
            {
                return this.phonenumber;
            }
            set
            {
                this.phonenumber = value;
                this.RaisePropertyChanged("PhoneNumber");
            }
        }

        /// <summary>
        /// Gets or sets the country field.
        /// </summary>
        [Display(ShortName = "Country", Prompt = "Enter your country")]
        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
                this.RaisePropertyChanged("Country");
            }
        }

        /// <summary>
        /// Gets or sets the address field.
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Prompt = "Enter your address")]

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
        /// Gets or sets the city field.
        /// </summary>
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
                this.RaisePropertyChanged("City");
            }
        }
        #endregion
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


    }

}
