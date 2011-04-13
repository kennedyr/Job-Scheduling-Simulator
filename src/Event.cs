using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSchedSimulator
{

    public class Event : IComparable<Event>
    {
        public const int ARRIVAL = 0;
        public const int IO_REQUEST = 1;
        public const int IO_DONE = 2;
        public const int PREEMPTION = 3;
        public const int TERMINATION = 4;

        public int time { get; set; }
        public int event_id { get; set; }
        public int process_id { get; set; }

        public Event() { }

        public Event(int time, int event_id, int process_id)
        {
            this.time = time;
            this.event_id = event_id;
            this.process_id = process_id;
        }
	/* Sort by time, then event_id
	*/
        public int CompareTo(Event other)
        {
            int time_diff = this.time - other.time;
            if (time_diff != 0) return time_diff;
            return this.event_id - other.event_id;
        }
    }
}
