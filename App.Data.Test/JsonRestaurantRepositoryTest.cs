using NUnit.Framework;
using App.Data;

namespace App.Data.Test
{
    [TestFixture]
    public class JsonRestaurantRepositoryTest
    {
        [Test]
        public void LoadDocument()
        {
            var loader = new JsonRestaurantRepository();
            var result = loader.LoadJson(
            @".\resources\restaurants.net.json");
            loader.SaveData(result);
            Assert.AreEqual(1, result.Count);
        }
    }
}