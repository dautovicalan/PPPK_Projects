using CosmosDbOsoba.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDbOsoba.Dao
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Person>> GetPeopleAsync(string queryString);
        Task<Person> GetPersonAsync(string id);
        Task AddPersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(Person person);
    }
}