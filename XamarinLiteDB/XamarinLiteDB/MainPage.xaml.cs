using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinLiteDB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Get All Persons
            var personList=App.LiteDB.GetAllPersons();
            if(personList.Count!=0)
            {
                lstPersons.ItemsSource = personList;
            }
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                Person person = new Person()
                {
                    Name = txtName.Text
                };
                //Add New Person
                App.LiteDB.AddPerson(person);
                txtName.Text = string.Empty;
                DisplayAlert("Success", "Person Added", "OK");

                //Get All Persons
                var personList = App.LiteDB.GetAllPersons();
                if (personList.Count != 0)
                {
                    lstPersons.ItemsSource = personList;
                }
            }
        }

        private void BtnRead_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtPersonId.Text))
            {
               var person= App.LiteDB.GetPerson(Convert.ToInt32(txtPersonId.Text));
                if(person!=null)
                {
                    txtName.Text = person.Name;
                    DisplayAlert("Success", "Person Name: "+person.Name, "OK");
                }
                else
                {
                    DisplayAlert("Faild", "Person is not available", "OK");
                }
            }
        }

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonId.Text))
            {
                Person person = new Person()
                {
                    PersonId = Convert.ToInt32(txtPersonId.Text),
                    Name = txtName.Text
                };

                //Update person
                App.LiteDB.UpdatePerson(person);
                txtName.Text = string.Empty;
                txtPersonId.Text = string.Empty;
                DisplayAlert("Success", "Person Updated", "OK");

                //Get All Persons
                var personList = App.LiteDB.GetAllPersons();
                if (personList.Count != 0)
                {
                    lstPersons.ItemsSource = personList;
                }
            }
        }

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtPersonId.Text))
            {
                //Delete Person
                App.LiteDB.DeletePerson(Convert.ToInt32(txtPersonId.Text));
                txtPersonId.Text = string.Empty;
                DisplayAlert("Warning", "Person Deleted!", "OK");

                //Get All Persons
                var personList = App.LiteDB.GetAllPersons();
                if (personList.Count != 0)
                {
                    lstPersons.ItemsSource = personList;
                }
            }

        }

        
    }
}
