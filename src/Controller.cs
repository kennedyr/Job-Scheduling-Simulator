using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace JobSchedSimulator
{
    public class Controller
    {
        public DisplayForm gui { get; set; }

        public List<Event> event_List;
        public List<Process> process_List;
        public List<int> ready_Queue;
        public List<int> IO_Queue;
        public int cpu;
        public int io;
        public int cpu_Idling_Time;
        public bool cpu_Is_Idling { get; set; }
        public bool io_Is_Idling { get; set; }
        public int simulation_Time { get; set; }
        public int time_quantum { get; set; }

        /*Constructor
         */
        public Controller()
        {
            event_List = new List<Event>();
            process_List = new List<Process>();
            ready_Queue = new List<int>();
            IO_Queue = new List<int>();

            cpu_Is_Idling = true;
            io_Is_Idling = true;
            simulation_Time = 0;
        }
        /*Perform actions required with each increment
         * of the simulation time.
         */
        public void Increment_Clock()
        {
            simulation_Time++;
            gui.Set_Simulation_Time(simulation_Time);
            if (cpu_Is_Idling)
                cpu_Idling_Time++;
            int cpuutil = 100 * (simulation_Time - cpu_Idling_Time) / simulation_Time;
            gui.Set_CPU_Utilization(cpuutil + "%");
            foreach (Process p in process_List)
            {
                p.tick();
                if (p.state > -1)
                {
                    gui.Set_Result_Table_CPU_Wait(p.process_id.ToString(), p.ready_wait);
                    gui.Set_Result_Table_IO_Wait(p.process_id.ToString(), p.io_wait);
                    gui.Set_Result_Table_Process_State(p.process_id.ToString(), Process.STATES(p.state));
                }
            }
            Generate_Events();
            Execute_Events();
            if (!CheckForLiveProcesses())
                gui.Next_Button_Deactivate();
        }

        private bool CheckForLiveProcesses()
        {
            foreach (Process p in process_List)
            {
                if (p.state != Process.EXIT)
                    return true;
            }
            return false;
        }

        /* Just in Time Generator
         * Generate the current events for this simulation time.
         */
        private void Generate_Events()
        {
            if (!cpu_Is_Idling)
            {
                process_List[cpu - 1].cpu_bursts[0]--;
                //Finished burst
                if (process_List[cpu - 1].cpu_bursts[0] == 0)
                {
                    //IO Request
                    if (process_List[cpu - 1].io_bursts.Count > 0)
                    {
                        event_List.Add(new Event(simulation_Time, Event.IO_REQUEST, cpu));
                    }
                    //Terminate
                    else
                    {
                        event_List.Add(new Event(simulation_Time, Event.TERMINATION, cpu));
                    }

                }

                //Preemption
                else if (process_List[cpu - 1].dispatched_at_time + time_quantum == simulation_Time)
                {
                    event_List.Add(new Event(simulation_Time, Event.PREEMPTION, cpu));
                }

            }
            if (!io_Is_Idling)
            {
                process_List[io - 1].io_bursts[0]--;
                //IO Done
                if (process_List[io - 1].io_bursts[0] == 0)
                {
                    event_List.Add(new Event(simulation_Time, Event.IO_DONE, io));
                }
            }
            //sort list by time, then event type
            event_List.Sort();
        }

        /*Insert the arrival time events
         */
        private void Populate_Event_List()
        {
            foreach (Process p in process_List)
            {
                event_List.Add(new Event(p.arrival_time, Event.ARRIVAL, p.process_id));
            }
            event_List.Sort();
        }

        /* Perform the Event Actions
         */
        private void Execute_Events()
        {
            foreach (Event e in event_List)
            {
                if (e.time == simulation_Time)
                {
                    switch (e.event_id)
                    {
                        case Event.ARRIVAL:
                            process_List[e.process_id - 1].state = Process.NEW;
                            ready_Queue.Add(e.process_id);
                            gui.Process_Arrival(e.process_id.ToString());
                            break;
                        case Event.PREEMPTION:
                            process_List[e.process_id - 1].state = Process.READY;
                            gui.Set_Result_Table_Process_State(e.process_id.ToString(), "Ready");
                            cpu = 0;
                            cpu_Is_Idling = true;
                            ready_Queue.Add(e.process_id);
                            gui.Process_Preemption(e.process_id.ToString());
                            break;
                        case Event.IO_REQUEST:
                            process_List[e.process_id - 1].state = Process.BLOCKED;
                            gui.Set_Result_Table_Process_State(e.process_id.ToString(), "Blocked");
                            process_List[e.process_id - 1].cpu_bursts.RemoveAt(0);
                            cpu = 0;
                            cpu_Is_Idling = true;
                            IO_Queue.Add(e.process_id);
                            gui.Process_IO_Request(e.process_id.ToString());
                            break;
                        case Event.IO_DONE:
                            process_List[e.process_id - 1].state = Process.READY;
                            gui.Set_Result_Table_Process_State(e.process_id.ToString(), "Ready");
                            process_List[e.process_id - 1].io_bursts.RemoveAt(0);
                            io = 0;
                            io_Is_Idling = true;
                            ready_Queue.Add(e.process_id);
                            gui.Process_IO_Done(e.process_id.ToString());
                            break;
                        case Event.TERMINATION:
                            process_List[e.process_id - 1].state = Process.EXIT;
                            Process p = process_List[e.process_id - 1];
                            gui.Set_Result_Table_Turn_Around_Time(p.process_id.ToString(), 
				p.ready_wait + p.io_wait + p.running_time);

                            gui.Set_Result_Table_Process_State(e.process_id.ToString(), "Exit");
                            process_List[e.process_id - 1].cpu_bursts.RemoveAt(0);
                            cpu = 0;
                            cpu_Is_Idling = true;
                            gui.Process_Termination(e.process_id.ToString());
                            break;
                    }

                    if (cpu_Is_Idling && ready_Queue.Count > 0)
                    {
                        cpu_Is_Idling = false;
                        CPU_Dispatch();

                    }
                    if (io_Is_Idling && IO_Queue.Count > 0)
                    {
                        io_Is_Idling = false;
                        IO_Dispatch();
                    }
                    //System.Threading.Thread.Sleep(500);
                }
            }
            for (int i = 0; i < event_List.Count; i++)
            {
                if (event_List[i].time == simulation_Time)
                {
                    event_List.RemoveAt(i);
                }
            }
            event_List.Sort();
        }
        /* Dispatch the first item in the Ready Queue
         */
        private void CPU_Dispatch()
        {
            cpu = ready_Queue[0];
            ready_Queue.RemoveAt(0);
            process_List[cpu - 1].state = Process.RUNNING;
            process_List[cpu - 1].dispatched_at_time = simulation_Time;
            gui.Cpu_Dispatch(cpu.ToString());
            gui.Set_Result_Table_Process_State(cpu.ToString(), "Running");
        }
        /* Dispatch the first item in the IO Queue
         */
        private void IO_Dispatch()
        {
            io = IO_Queue[0];
            IO_Queue.RemoveAt(0);
            process_List[io - 1].state = Process.RUNNING;
            gui.Io_Dispatch(io.ToString());
            gui.Set_Result_Table_Process_State(io.ToString(), "Running");
        }
        /*Debug Function to display all of the process info
         */
        private void Dump_All_Processes()
        {
            foreach (Process p in process_List)
            {
                Console.WriteLine(p.process_id);
                Console.WriteLine(p.arrival_time);
                Console.WriteLine(p.num_cpu_bursts);
                foreach (int a in p.cpu_bursts)
                {
                    Console.WriteLine(a);
                }
                foreach (int a in p.io_bursts)
                {
                    Console.WriteLine(a);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// Parses the input info and kicks off the other functions and classes.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var _this = new Controller();

            if (args.Length != 2)
            {
                Console.WriteLine("Program requires arguments consisting of a config file " +
                "with initialization values and a time quantum value.");
                Console.WriteLine("Usage: JobSchedSimulator.exe [input file] [quantum number]");
                Environment.Exit(1);
            }
            try
            {
                StreamReader fileReader;
                String line;
                _this.time_quantum = int.Parse(args[1]);
                fileReader = File.OpenText(args[0]);
                line = fileReader.ReadLine();
                string[] input_values;
                Process temp;
                int i;
                int process_id = 1;
                while (line != null)
                {
                    input_values = line.Split(new string[1] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    temp = new Process();
                    temp.process_id = process_id;
                    temp.arrival_time = int.Parse(input_values[0]);
                    temp.num_cpu_bursts = int.Parse(input_values[1]);

                    for (i = 2; i < input_values.Length; i++)
                    {
                        if (i % 2 == 0)
                            temp.AddCpuBurst(int.Parse(input_values[i]));
                        else
                            temp.AddIoBurst(int.Parse(input_values[i]));
                    }

                    _this.process_List.Add(temp);
                    process_id++;
                    line = fileReader.ReadLine();
                }

                fileReader.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Could Not Open file");
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Malformed input");
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }
            _this.Populate_Event_List();
            _this.gui = new DisplayForm(_this);
            Application.Run(_this.gui);
        }
    }
}
