using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BusinessLogic
{
    public class Business
    {
        private Data REPOSITORY;
        public Business(String connectionString)
        {
            REPOSITORY = new Data(connectionString);
        }

        public void processExamplePersons()
        {
            List<Person> PERSON = REPOSITORY.getExamplePersons();
            
            var result = from person in PERSON
                         where person.FirstName == "Kim"
                         orderby person.MiddleName descending
                         select person;

            //var result = PERSON.Select(person => person.FirstName == "Adam");

            foreach (Person item in result)
            {
                Console.WriteLine(item.FirstName + " " + item.MiddleName + " " + item.LastName);
            }
        }

        public void processExamplePersons2()
        {
            List<Person> PERSON = REPOSITORY.getExamplePersons();

            var result = from person in PERSON
                         where person.FirstName == "Kim" || person.FirstName == "Adam"
                         orderby person.MiddleName descending
                         select person;

            foreach (Person item in result)
            {
                Console.WriteLine(item.FirstName + " " + item.MiddleName + " " + item.LastName);
            }
        }

        public void processExamplePersons3()
        {
            List<Person> PERSON = REPOSITORY.getExamplePersons();

            var result = from person in PERSON
                         where person.FirstName == "Kim" || person.FirstName == "Adam"
                         group person by person.FirstName into personGroup
                         select personGroup;

            foreach (var personGroup in result)
            {
                foreach (Person item in personGroup)
                {
                    Console.WriteLine("Group Start:");
                    Console.WriteLine(item.FirstName + " " + item.MiddleName + " " + item.LastName);
                }  
            }
        }

        public void processExamplePersons4()
        { 
            List<Person> PERSON = REPOSITORY.getExamplePersons();
            IEnumerable<Person> result = PERSON.Where(o => o.FirstName == "Kim").OrderByDescending(o => o.MiddleName);
            

            foreach (var item in result)
            {
                Console.WriteLine(item.FirstName + " " + item.MiddleName + " " + item.LastName);
            }

            IEnumerable<Person> result2 = PERSON.Where(o => o.FirstName == "Kim").OrderByDescending(o => o.MiddleName);
        }
    }
}
