using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public class Data
    {
        private String connectionString;
        private String errorMessage;
        private SqlConnection CONNECTION;
        private SqlCommand COMMAND;
        private SqlDataReader READER;

        public Data(String connectionString)
        {
            this.connectionString = connectionString;
            CONNECTION = new SqlConnection(connectionString);
        }

        public List<Person> getExamplePersons()
        {
            List<Person> PERSON = null;

            try
            {
                CONNECTION.Open();

                String query = "SELECT TOP 100 [FirstName],[MiddleName],[LastName] FROM [Person].[Person]";
                COMMAND = new SqlCommand(query, CONNECTION);
                READER = COMMAND.ExecuteReader();

                if (READER.HasRows)
                {
                    PERSON = new List<Person>();
                    EntityMapper MAPPER = new EntityMapper();

                    while (READER.Read())
                        PERSON.Add(MAPPER.convertToPerson(READER));
                }

                CONNECTION.Close();
            }
            catch (Exception EX)
            {
                errorMessage = EX.Message;
                Console.WriteLine("Error: " + EX.Message);
            }

            return PERSON;
        }
    }
}
