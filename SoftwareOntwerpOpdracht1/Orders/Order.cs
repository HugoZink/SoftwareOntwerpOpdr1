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
		private List<Option> _options;
		private IMessage messager;
		private ILogger logger;

		public OrderState State { get; set; }
        
		public bool PaymentReminderSent { get; private set; }
        public IEnumerable<Ticket> Tickets { get { return _tickets; } }
		public IEnumerable<Option> Options { get { return _options; } }
		public User User { get; private set; }
		public Show Show { get; set; }

        public Order(User user)
        {
			this.User = user;
            this._tickets = new List<Ticket>();
			this._options = new List<Option>();

			this.State = OrderStateFactory.GetInitialOrder();
			this.messager = MessageFactory.CreateMessage(user);
			this.logger = LoggerFactory.CreateLogger();
		}

        public void AddOption(Option option)
        {
			this._options.Add(option);
        }

        public void RemoveOption(Option option)
        {
			this._options.Remove(option);
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
			this.logger.Log($"User {User.id} has paid for their order.");
		}

		public void Cancel()
		{
			this.State = this.State.Cancel();

			this.messager.SendMessage(User, "Your order has been successfully canceled.");
			this.logger.Log($"User {User.id} has canceled their order.");
		}

		public void CheckTimeRemaining()
		{
			//This function will normally be called by some external source every 10 minutes.
			//For this exercise, it will probably be manually called from the tests instead.

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
			if(PaymentReminderSent)
			{
				return;
			}

			this.messager.SendMessage(User, "You have not paid for your order yet.");
			PaymentReminderSent = true;
		}

		private void PerformAutomaticCancel()
		{
			this.State = this.State.Cancel();

			this.messager.SendMessage(User, "Your order has been automatically canceled.");
			this.logger.Log($"User {User.id} had their order automatically canceled, due to failure to pay in time.");
		}
    }
}
