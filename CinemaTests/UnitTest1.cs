using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareOntwerpOpdracht1.Orders;
using System.Linq;
using SoftwareOntwerpOpdracht1.Movies;

namespace CinemaTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestPendingOrderAddTickets()
		{
			var ticket = new Ticket() { Seat = 1 };
			var user = new User("email");

			Order order = new Order(user);
			order.AddTicket(ticket);

			Assert.AreEqual(1, order.Tickets.Count());
			Assert.AreEqual(ticket, order.Tickets.First());
			Assert.AreEqual("Pending", order.State.State);
		}

		[TestMethod]
		public void TestPendingOrderRemoveTickets()
		{
			var ticket = new Ticket() { Seat = 1 };
			var user = new User("email");

			Order order = new Order(user);
			order.AddTicket(ticket);
			order.RemoveTicket(ticket);

			Assert.AreEqual(0, order.Tickets.Count());
		}

		[TestMethod]
		public void TestSubmitOrder()
		{
			var ticket = new Ticket() { Seat = 1 };
			var user = new User("email");

			Order order = new Order(user);
			order.AddTicket(ticket);
			order.Submit();

			Assert.AreEqual("Submitted", order.State.State);
		}

		[TestMethod]
		public void TestSubmittedOrderAddTickets()
		{
			var ticket = new Ticket() { Seat = 1 };
			var user = new User("email");

			Order order = new Order(user);
			order.Submit();
			order.AddTicket(ticket);

			Assert.AreEqual(1, order.Tickets.Count());
			Assert.AreEqual(ticket, order.Tickets.First());
			Assert.AreEqual("Submitted", order.State.State);
		}

		[TestMethod]
		public void TestSubmittedOrderRemoveTickets()
		{
			var ticket = new Ticket() { Seat = 1 };
			var user = new User("email");

			Order order = new Order(user);
			order.Submit();
			order.AddTicket(ticket);
			order.RemoveTicket(ticket);

			Assert.AreEqual(0, order.Tickets.Count());
		}

		[TestMethod]
		public void TestCancelPendingOrder()
		{
			var ticket = new Ticket() { Seat = 1 };
			var user = new User("email");

			Order order = new Order(user);
			order.AddTicket(ticket);
			order.Cancel();

			Assert.AreEqual("Canceled", order.State.State);
			Assert.ThrowsException<InvalidOperationException>( () => { order.AddTicket(ticket); } );
			Assert.ThrowsException<InvalidOperationException>(() => { order.RemoveTicket(ticket); });
		}

		[TestMethod]
		public void TestCancelSubmittedOrder()
		{
			var ticket = new Ticket() { Seat = 1 };
			var user = new User("email");

			Order order = new Order(user);
			order.AddTicket(ticket);
			order.Cancel();

			Assert.AreEqual("Canceled", order.State.State);
			Assert.ThrowsException<InvalidOperationException>(() => { order.AddTicket(ticket); });
		}

		[TestMethod]
		public void TestPaidOrder()
		{
			var ticket = new Ticket() { Seat = 1 };
			var user = new User("email");

			Order order = new Order(user);
			order.AddTicket(ticket);
			order.Submit();
			order.Pay();

			Assert.AreEqual("Paid", order.State.State);
			Assert.ThrowsException<InvalidOperationException>(() => { order.AddTicket(ticket); });
			Assert.ThrowsException<InvalidOperationException>(() => { order.RemoveTicket(ticket); });
		}

		[TestMethod]
		public void TestPaidOrderInvalidOperations()
		{
			var ticket = new Ticket() { Seat = 1 };
			var user = new User("email");

			Order order = new Order(user);
			order.AddTicket(ticket);
			order.Submit();
			order.Pay();

			Assert.ThrowsException<InvalidOperationException>(() => { order.Submit(); });
			Assert.ThrowsException<InvalidOperationException>(() => { order.Pay(); });
			Assert.ThrowsException<InvalidOperationException>(() => { order.Cancel(); });
		}

		[TestMethod]
		public void TestCancelOrderInvalidOperations()
		{
			var ticket = new Ticket() { Seat = 1 };
			var user = new User("email");

			Order order = new Order(user);
			order.AddTicket(ticket);
			order.Cancel();

			Assert.ThrowsException<InvalidOperationException>(() => { order.Submit(); });
			Assert.ThrowsException<InvalidOperationException>(() => { order.Pay(); });
			Assert.ThrowsException<InvalidOperationException>(() => { order.Cancel(); });
		}

		[TestMethod]
		public void TestMessageFactory()
		{
			var emailUser = new User("email");
			var smsUser = new User("sms");
			var whatsappUser = new User("whatsapp");

			Assert.IsInstanceOfType(MessageFactory.CreateMessage(emailUser), typeof(EmailMessage));
			Assert.IsInstanceOfType(MessageFactory.CreateMessage(smsUser), typeof(SMSMessage));
			Assert.IsInstanceOfType(MessageFactory.CreateMessage(whatsappUser), typeof(WhatsappMessage));
		}

		[TestMethod]
		public void TestAutomaticPaymentReminder()
		{
			var show = new Show()
			{
				Date = DateTime.Now.AddHours(23),
				Movie = new Movie() { Title = "A movie" },
				Room = new Room() { Number = 1 }
			};

			var user = new User("email");
			var order = new Order(user);
			order.Show = show;
			order.AddTicket(new Ticket() { Seat = 1 });
			order.Submit();

			Assert.AreEqual(false, order.PaymentReminderSent);

			order.CheckTimeRemaining();

			Assert.AreEqual("Submitted", order.State.State);
			Assert.AreEqual(true, order.PaymentReminderSent);
		}

		[TestMethod]
		public void TestAutomaticCancel()
		{
			var show = new Show()
			{
				Date = DateTime.Now.AddHours(11),
				Movie = new Movie() { Title = "A movie" },
				Room = new Room() { Number = 1 }
			};

			var user = new User("email");
			var order = new Order(user);
			order.Show = show;
			order.AddTicket(new Ticket() { Seat = 1 });
			order.Submit();

			order.CheckTimeRemaining();

			Assert.AreEqual("Canceled", order.State.State);
		}

		[TestMethod]
		public void TestPopcornOption()
		{
			var ticket = new Ticket() { Seat = 1 };
			var user = new User("email");

			Order order = new Order(user);
			order.AddTicket(ticket);
			order.AddOption(new PopcornOption());
			order.AddOption(new PopcornOption());

			Assert.AreEqual(2, order.Options.Count());
			Assert.AreEqual(2.0m, order.Options.First().Price);
			Assert.IsInstanceOfType(order.Options.First(), typeof(PopcornOption));
		}

		[TestMethod]
		public void TestParkingOption()
		{
			var ticket = new Ticket() { Seat = 1 };
			var user = new User("email");

			Order order = new Order(user);
			order.AddTicket(ticket);
			order.AddOption(new ParkingOption());

			Assert.AreEqual(1, order.Options.Count());
			Assert.AreEqual(3.0m, order.Options.First().Price);
			Assert.IsInstanceOfType(order.Options.First(), typeof(ParkingOption));
		}

		[TestMethod]
		public void TestBreakCateringOption()
		{
			var ticket = new Ticket() { Seat = 1 };
			var user = new User("email");

			Order order = new Order(user);
			order.AddTicket(ticket);
			order.AddOption(new BreakCateringOption());

			Assert.AreEqual(1, order.Options.Count());
			Assert.AreEqual(5.0m, order.Options.First().Price);
			Assert.IsInstanceOfType(order.Options.First(), typeof(BreakCateringOption));
		}

		[TestMethod]
		public void TestRemoveOptions()
		{
			var ticket = new Ticket() { Seat = 1 };
			var user = new User("email");

			Option catering = new BreakCateringOption();
			Option popcorn = new PopcornOption();
			Option parking = new ParkingOption();

			Order order = new Order(user);
			order.AddTicket(ticket);
			order.AddOption(catering);
			order.AddOption(popcorn);
			order.AddOption(parking);

			order.RemoveOption(catering);
			order.RemoveOption(popcorn);

			Assert.AreEqual(1, order.Options.Count());
			Assert.AreEqual(3.0m, order.Options.First().Price);
			Assert.IsInstanceOfType(order.Options.First(), typeof(ParkingOption));
		}
	}
}
