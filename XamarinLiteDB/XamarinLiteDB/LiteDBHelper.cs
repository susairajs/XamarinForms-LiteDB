using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace XamarinLiteDB
{
    public class LiteDBHelper
    {
        protected LiteCollection<Person> personCollection;

        public LiteDBHelper(string dbPath)
        {
            using (var db = new LiteDatabase(dbPath))
            {
                personCollection = db.GetCollection<Person>("Persons");
            }
                
        }

        //Get All Persons
        public List<Person> GetAllPersons()
        {
            var persons= new List<Person>(personCollection.FindAll());
            return persons;
        }

        //Add New Person
        public void AddPerson(Person person)
        {
            personCollection.Insert(person);
        }

        //Update Person
        public void UpdatePerson(Person person)
        {
            personCollection.Update(person);
        }

        //Get Person
        public Person GetPerson(int personId)
        {
            var person = GetAllPersons().Where(a => a.PersonId == personId).FirstOrDefault();
            return person;
        }
        //Delete Person
        public void DeletePerson(int personId)
        {
            personCollection.Delete(a => a.PersonId == personId);
        }

    }
}
