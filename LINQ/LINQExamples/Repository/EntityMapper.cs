using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace Repository
{
    public class EntityMapper
    {
        public Person convertToPerson(SqlDataReader READER)
        {
            Person PERSON = new Person();
            
            PERSON.FirstName = READER["FirstName"].ToString();
            PERSON.MiddleName = READER["MiddleName"].ToString();
            PERSON.LastName = READER["LastName"].ToString();

            return PERSON;
        }
    }
}
