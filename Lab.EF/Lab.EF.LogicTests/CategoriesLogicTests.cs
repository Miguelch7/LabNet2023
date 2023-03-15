using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Lab.EF.Entities;
using Moq;
using System.Data.Entity;
using Lab.EF.Data;
using System.Runtime.Remoting.Contexts;

namespace Lab.EF.Logic.Tests
{
    [TestClass()]
    public class CategoriesLogicTests
    {
        [TestMethod()]
        public void AddNewCategoryTest()
        {
            Categories category = new Categories()
            {
                CategoryName = "Test",
                Description = "Description",
            };

            Mock<DbSet<Categories>> mockSet = new Mock<DbSet<Categories>>();

            Mock<NorthwindContext> mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            CategoriesLogic service = new CategoriesLogic(mockContext.Object);
            service.Add(category);

            mockSet.Verify(m => m.Add(It.IsAny<Categories>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void GetAllCategoriesTest()
        {
            int cantidadCategoriasEsperadas = 3;
            int cantidadCategoriasObtenidas;

            IQueryable<Categories> data = new List<Categories>
            {
                new Categories { CategoryName = "Category1" },
                new Categories { CategoryName = "Category2" },
                new Categories { CategoryName = "Category3" }
            }.AsQueryable();

            Mock<DbSet<Categories>> mockSet = new Mock<DbSet<Categories>>();
            mockSet.As<IQueryable<Categories>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            Mock<NorthwindContext> mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            CategoriesLogic service = new CategoriesLogic(mockContext.Object);
            List<Categories> listaCategoriasObtenidas = service.GetAll();

            cantidadCategoriasObtenidas = listaCategoriasObtenidas.Count;
            
            Assert.AreEqual(cantidadCategoriasEsperadas, cantidadCategoriasObtenidas);
            Assert.AreEqual("Category1", listaCategoriasObtenidas[0].CategoryName);
            Assert.AreEqual("Category2", listaCategoriasObtenidas[1].CategoryName);
            Assert.AreEqual("Category3", listaCategoriasObtenidas[2].CategoryName);
        }

        [TestMethod()]
        public void DeleteCategoryTest()
        {
            int idAEliminar = 1;

            IQueryable<Categories> data = new List<Categories>
            {
                new Categories { CategoryName = "Category1" },
                new Categories { CategoryName = "Category2" },
                new Categories { CategoryName = "Category3" }
            }.AsQueryable();

            Mock<DbSet<Categories>> mockSet = new Mock<DbSet<Categories>>();
            mockSet.As<IQueryable<Categories>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            Mock<NorthwindContext> mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            CategoriesLogic service = new CategoriesLogic(mockContext.Object);
            service.Delete(idAEliminar);

            mockSet.Verify(m => m.Remove(It.IsAny<Categories>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}