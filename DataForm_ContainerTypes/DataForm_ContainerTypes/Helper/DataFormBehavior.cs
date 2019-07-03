using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DataForm_ContainerTypes
{
    /// <summary>
    /// User defined behaviour to respond arbitrary conditions and events of DataForm.
    /// </summary>
    public class DataFormBehavior : Behavior<ContentPage>
    {
        /// <summary>
        /// DataForm control to edit the data fields of any data object
        /// </summary>
        SfDataForm dataForm;

        public DataFormBehavior()
        {
        }

        /// <summary>
        /// Attaches to the superclass and then calls the OnAttachedTo method on this object.
        /// </summary>
        /// <param name="bindable">The bindable object to which the behavior was attached.</param>
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.dataForm = bindable.FindByName<SfDataForm>("dataForm");
            this.dataForm.AutoGeneratingDataFormItem += this.OnAutoGeneratingDataFormItem;
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.dataForm = bindable.FindByName<SfDataForm>("dataForm");
            this.dataForm.AutoGeneratingDataFormItem -= this.OnAutoGeneratingDataFormItem;
        }

        /// <summary>
        /// Raised to set read only property and cancel the some properties.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Contains arguments of auto generating data form event</param>
        private void OnAutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null)
            {
                if (e.DataFormItem.Name.Equals("PhoneNumber"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new Syncfusion.SfDataForm.XForms.TextInputLayoutSettings()
                    {
                        OutlineCornerRadius = 30,
                        ReserveSpaceForAssistiveLabels = true
                    };
                }
                else if (e.DataFormItem.Name.Equals("Password"))
                {
                    e.DataFormItem.ShowCharCount = true;
                    (e.DataFormItem as DataFormTextItem).EnablePasswordVisibilityToggle = true;
                
                }
                else if (e.DataFormItem.Name.Equals("Address"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new Syncfusion.SfDataForm.XForms.TextInputLayoutSettings()
                    {
                        ContainerType = ContainerType.None
                    };
                }
            }
                    
        }
    }
}
