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
        public int DeletePersonsByName(string name)
        {
            // Aquí puedes realizar validaciones u operaciones adicionales si es necesario
            return personMng.DeletePersonsByName(name);
        }

        public void UpdateUser(Person person)
        {
            // Aquí puedes realizar validaciones u operaciones adicionales antes de actualizar el usuario.
            personMng.UpdateUser(person);
        }

        public Person GetUserById(int id)
        {
            return personMng.GetUserById(id);
        }

        public int ChangePassword(int id, string newPassword)
        {
            return personMng.ChangePassword(id, newPassword);
        }

        public List<Person> GetPersonsByName(string name)
        {
            // Aquí puedes realizar validaciones u operaciones adicionales si es necesario
            return personMng.GetPersonsByName(name);
        }
    }
}