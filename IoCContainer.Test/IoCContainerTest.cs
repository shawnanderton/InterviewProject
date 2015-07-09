using NUnit.Framework;
using IoCContainer;
using IoCContainer.Enums;
using System;

namespace IoCContainer.Test
{

    [TestFixture]
    public class IoCContainerTest
    {
        

        [TestFixtureSetUp]
        public void Init()
        {
          
            
        }
        [Test]
        public void ShouldReloveObject()
        {
            Container container = new Container();
            container.Register<ICustomer, Customer>();
           

            var customer = container.Resolve<ICustomer>();
            Assert.That(customer, Is.InstanceOfType(typeof(Customer)));
        }
        [Test]
        public void ShouldCreateTransientInstanceByDefault()
        {
            Container container = new Container();
            container.Register<ICustomer, Customer>();
            container.Register<IOrder, Order>();
           
            var order1 = container.Resolve<IOrder>();
            order1.Customer.FirstName = "Bob";

            var order2 = container.Resolve<IOrder>();
            order2.Customer.FirstName = "Joe";

            Assert.AreNotEqual(((Order)order1).Customer.FirstName, ((Order)order2).Customer.FirstName);
        }

        [Test]
        public void CanCreateInstanceSinlgeton()
        {

            Container container = new Container();
            container.Register<ICustomer, Customer>(LifestyleType.Singleton);

            var customer1 = container.Resolve<ICustomer>();
            var customer2 = container.Resolve<ICustomer>();

            Assert.That(customer2, Is.SameAs(customer1));
        }

        [Test]
        public void ShouldThrowExceptionIfTypeNotRegistered()
        {
            Container container = new Container();

            Exception exception = null;
            try
            {
                container.Resolve<ICustomer>();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.That(exception, Is.InstanceOfType(typeof(Exception)));
        }

        [Test]
        public void ShouldResolveObjectAndConstructorParameters()
        {
            var container = new Container();

            container.Register<ICustomer, Customer>();
            container.Register<IOrder, Order>();

            var instance = container.Resolve<IOrder>();

            Assert.That(instance, Is.InstanceOfType(typeof(Order)));
        }

    }

    public interface ICustomer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
    public class Customer : ICustomer
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public interface IOrder
    {
       
        ICustomer Customer { get; set; }


    }
    public class Order : IOrder
    {
        public Order(ICustomer customer)
        {
            Customer = customer;
        }

      
        public ICustomer Customer { get; set; }


    }
}