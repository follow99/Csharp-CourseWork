using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CA1_MVC1;
using CA1_MVC1.Controllers;
using CA1_MVC1.Models;
using Moq;


namespace CA1_MVC1.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {

            //创建MOCK对象
            var mock = new Mock<ISMSTextRepository>();
            //设置MOCK调用行为
            mock.Setup(p => p.GetContactById("1")).Returns(new SMSText());
            //MOCK调用方法
            mock.Object.GetContactById("1");
            Assert.AreNotSame(new SMSText(), mock.Object.GetContactById("1"));
            // Arrange
            //SMSTextController controller = new SMSTextController();
            //ContactListDbtest db = new ContactListDbtest();
            // Act
            //pass areacode phoneNumber without db
            // ViewResult result = controller.Index("085","4789562") as ViewResult;
            //pass areacode phoneNumber with db
            //ViewResult result = controller.Index(1) as ViewResult;
            // Assert
            //Assert.IsNotNull(result);
        }
        [TestMethod()]
        public void ConfirmedTest()
        {
            SMSTextController controller = new SMSTextController();
            
            SMSText smsText=new SMSText();
            ViewResult result = controller.Confirmed(new SMSText()) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void NotFoundTest()
        {
            SMSTextController controller = new SMSTextController();
            ViewResult result = controller.NotFound(new SMSText()) as ViewResult;
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void About()
        {
            // Arrange
            SMSTextController controller = new SMSTextController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Description page.", result.ViewBag.Message);
        }

        /**
        [TestMethod]
        public void Contact()
        {
            // Arrange
            SMSTextController controller = new SMSTextController();

            // Act
            //pass areacode phoneNumber without db
            //ViewResult result = controller.Index("085", "4789562") as ViewResult;
            //pass areacode phoneNumber with db
            ViewResult result = controller.Index(1) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }*/
    }
}
