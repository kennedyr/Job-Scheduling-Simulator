using System;
using System.Drawing;
using System.Windows.Forms;

namespace JobSchedSimulator
{
    public partial class DisplayForm : Form
    {
        public Controller controller;
        public DisplayForm(Controller o)
        {
            controller = o;
            /*Icon Setup
            try
            {
                var bitmap = new Bitmap("icon.png");
                var iconHandle = bitmap.GetHicon();    
                var icon = System.Drawing.Icon.FromHandle(iconHandle);
                Icon = new Icon(icon, 32, 32);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }*/

            InitializeComponent();
            Set_Quantum(controller.time_quantum);
        }

	/* Next button Click
	*/
        private void Next_Click(object sender, EventArgs e)
        {
            controller.Increment_Clock();
        }

        // Externally Available Functions
        // -
        // Process State Changes


        /* Process Arrival
         *
        */
        public void Process_Arrival(string name)
        {
            System.Windows.Forms.Label temp = new System.Windows.Forms.Label();

            temp.BackColor = System.Drawing.Color.LightSalmon;
            temp.Location = new System.Drawing.Point(3, 0);
            temp.Name = name;
            temp.Size = new System.Drawing.Size(50, 50);
            temp.TabIndex = 0;
            temp.Text = name;
            temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            CPU_Enqueue(temp);


            Label cell0 = new Label();
            Label cell1 = new Label();
            Label cell2 = new Label();
            Label cell3 = new Label();
            Label cell4 = new Label();

            cell0.Name = "pid" + name;
            cell0.Text = name;
            ResultTable.Controls.Add(cell0);
            cell1.Name = "state" + name;
            cell1.Text = "New";
            ResultTable.Controls.Add(cell1);
            cell2.Name = "tat" + name;
            cell2.Text = "0";
            ResultTable.Controls.Add(cell2);
            cell3.Name = "cpuwait" + name;
            cell3.Text = "0";
            ResultTable.Controls.Add(cell3);
            cell4.Name = "iowait" + name;
            cell4.Text = "0";
            ResultTable.Controls.Add(cell4);

        }

        /* Process Preemption
        */
        public void Process_Preemption(string name)
        {
            System.Windows.Forms.Label found_label;
            System.Windows.Forms.Control[] c = CPU.Controls.Find(name, false);
            found_label = (System.Windows.Forms.Label)c[0];

            CPU.Controls.Remove(found_label);
            SetCPUIdle();
            CPU_Enqueue(found_label);
        }

        /* Process IO Reqest
        */
        public void Process_IO_Request(string name)
        {
            Label found_label;
            Control[] c = CPU.Controls.Find(name, false);
            found_label = (Label)c[0];

            CPU.Controls.Remove(found_label);
            SetCPUIdle();
            IO_Enqueue(found_label);
        }

        /* Process IO Done
        */
        public void Process_IO_Done(string name)
        {
            Label found_label;
            Control[] c = IO.Controls.Find(name, false);
            found_label = (Label)c[0];

            IO.Controls.Remove(found_label);
            SetIOIdle();
            CPU_Enqueue(found_label);
        }

        /* Process Termination
        */
        public void Process_Termination(string name)
        {
            Label found_label;
            Control[] c = CPU.Controls.Find(name, false);
            found_label = (Label)c[0];

            CPU.Controls.Remove(found_label);
            SetCPUIdle();
        }

        /* CPU Dispatch
        */
        public void Cpu_Dispatch(string name)
        {
            setCPUNotIdle();
            CPU.Controls.Add(CPU_Dequeue(name));
        }

        /* IO Dispatch
        */
        public void Io_Dispatch(string name)
        {
            setIONotIdle();
            IO.Controls.Add(IO_Dequeue(name));
        }


        // Externally Available Functions
        // -
        // Label Data Changes

        /* turn off the next button
         */
        public void Next_Button_Deactivate()
        {
            Next.Enabled = false;
        }
        /* Set Quantum Value
         */
        public void Set_Quantum(int quantum)
        {
            this.Quantum.Text = this.Quantum1.Text = quantum.ToString();
        }

        /* Set SimTime Value
        */
        public void Set_Simulation_Time(int time)
        {
            this.SimTime.Text = time.ToString();
        }

        /* Set CPU Utilization
        */
        public void Set_CPU_Utilization(string cpuUtil)
        {
            this.cpuUtilization.Text = cpuUtil;
        }

        /* Set Result Table Process State
        */
        public void Set_Result_Table_Process_State(string name, string state)
        {
            Control[] c = ResultTable.Controls.Find("state" + name, true);
            c[0].Text = state;
        }

        /* Set Result Table Process Turn Around Time
        */
        public void Set_Result_Table_Turn_Around_Time(string name, int tat)
        {
            Control[] c = ResultTable.Controls.Find("tat" + name, true);
            c[0].Text = tat.ToString();
        }

        /* Set Result Table Process CPU Wait
        */
        public void Set_Result_Table_CPU_Wait(string name, int cpuWait)
        {
            Control[] c = ResultTable.Controls.Find("cpuwait" + name, true);
            c[0].Text = cpuWait.ToString();
        }

        /* Set Result Table Process IO Wait
        */
        public void Set_Result_Table_IO_Wait(string name, int ioWait)
        {
            Control[] c = ResultTable.Controls.Find("iowait" + name, true);
            c[0].Text = ioWait.ToString();
        }

        //
        // Helper Functions
        //

        /* Set CPU to Idle
         */
        private void SetCPUIdle()
        {
            CPU.Controls.Add(cpuIdle);
            cpuIdle.Show();
        }

        /* Hide CPU Idle
         */
        private void setCPUNotIdle()
        {
            cpuIdle.Hide();
            CPU.Controls.Remove(cpuIdle);
        }

        /* Set IO to Idle
        */
        private void SetIOIdle()
        {
            IO.Controls.Add(ioIdle);
            ioIdle.Show();
        }

        /* Hide ioIdle
        */
        private void setIONotIdle()
        {
            ioIdle.Hide();
            IO.Controls.Remove(ioIdle);
        }

        /* Add Label to readyQueue
        */
        private void CPU_Enqueue(System.Windows.Forms.Label process)
        {
            this.ReadyQueue.Controls.Add(process);
        }

        /* remove label from readyQueue
        */
        private System.Windows.Forms.Label CPU_Dequeue(string name)
        {
            var c = this.ReadyQueue.Controls.Find(name, false);
            this.ReadyQueue.Controls.Remove(c[0]);
            return (System.Windows.Forms.Label)c[0];
        }

        /* Add Label to IO Queue
        */
        private void IO_Enqueue(System.Windows.Forms.Label process)
        {
            this.ioQueue.Controls.Add(process);
        }

        /* Remove Label From IO Queue 
        */
        private System.Windows.Forms.Label IO_Dequeue(string name)
        {
            var c = this.ioQueue.Controls.Find(name, false);
            this.ioQueue.Controls.Remove(c[0]);
            return (System.Windows.Forms.Label)c[0];
        }


    }
}
