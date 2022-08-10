using Microsoft.Extensions.Logging;

namespace Core.Common
{
    public class DefaultLoggingEvents
    {
		private const int RangeStart = 100000;
		// Default +0
		public static readonly EventId AggregateIdGenerated = new EventId(RangeStart + 1, "AggregateIdGenerated");

		// HTTP +50
		public static readonly EventId RequestReceive = new EventId(RangeStart + 51, "RequestReceive");
		public static readonly EventId RequestReply = new EventId(RangeStart + 52, "RequestReply");

		// Event-Driven +100
		public static readonly EventId EventPublishing = new EventId(RangeStart + 101, "EventPublishing");
		public static readonly EventId EventConsuming = new EventId(RangeStart + 102, "EventConsuming");
		public static readonly EventId EventAck = new EventId(RangeStart + 103, "EventAck");
		public static readonly EventId EventNack = new EventId(RangeStart + 104, "EventNack");
		public static readonly EventId EventReject = new EventId(RangeStart + 105, "EventReject");

		// Data +200
		public static readonly EventId DataQuery = new EventId(RangeStart + 200, "DataQuery");
		public static readonly EventId DataInsert = new EventId(RangeStart + 201, "DataInsert");
		public static readonly EventId DataUpdate = new EventId(RangeStart + 202, "DataUpdate");
		public static readonly EventId DataDelete = new EventId(RangeStart + 203, "DataDelete");
		public static readonly EventId DataUpdatePartial = new EventId(RangeStart + 204, "DataUpdatePartial");
	}
}
