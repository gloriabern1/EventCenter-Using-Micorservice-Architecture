
using GloriaEvent.Grpc;
using GloriaEvent.web.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events = GloriaEvent.web.Models.ServiceModels.Events;

namespace GloriaEvent.web.Models.ViewModels
{
    public class EventsListModel
    {
        public IEnumerable<Events> Events { get; set; }
        public Guid SelectedCategory { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
    }

    public class EventsListModelGRPC
    {
        public IEnumerable<GloriaEvent.Grpc.Event> Event { get; set; }
        public Guid SelectedCategory { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
