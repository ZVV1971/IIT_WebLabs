using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZVV_Web_Lab_1.Controllers;
using ZVV_Web_Lab_1.Models;
using DAL_ZVV.Entities;
using DAL_ZVV.Interfaces;
using Moq;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;

namespace ZVV_Web_Lab_1.Tests.Controllers
{
    [TestClass]
    public class PagingTest
    {
        [TestMethod]
        public void CatalogPagingTest()
        {
            var mock = new Mock<IRepository<LabGlassware>>();
            mock.Setup(r => r.GetAll()).Returns(new List<LabGlassware>
                {
                    new LabGlassware { GW_ID=1 },
                    new LabGlassware { GW_ID=2 },
                    new LabGlassware { GW_ID=3 },
                    new LabGlassware { GW_ID=4 },
                    new LabGlassware { GW_ID=5 }
            });

            // Макеты для получения HttpContext HttpRequest 
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Создание объекта контроллера 
            GWController controller = new GWController(mock.Object);

            NameValueCollection valueCollection = new NameValueCollection();
            valueCollection.Add("Accept", "application/json");
            valueCollection.Add("X-Requested-With", "XMLHttpRequest");
            
            //другой вариант: 
            //valueCollection.Add("Accept", "HTML");
            request.Setup(r => r.Headers).Returns(valueCollection); 

            // Создание контекста контроллера 
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            // Act 
            // Вызов метода List  
            ViewResult view = controller.List(null, 2) as ViewResult;

            // Assert 
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<LabGlassware> model = view.Model as PageListViewModel<LabGlassware>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(4, model[0].GW_ID);
            Assert.AreEqual(5, model[1].GW_ID);
        }
    }
}
