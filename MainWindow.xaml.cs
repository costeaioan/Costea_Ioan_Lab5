using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Costea_Ioan_Lab5
{
    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ActionState action = ActionState.Nothing;
        PhoneNumbersDataSet phoneNumbersDataSet = new PhoneNumbersDataSet();
        PhoneNumbersDataSetTableAdapters.PhoneNumbersTableAdapter tblPhoneNumbersAdapter = new PhoneNumbersDataSetTableAdapters.PhoneNumbersTableAdapter();
        Binding txtPhoneNumberBinding = new Binding();
        Binding txtSubscriberBinding = new Binding();
        Binding txtContractValueBinding = new Binding();
        Binding txtContractDateBinding = new Binding();

        public MainWindow()
        {
            InitializeComponent();
            grdMain.DataContext = phoneNumbersDataSet.PhoneNumbers;
            txtPhoneNumberBinding.Path = new PropertyPath("Phonenum");
            txtSubscriberBinding.Path = new PropertyPath("Subscriber");
            txtContractDateBinding.Path = new PropertyPath("Contract_date");
            txtContractValueBinding.Path = new PropertyPath("Contract_value");
            txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
            txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
            txtContractDate.SetBinding(TextBox.TextProperty, txtContractDateBinding);
            txtContractValue.SetBinding(TextBox.TextProperty, txtContractValueBinding);

        }

        private void lstPhonesLoad()
        {
            tblPhoneNumbersAdapter.Fill(phoneNumbersDataSet.PhoneNumbers);
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void grdMain_Loaded(object sender, RoutedEventArgs e)
        {
            lstPhonesLoad();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Close Application?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            PhoneNumbersDataSet phoneNumbersDataSet =
((PhoneNumbersDataSet)(this.FindResource("phoneNumbersDataSet")));
            System.Windows.Data.CollectionViewSource phoneNumbersViewSource =
            ((System.Windows.Data.CollectionViewSource)(this.FindResource("phoneNumbersViewSource")));
            phoneNumbersViewSource.View.MoveCurrentToFirst();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
            btnNew.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            lstPhones.IsEnabled = false;
            btnPrevious.IsEnabled = false;
            btnNext.IsEnabled = true;
            txtPhoneNumber.IsEnabled = true;
            txtContractDate.IsEnabled = true;
            txtContractValue.IsEnabled = true;
            txtSubscriber.IsEnabled = true;

            BindingOperations.ClearBinding(txtPhoneNumber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtSubscriber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContractDate, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContractValue, TextBox.TextProperty);
            txtContractValue.Text = "";
            txtContractDate.Text = "";
            txtPhoneNumber.Text = "";
            txtSubscriber.Text = "";
            Keyboard.Focus(txtPhoneNumber);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
            string tempPhonenum = txtPhoneNumber.Text.ToString();
            string tempSubscriber = txtSubscriber.Text.ToString();
            string stringDate = txtContractDate.Text.ToString();
            string stringValue = txtContractValue.Text.ToString();
            DateTime tempDate = new DateTime(1970, 1, 1);
            int tempInt;
            try
            {
                tempDate = DateTime.Parse(stringDate);
                tempInt = int.Parse(stringValue);
            }
            catch (Exception myException)
            {
                MessageBox.Show(myException.Message);
                txtContractDate.Clear();
            }


            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            lstPhones.IsEnabled = false;
            btnPrevious.IsEnabled = false;
            btnNext.IsEnabled = false;
            txtPhoneNumber.IsEnabled = true;
            txtContractDate.IsEnabled = true;
            txtContractValue.IsEnabled = true;
            txtSubscriber.IsEnabled = true;

            BindingOperations.ClearBinding(txtPhoneNumber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtPhoneNumber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContractDate, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContractValue, TextBox.TextProperty);
            txtPhoneNumber.Text = tempPhonenum;
            txtContractDate.Text = tempDate.ToShortDateString();
            txtContractValue.Text = stringValue;
            txtSubscriber.Text = tempSubscriber;
            Keyboard.Focus(txtPhoneNumber);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
            string tempPhonenum = txtPhoneNumber.Text.ToString();
            string tempSubscriber = txtSubscriber.Text.ToString();
            int tempValue = int.Parse(txtContractValue.Text.ToString());
            btnNew.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            lstPhones.IsEnabled = false;
            btnPrevious.IsEnabled = false;
            btnNext.IsEnabled = false;
            BindingOperations.ClearBinding(txtPhoneNumber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtSubscriber, TextBox.TextProperty);
            txtPhoneNumber.Text = tempPhonenum;
            txtSubscriber.Text = tempSubscriber;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)

        {

            action = ActionState.Nothing;
            btnNew.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            lstPhones.IsEnabled = true;
            btnPrevious.IsEnabled = true;
            btnNext.IsEnabled = true;
            txtPhoneNumber.IsEnabled = false;
            txtSubscriber.IsEnabled = false;
            txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
            txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
            txtContractDate.SetBinding(TextBox.TextProperty, txtContractDateBinding);
            txtContractValue.SetBinding(TextBox.TextProperty, txtContractValueBinding);

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (action == ActionState.New)
            {
                try
                {
                    DataRow newRow = phoneNumbersDataSet.PhoneNumbers.NewRow();
                    newRow.BeginEdit();
                    newRow["PhoneNum"] = txtPhoneNumber.Text.Trim();
                    newRow["Subscriber"] = txtSubscriber.Text.Trim();
                    newRow["Contract_value"] = int.Parse(txtContractValue.Text.Trim());
                    newRow["Contract_date"] = DateTime.Parse(txtContractDate.Text.Trim());
                    newRow.EndEdit();
                    phoneNumbersDataSet.PhoneNumbers.Rows.Add(newRow);
                    tblPhoneNumbersAdapter.Update(phoneNumbersDataSet.PhoneNumbers);
                    phoneNumbersDataSet.AcceptChanges();
                }

                catch (DataException ex)
                {

                    phoneNumbersDataSet.RejectChanges();
                    MessageBox.Show(ex.Message);
                    safety_Cancel();
                }

                catch (FormatException dateEx)
                {
                    phoneNumbersDataSet.RejectChanges();
                    MessageBox.Show(dateEx.Message);
                    safety_Cancel();
                }

                catch (System.ArgumentException ex)
                {
                    phoneNumbersDataSet.RejectChanges();
                    MessageBox.Show(ex.Message);
                    safety_Cancel();
                }

                btnNew.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = false;
                lstPhones.IsEnabled = true;
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = true;
                txtPhoneNumber.IsEnabled = false;
                txtSubscriber.IsEnabled = false;
                txtContractDate.IsEnabled = false;
                txtContractValue.IsEnabled = false;
            }

            else
                if (action == ActionState.Edit)
            {
                try
                {
                    DataRow editRow = phoneNumbersDataSet.PhoneNumbers.Rows[lstPhones.SelectedIndex];
                    editRow.BeginEdit();
                    editRow["Phonenum"] = txtPhoneNumber.Text.Trim();
                    editRow["Subscriber"] = txtSubscriber.Text.Trim();
                    editRow["Contract_value"] = int.Parse(txtContractValue.Text.Trim());
                    editRow["Contract_date"] = DateTime.Parse(txtContractDate.Text.Trim());
                    editRow.EndEdit();
                    tblPhoneNumbersAdapter.Update(phoneNumbersDataSet.PhoneNumbers);
                    phoneNumbersDataSet.AcceptChanges();
                }

                catch (DataException ex)
                {

                    phoneNumbersDataSet.RejectChanges();
                    MessageBox.Show(ex.Message);
                }

                catch (FormatException dateEx)
                {
                    phoneNumbersDataSet.RejectChanges();
                    MessageBox.Show(dateEx.Message);
                }

                catch (System.ArgumentException ex)
                {
                    phoneNumbersDataSet.RejectChanges();
                    MessageBox.Show(ex.Message);
                }

                btnNew.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = false;
                lstPhones.IsEnabled = true;
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = true;
                txtPhoneNumber.IsEnabled = false;
                txtSubscriber.IsEnabled = false;
                txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
                txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
                txtContractDate.SetBinding(TextBox.TextProperty, txtContractDateBinding);
                txtContractValue.SetBinding(TextBox.TextProperty, txtContractValueBinding);
            }

            else
                if (action == ActionState.Delete)
            {
                try
                {
                    DataRow deleteRow = phoneNumbersDataSet.PhoneNumbers.Rows[lstPhones.SelectedIndex];

                    deleteRow.Delete();

                    tblPhoneNumbersAdapter.Update(phoneNumbersDataSet.PhoneNumbers);
                    phoneNumbersDataSet.AcceptChanges();
                }

                catch (DataException ex)
                {
                    phoneNumbersDataSet.RejectChanges();
                    MessageBox.Show(ex.Message);
                }

                btnNew.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = false;
                lstPhones.IsEnabled = true;
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = true;
                txtPhoneNumber.IsEnabled = false;
                txtSubscriber.IsEnabled = false;
                txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
                txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
                txtContractDate.SetBinding(TextBox.TextProperty, txtContractDateBinding);
                txtContractValue.SetBinding(TextBox.TextProperty, txtContractValueBinding);
            }
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            //using System.ComponentMode1
            ICollectionView navigationView = CollectionViewSource.GetDefaultView(phoneNumbersDataSet.PhoneNumbers);
            navigationView.MoveCurrentToPrevious();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView navigationView = CollectionViewSource.GetDefaultView(phoneNumbersDataSet.PhoneNumbers);
            navigationView.MoveCurrentToNext();
        }

        private void lstPhones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void safety_Cancel()
        {

            action = ActionState.Nothing;
            btnNew.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            lstPhones.IsEnabled = true;
            btnPrevious.IsEnabled = true;
            btnNext.IsEnabled = true;
            txtPhoneNumber.IsEnabled = false;
            txtSubscriber.IsEnabled = false;
            txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
            txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
            txtContractDate.SetBinding(TextBox.TextProperty, txtContractDateBinding);
            txtContractValue.SetBinding(TextBox.TextProperty, txtContractValueBinding);



        }
    }
}
