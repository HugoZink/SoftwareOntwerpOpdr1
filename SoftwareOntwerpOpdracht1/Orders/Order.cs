using SoftwareOntwerpOpdracht1.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    public class Order 
    {
		private List<Ticket> _tickets;
		private IMessage messager;
		private ILogger logger;

		public OrderState State { get; set; }
        
        public IEnumerable<Ticket> Tickets { get { return _tickets; } }
		public User User { get; private set; }
		public Show Show { get; set; }

        public Order(User user)
        {
			this.User = user;
            this._tickets = new List<Ticket>();

			this.messager = MessageFactory.CreateMessage(user);
			this.logger = LoggerFactory.CreateLogger();
		}
        
        public void AddTicket(Ticket ticket)
        {
			if (!State.CanManageTickets)
			{
				throw new InvalidOperationException();
			}

            _tickets.Add(ticket);
        }

        public void RemoveTicket(Ticket ticket)
        {
			if(!State.CanManageTickets)
			{
				throw new InvalidOperationException();
			}

			_tickets.Remove(ticket);
        }

		public void Submit()
		{
			this.State = this.State.Submit();

			this.messager.SendMessage(User, "Your order has been submitted, but has not yet been paid. Your seats have been reserved.");
		}

		public void Pay()
		{
			this.State = this.State.Pay();

			this.messager.SendMessage(User, "Your order has been successfully paid. Enjoy the show!");
			this.logger.Log($"User {User.ToString()} has paid for their order.");
		}

		public void Cancel()
		{
			this.State = this.State.Cancel();

			this.messager.SendMessage(User, "Your order has been successfully canceled.");
			this.logger.Log($"User {User.ToString()} has canceled their order.");
		}

		public void CheckTimeRemaining()
		{
			var now = DateTime.Now;

			//Do the submitted payment reminder check
			if((State.State == "Pending" || State.State == "Submitted") && now > Show.Date.AddHours(-24))
			{
				PerformPaymentReminder();
			}

			//Do the automatic cancel check
			if(State.State != "Paid" && State.State != "Canceled" && now > Show.Date.AddHours(-12))
			{
				PerformAutomaticCancel();
			}
		}

		private void PerformPaymentReminder()
		{
			this.messager.SendMessage(User, "You have not paid for your order yet.");
		}

		private void PerformAutomaticCancel()
		{
			this.State.Cancel();

			this.messager.SendMessage(User, "Your order has been automatically canceled.");
			this.logger.Log($"User {User.ToString()} had their order automatically canceled, due to failure to pay in time.");
		}
    }
}
