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

        /// <summary>
        /// Represents the view model of the <see cref="ContactListViewModel" /> class.
        /// </summary>
        private ContactListViewModel viewModel;

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

            this.dataForm.LayoutManager = new DataFormLayoutManagerExt(this.dataForm);
            this.dataForm.RegisterEditor("SaveTo", "Segment");
            this.dataForm.BindingContextChanged += this.OnBindingContextChanged;
            this.viewModel = bindable.BindingContext as ContactListViewModel;
            this.dataForm.AutoGeneratingDataFormItem += this.OnAutoGeneratingDataFormItem;
            this.dataForm.Validating += this.OnValidating;
            this.dataForm.ContainerBackgroundColor = Color.Default;
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.dataForm = bindable.FindByName<SfDataForm>("dataForm");
            this.dataForm.AutoGeneratingDataFormItem -= this.OnAutoGeneratingDataFormItem;
            this.dataForm.BindingContextChanged -= this.OnBindingContextChanged;
            this.dataForm.Validating -= this.OnValidating;
        }

        /// <summary>
        /// Occurs when Binding context of the data form is changed. 
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments of binding context changed event.</param>
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            this.viewModel = this.dataForm.BindingContext as ContactListViewModel;
        }

        /// <summary>
        /// Validates the value in the data form fields.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments of OnValidating event.</param>
        private void OnValidating(object sender, ValidatingEventArgs e)
        {
            if (e.PropertyName.Equals("ContactNumber"))
            {
                if (e.Value != null && e.Value.ToString().Length > 10)
                {
                    e.ErrorMessage = "Phone number should not exceed 10 digits.";
                    e.IsValid = false;
                }
            }
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

                if (e.DataFormItem.Name.Equals("ContactNumber"))
                {
                    var dataFormMaskedItem = e.DataFormItem as DataFormMaskedEditTextItem;
                    dataFormMaskedItem.KeyBoard = Keyboard.Telephone;
                    dataFormMaskedItem.CutCopyMaskFormat = Syncfusion.XForms.MaskedEdit.MaskFormat.ExcludePromptAndLiterals;
                    dataFormMaskedItem.SkipLiterals = true;
                    dataFormMaskedItem.ValueMaskFormat = Syncfusion.XForms.MaskedEdit.MaskFormat.ExcludePromptAndLiterals;
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        LeadingView = new Label()
                        {
                            VerticalTextAlignment = Device.RuntimePlatform == Device.iOS ? TextAlignment.Center : TextAlignment.Start,
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "F",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" :
                                                                   Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        },
                        ReserveSpaceForAssistiveLabels = true
                    };
                }
                else if (e.DataFormItem.Name.Equals("Email"))
                {
                    (e.DataFormItem as DataFormTextItem).KeyBoard = Keyboard.Email;
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        LeadingView = new Label()
                        {
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "G",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" :
                                                                  Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("ContactName"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        LeadingView = new Label()
                        {
                            VerticalTextAlignment = Device.RuntimePlatform == Device.iOS ? TextAlignment.Center : TextAlignment.Start,
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "A",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" : Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("LastName"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        LeadingView = new Label()
                        {
                            VerticalTextAlignment = Device.RuntimePlatform == Device.iOS ? TextAlignment.Center : TextAlignment.Start,
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "A",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" :
                                                                   Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("BirthDate"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        ContainerType = ContainerType.Filled,
                        OutlineCornerRadius = 30,
                        LeadingView = new Label()
                        {
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "H",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" :
                                                                   Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("GroupName"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        ContainerType = ContainerType.Filled,
                        OutlineCornerRadius = 30,
                        LeadingView = new Label()
                        {
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "B",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" :
                                                                                      Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("Address"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        LeadingView = new Label()
                        {
                            VerticalTextAlignment = Device.RuntimePlatform == Device.iOS ? TextAlignment.Center : TextAlignment.Start,
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "I",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" :
                                                                  Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("Notes"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        ContainerType = ContainerType.Filled,
                        OutlineCornerRadius = 30,
                        LeadingView = new Label()
                        {
                            VerticalTextAlignment = Device.RuntimePlatform == Device.iOS ? TextAlignment.Center : TextAlignment.Start,
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "C",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" :
                                                                                      Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("SaveTo"))
                {
                    e.DataFormItem.LayoutOptions = LayoutType.Default;
                }
            }

            if (e.DataFormGroupItem != null)
            {
                e.DataFormGroupItem.AllowExpandCollapse = false;
            }
        }
    }

    /// <summary>
    /// Represents a class that used to customize the DataForm.
    /// </summary>
    public class DataFormLayoutManagerExt : DataFormLayoutManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFormLayoutManagerExt"/> class.
        /// </summary>
        /// <param name="dataform">DataForm control helps editing the data fields of any data object.</param>
        public DataFormLayoutManagerExt(Syncfusion.XForms.DataForm.SfDataForm dataform) : base(dataform)
        {
        }

        /// <summary>
        /// Gets left start offset for editor.
        /// </summary>
        /// <param name="dataFormItem">DataFormItem of the editor.</param>
        /// <returns>Returns left padding for editor.</returns>
        protected override int GetLeftPaddingForEditor(DataFormItem dataFormItem)
        {
            return 0;
        }

        /// <summary>
        /// Gets left start offset for label.
        /// </summary>
        /// <param name="dataFormItem">DataFormItem of the editor.</param>
        /// <returns>Returns left padding value for label.</returns>
        protected override int GetLeftPaddingForLabel(DataFormItem dataFormItem)
        {
            if (dataFormItem.Name.Equals("SaveTo"))
            {
                return 60;
            }

            return base.GetLeftPaddingForLabel(dataFormItem);
        }
    }
}
