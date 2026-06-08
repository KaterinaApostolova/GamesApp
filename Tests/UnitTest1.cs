using GamesApp.Controllers;
using GamesApp.Data;
using GamesApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class Tests
    {
        private MyContext context;
        private UserController controller;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MyContext>().UseInMemoryDatabase(databaseName: "ReservationTestDb").Options;
            context = new MyContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var user = new User
            {
                Id = 1,
                FullName = "Iva",
                Age = 19,
                Username = "Ivvvv",
                Password = "12345678",
                Email = "iva@abv.bg"
            };
            context.Users.Add(user);
            context.SaveChanges();
            controller = new UserController(context);
        }
        [TearDown]
        public void TearDown()
        { context.Dispose(); }
        [Test]
        public void GetAll_ReturnsUsers()
        {
            var result = controller.GetAll();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Iva", result[0].FullName);
        }
        [Test]
        public void Get_ValidId_ReturnsUser()
        {
            var res = controller.GetById(1);
            Assert.IsNotNull(res);
            Assert.AreEqual(19, res.Age);
        }

        [Test]
        public void Get_InvalidId_ReturnsNull()
        {
            var res = controller.GetById(199);
            Assert.IsNull(res);
        }
        [Test]
        public void AddUser_AdddsSuccessfully()
        {
            User userAdded = new User { Id = 2, FullName = "Anna", Age = 34, Username = "Annnnn", Email = "anna@gmail.com", Password = "12345678" };
            controller.Add(userAdded);
            var added = context.Users.FirstOrDefault(u => u.FullName == "Anna");
            Assert.AreEqual(34, added.Age);
        }
        [Test]
        public void UpdateUser_ExistingUser_UpdateSuccessfully()
        {
            var originalUser = new User { Id = 3, FullName = "Anna", Age = 34, Username = "Annnnn", Email = "anna@gmail.com", Password = "12345678" };
            context.Users.Add(originalUser);
            context.SaveChanges();
            var updatedUser = new User { Id = 3, FullName = "Anna-Maria", Age = 56, Username = "Annnnn", Email = "anna-maria@gmail.com", Password = "12345678" };
            controller.Update(updatedUser);
            var updated = context.Users.FirstOrDefault(u => u.Id == 3);
            Assert.IsNotNull(updated);
            Assert.AreEqual("Anna-Maria", updated.FullName);
            Assert.AreEqual(56, updated.Age);
            Assert.AreEqual("anna-maria@gmail.com", updated.Email);
        }
        [Test]
        public void Delete_ExistingReservation_RemovesSuccessfully()
        {
            controller.Delete(1);
            var delleted = context.Users.Find(1);
            Assert.IsNull(delleted);
        }
}
}