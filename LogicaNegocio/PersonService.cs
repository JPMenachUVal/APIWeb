using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace LogicaNegocio
{
    public class PersonService
    {
        private readonly PersonMng personMng;

        public PersonService(string connectionString)
        {
            personMng = new PersonMng(connectionString);
        }

        public List<Person> GetPersons()
        {
            return personMng.GetPersons();
        }

        public void AddUser(Person person)
        {
            // Aquí puedes realizar validaciones u operaciones adicionales antes de agregar el usuario.
            personMng.AddUser(person);
        }
    }
}