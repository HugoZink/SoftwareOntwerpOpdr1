using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareOntwerpOpdracht1.Orders;
using System.Linq;

namespace CinemaTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestPendingOrderAddTickets()
		{
			var ticket = new Ticket() { Seat = 1 };

			IOrder order = new PendingOrder();
			order.AddTicket(ticket);

			Assert.AreEqual(1, order.Tickets.Count());
			Assert.AreEqual(ticket, order.Tickets.First());
			Assert.AreEqual("Pending", order.State);
		}

		[TestMethod]
		public void TestPendingOrderRemoveTickets()
		{
			var ticket = new Ticket() { Seat = 1 };

			IOrder order = new PendingOrder();
			order.AddTicket(ticket);
			order.RemoveTicket(ticket);

			Assert.AreEqual(0, order.Tickets.Count());
		}

		[TestMethod]
		public void TestSubmitOrder()
		{
			var ticket = new Ticket() { Seat = 1 };

			IOrder order = new PendingOrder();
			order.AddTicket(ticket);
			order = order.Advance();

			Assert.AreEqual("Submitted", order.State);
		}

		[TestMethod]
		public void TestCancelPendingOrder()
		{
			var ticket = new Ticket() { Seat = 1 };

			IOrder order = new PendingOrder();
			order = order.Cancel();

			Assert.AreEqual("Canceled", order.State);
			Assert.ThrowsException<InvalidOperationException>( () => { order.AddTicket(ticket); } );
			Assert.ThrowsException<InvalidOperationException>(() => { order.RemoveTicket(ticket); });
		}

		[TestMethod]
		public void TestCancelSubmittedOrder()
		{
			var ticket = new Ticket() { Seat = 1 };

			IOrder order = new PendingOrder();
			order = order.Advance();
			order = order.Cancel();

			Assert.AreEqual("Canceled", order.State);
			Assert.ThrowsException<InvalidOperationException>(() => { order.AddTicket(ticket); });
		}

		[TestMethod]
		public void TestPaidOrder()
		{
			var ticket = new Ticket() { Seat = 1 };

			IOrder order = new PendingOrder();
			order = order.Advance();
			order = order.Advance();

			Assert.AreEqual("Paid", order.State);
			Assert.ThrowsException<InvalidOperationException>(() => { order.AddTicket(ticket); });
			Assert.ThrowsException<InvalidOperationException>(() => { order.RemoveTicket(ticket); });
		}

		[TestMethod]
		public void TestPaidOrderInvalidOperations()
		{
			var ticket = new Ticket() { Seat = 1 };

			IOrder order = new PendingOrder();
			order = order.Advance();
			order = order.Advance();

			Assert.ThrowsException<InvalidOperationException>(() => { order = order.Advance(); });
			Assert.ThrowsException<InvalidOperationException>(() => { order = order.Cancel(); });
		}

		[TestMethod]
		public void TestCancelOrderInvalidOperations()
		{
			var ticket = new Ticket() { Seat = 1 };

			IOrder order = new PendingOrder();
			order = order.Cancel();

			Assert.ThrowsException<InvalidOperationException>(() => { order = order.Advance(); });
			Assert.ThrowsException<InvalidOperationException>(() => { order = order.Cancel(); });
		}
	}
}
