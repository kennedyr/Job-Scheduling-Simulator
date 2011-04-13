using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSchedSimulator
{
    public class Process : IComparable<Process>
    {
        public const int NEW = 0;
        public const int READY = 1;
        public const int RUNNING = 2;
        public const int BLOCKED = 3;
        public const int EXIT = 4;

        public int process_id { get; set; }
        public int arrival_time { get; set; }
        public int dispatched_at_time { get; set; }
        public int num_cpu_bursts { get; set; }
        public List<int> cpu_bursts { get; set; }
        public List<int> io_bursts { get; set; }

        public int turn_around_time { get; set; }
        public int running_time { get; set; }
        public int ready_wait { get; set; }
        public int io_wait { get; set; }

        public int state { get; set; }

        public Process()
        {
            cpu_bursts = new List<int>();
            io_bursts = new List<int>();
            state = -1;
        }
        public Process(int pid, int time, int num, List<int> cpu, List<int> io)
        {
            process_id = pid;
            arrival_time = time;
            num_cpu_bursts = num;
            cpu_bursts = cpu;
            io_bursts = io;
        }

        public static string STATES(int state)
        { //"New", "Ready", "Running", "Blocked", "Exit"
            switch (state)
            {
                case NEW:
                    return "New";
                case READY:
                    return "Ready";
                case RUNNING:
                    return "Running";
                case BLOCKED:
                    return "Blocked";
                case EXIT:
                    return "Exit";
            }
            //Shouldn't ever get here
            throw new FormatException();
        }
        public void AddCpuBurst(int burst)
        {
            cpu_bursts.Add(burst);
        }

        public void AddIoBurst(int burst)
        {
            io_bursts.Add(burst);
        }
	/* Sort by process_Id
	*/
        public int CompareTo(Process other)
        {
            return this.process_id - other.process_id;
        }
        /* Update stat values on clock tick
         */
        public void tick()
        {
            switch (state)
            {
                case NEW:
                    ready_wait++;
                    break;
                case READY:
                    ready_wait++;
                    break;
                case RUNNING:
                    running_time++;
                    break;
                case BLOCKED:
                    io_wait++;
                    break;
                case EXIT:
                    break;
                default:
                    break;
            }
        }
    }
}
