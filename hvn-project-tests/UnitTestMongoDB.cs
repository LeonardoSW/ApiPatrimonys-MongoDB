using Microsoft.VisualStudio.TestTools.UnitTesting;
using hvn_project.Repository;
using hvn_project.Models;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace hvn_project_tests
{
    [TestClass]
    public class UnitTestMongoDB
    {
        MongoRepository database = new MongoRepository();
        Random rand = new Random();        


        [TestMethod]
        public void TestFlowsPersistency()
        {
            string patrimonyNumberTest = rand.Next(100000, 100100).ToString();

            PatrimonyItems itemTest = new PatrimonyItems()
            {
                Id = null,
                PatrimonyNumber = patrimonyNumberTest,
                Description = "Ref: Unit Test",
                CreateDate = DateTime.Now,
                Status = PatrimonyStatus.Inactive,
                UpdateDate = DateTime.Now
            };

            database.InsertPatrimonyItemAsync(itemTest).GetAwaiter().GetResult();

            itemTest.Status = PatrimonyStatus.Active;

            database.UpdatePatrimonyItemAsync(itemTest).GetAwaiter().GetResult();

            string idTest = database.GetPatrimonyItensByFilterAsync(patrimonyNumberTest).GetAwaiter().GetResult().FirstOrDefault().Id;
            Assert.IsNotNull(idTest);

            database.DeletePatrimonyItemByIdAsync(idTest).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void TestMethodRecovery()
        {
            var response = database.GetPatrimonyItensListAsync().GetAwaiter().GetResult();
            Assert.IsNotNull(response);
        }
    }
}
