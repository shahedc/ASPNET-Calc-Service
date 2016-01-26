using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDbIntegration.Controllers;
using WebDbIntegration.Data;
using Xunit;

namespace WebDbIntegration.Tests.Controllers
{
    public class ValuesControllerTest
    {
        private MyDbContext _context;
        private ValuesController _controller;

        public ValuesControllerTest()
        {
            // Initialize DbContext in memory
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase();
            _context = new MyDbContext(optionsBuilder.Options);

            // Seed data
            _context.People.Add(new Person()
            {
                FirstName = "John",
                LastName = "Doe"
            });
            _context.People.Add(new Person()
            {
                FirstName = "Sally",
                LastName = "Doe"
            });
            _context.SaveChanges();

            // Create test subject
            _controller = new ValuesController(_context);
        }

        [Fact]
        public void Get_person_john_returns_john()
        {
            // Act
            var person = _controller.Get("John");

            // Assert
            Assert.IsType(typeof(Person), person);
            Assert.Equal("John", person.FirstName);
            Assert.Equal("Doe", person.LastName);
        }

        [Fact]
        public void Get_non_existent_person_returns_null()
        {
            // Act
            var result = _controller.Get("Fred");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Add_person_saves_to_db_with_generated_id()
        {
            // Arrange
            Guid personId = Guid.NewGuid();
            Person person = new Person()
            {
                Id = personId,
                FirstName = "Billy",
                LastName = "McBill"
            };
            var beforePersonCount = _context.People.Count();

            // Act
            _controller.Post(person);

            // Assert
            Person savedPerson = _context.People.Single(x => x.FirstName == "Billy"
                                                             && x.LastName == "McBill");
            Assert.NotEqual(personId, savedPerson.Id);
            Assert.Equal(beforePersonCount + 1, _context.People.Count());
        }
    }
}
