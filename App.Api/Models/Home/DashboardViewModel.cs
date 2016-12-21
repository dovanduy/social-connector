namespace App.Api.Models.Home
{
    using System.Collections.Generic;
    using App.Service.Message;

    public class DashboardViewModel
    {
        public IList<MessageListItem> Messages { get; set; }
    }
}