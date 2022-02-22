using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows
            => File.ReadAllLines("./People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {

           return CsvRows.ToList().Select(item => item.Split(',')[6]).Distinct().OrderBy(item=>item);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> rows = GetUniqueSortedListOfStatesGivenCsvRows();
            rows.ToArray();
            return String.Join(',', rows);
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                return CsvRows.Select(item => item.Split(',')).Select(rows =>
                    new Person(
                        rows[1],
                        rows[2],
                        new Address(rows[4], rows[5], rows[6], rows[7]),
                        rows[3]));
            }
        }
        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            return People
                .Where(person => filter(person.EmailAddress))
                .Select(person => (person.FirstName, person.LastName));
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            List<string>? states = People.Select(person => person.Address.State).Distinct().ToList();
            return String.Join(",", states);
        }

    }
}
