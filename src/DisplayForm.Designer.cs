using System.Collections.Generic;
namespace JobSchedSimulator
{
    partial class DisplayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed;
	/// otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReadyQueueLabel = new System.Windows.Forms.Label();
            this.SimTimeLabel = new System.Windows.Forms.Label();
            this.SimTime = new System.Windows.Forms.Label();
            this.QuantumLabel = new System.Windows.Forms.Label();
            this.Quantum = new System.Windows.Forms.Label();
            this.CPU = new System.Windows.Forms.FlowLayoutPanel();
            this.cpuIdle = new System.Windows.Forms.Label();
            this.IO = new System.Windows.Forms.FlowLayoutPanel();
            this.ioIdle = new System.Windows.Forms.Label();
            this.IOLabel = new System.Windows.Forms.Label();
            this.IOQueueLabel = new System.Windows.Forms.Label();
            this.CPULabel = new System.Windows.Forms.Label();
            this.Next = new System.Windows.Forms.Button();
            this.ReadyQueue = new System.Windows.Forms.FlowLayoutPanel();
            this.ioQueue = new System.Windows.Forms.FlowLayoutPanel();
            this.ResultTable = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Quantum1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cpuUtilization = new System.Windows.Forms.Label();
            this.CPU.SuspendLayout();
            this.IO.SuspendLayout();
            this.ResultTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReadyQueueLabel
            // 
            this.ReadyQueueLabel.AutoSize = true;
            this.ReadyQueueLabel.Location = new System.Drawing.Point(12, 46);
            this.ReadyQueueLabel.Name = "ReadyQueueLabel";
            this.ReadyQueueLabel.Size = new System.Drawing.Size(76, 13);
            this.ReadyQueueLabel.TabIndex = 0;
            this.ReadyQueueLabel.Text = "Ready Queue:";
            // 
            // SimTimeLabel
            // 
            this.SimTimeLabel.AutoSize = true;
            this.SimTimeLabel.Location = new System.Drawing.Point(9, 9);
            this.SimTimeLabel.Name = "SimTimeLabel";
            this.SimTimeLabel.Size = new System.Drawing.Size(87, 13);
            this.SimTimeLabel.TabIndex = 2;
            this.SimTimeLabel.Text = "Simulation Time: ";
            // 
            // SimTime
            // 
            this.SimTime.AutoSize = true;
            this.SimTime.Location = new System.Drawing.Point(102, 9);
            this.SimTime.Name = "SimTime";
            this.SimTime.Size = new System.Drawing.Size(13, 13);
            this.SimTime.TabIndex = 3;
            this.SimTime.Text = "0";
            // 
            // QuantumLabel
            // 
            this.QuantumLabel.AutoSize = true;
            this.QuantumLabel.Location = new System.Drawing.Point(525, 9);
            this.QuantumLabel.Name = "QuantumLabel";
            this.QuantumLabel.Size = new System.Drawing.Size(56, 13);
            this.QuantumLabel.TabIndex = 4;
            this.QuantumLabel.Text = "Quantum: ";
            // 
            // Quantum
            // 
            this.Quantum.AutoSize = true;
            this.Quantum.Location = new System.Drawing.Point(587, 9);
            this.Quantum.Name = "Quantum";
            this.Quantum.Size = new System.Drawing.Size(13, 13);
            this.Quantum.TabIndex = 5;
            this.Quantum.Text = "0";
            // 
            // CPU
            // 
            this.CPU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CPU.Controls.Add(this.cpuIdle);
            this.CPU.Location = new System.Drawing.Point(550, 63);
            this.CPU.Name = "CPU";
            this.CPU.Size = new System.Drawing.Size(54, 50);
            this.CPU.TabIndex = 6;
            // 
            // cpuIdle
            // 
            this.cpuIdle.BackColor = System.Drawing.Color.Transparent;
            this.cpuIdle.Location = new System.Drawing.Point(3, 0);
            this.cpuIdle.Name = "cpuIdle";
            this.cpuIdle.Size = new System.Drawing.Size(49, 49);
            this.cpuIdle.TabIndex = 16;
            this.cpuIdle.Text = "Idle";
            this.cpuIdle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IO
            // 
            this.IO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IO.Controls.Add(this.ioIdle);
            this.IO.Location = new System.Drawing.Point(12, 150);
            this.IO.Name = "IO";
            this.IO.Size = new System.Drawing.Size(54, 50);
            this.IO.TabIndex = 7;
            // 
            // ioIdle
            // 
            this.ioIdle.BackColor = System.Drawing.Color.Transparent;
            this.ioIdle.Location = new System.Drawing.Point(3, 0);
            this.ioIdle.Name = "ioIdle";
            this.ioIdle.Size = new System.Drawing.Size(49, 49);
            this.ioIdle.TabIndex = 15;
            this.ioIdle.Text = "Idle";
            this.ioIdle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IOLabel
            // 
            this.IOLabel.AutoSize = true;
            this.IOLabel.Location = new System.Drawing.Point(12, 134);
            this.IOLabel.Name = "IOLabel";
            this.IOLabel.Size = new System.Drawing.Size(23, 13);
            this.IOLabel.TabIndex = 8;
            this.IOLabel.Text = "I/O";
            // 
            // IOQueueLabel
            // 
            this.IOQueueLabel.AutoSize = true;
            this.IOQueueLabel.Location = new System.Drawing.Point(102, 134);
            this.IOQueueLabel.Name = "IOQueueLabel";
            this.IOQueueLabel.Size = new System.Drawing.Size(61, 13);
            this.IOQueueLabel.TabIndex = 10;
            this.IOQueueLabel.Text = "I/O Queue:";
            // 
            // CPULabel
            // 
            this.CPULabel.AutoSize = true;
            this.CPULabel.Location = new System.Drawing.Point(547, 46);
            this.CPULabel.Name = "CPULabel";
            this.CPULabel.Size = new System.Drawing.Size(29, 13);
            this.CPULabel.TabIndex = 11;
            this.CPULabel.Text = "CPU";
            // 
            // Next
            // 
            this.Next.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Next.Location = new System.Drawing.Point(262, 360);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 23);
            this.Next.TabIndex = 12;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // ReadyQueue
            // 
            this.ReadyQueue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReadyQueue.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ReadyQueue.Location = new System.Drawing.Point(12, 63);
            this.ReadyQueue.Name = "ReadyQueue";
            this.ReadyQueue.Size = new System.Drawing.Size(500, 50);
            this.ReadyQueue.TabIndex = 13;
            // 
            // ioQueue
            // 
            this.ioQueue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ioQueue.Location = new System.Drawing.Point(100, 150);
            this.ioQueue.Name = "ioQueue";
            this.ioQueue.Size = new System.Drawing.Size(500, 50);
            this.ioQueue.TabIndex = 14;
            // 
            // ResultTable
            // 
            this.ResultTable.AutoScroll = true;
            this.ResultTable.ColumnCount = 5;
            this.ResultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResultTable.Controls.Add(this.label7, 4, 0);
            this.ResultTable.Controls.Add(this.label6, 3, 0);
            this.ResultTable.Controls.Add(this.label4, 0, 0);
            this.ResultTable.Controls.Add(this.label3, 2, 0);
            this.ResultTable.Controls.Add(this.label1, 1, 0);
            this.ResultTable.Location = new System.Drawing.Point(12, 244);
            this.ResultTable.Name = "ResultTable";
            this.ResultTable.RowCount = 2;
            this.ResultTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResultTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResultTable.Size = new System.Drawing.Size(588, 101);
            this.ResultTable.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "IO Wait";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Ready Wait";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Process ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Turn Around Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "State";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Results For Quantum = ";
            // 
            // Quantum1
            // 
            this.Quantum1.AutoSize = true;
            this.Quantum1.Location = new System.Drawing.Point(134, 228);
            this.Quantum1.Name = "Quantum1";
            this.Quantum1.Size = new System.Drawing.Size(13, 13);
            this.Quantum1.TabIndex = 17;
            this.Quantum1.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(153, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "CPU Utilization: ";
            // 
            // cpuUtilization
            // 
            this.cpuUtilization.AutoSize = true;
            this.cpuUtilization.Location = new System.Drawing.Point(242, 228);
            this.cpuUtilization.Name = "cpuUtilization";
            this.cpuUtilization.Size = new System.Drawing.Size(21, 13);
            this.cpuUtilization.TabIndex = 19;
            this.cpuUtilization.Text = "0%";
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 395);
            this.Controls.Add(this.cpuUtilization);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Quantum1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ResultTable);
            this.Controls.Add(this.ioQueue);
            this.Controls.Add(this.ReadyQueue);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.CPULabel);
            this.Controls.Add(this.IOQueueLabel);
            this.Controls.Add(this.IOLabel);
            this.Controls.Add(this.IO);
            this.Controls.Add(this.CPU);
            this.Controls.Add(this.Quantum);
            this.Controls.Add(this.QuantumLabel);
            this.Controls.Add(this.SimTime);
            this.Controls.Add(this.SimTimeLabel);
            this.Controls.Add(this.ReadyQueueLabel);
            this.Name = "DisplayForm";
            this.Text = "Job Scheduling Simulator";
            this.CPU.ResumeLayout(false);
            this.IO.ResumeLayout(false);
            this.ResultTable.ResumeLayout(false);
            this.ResultTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ReadyQueueLabel;
        private System.Windows.Forms.Label SimTimeLabel;
        private System.Windows.Forms.Label SimTime;
        private System.Windows.Forms.Label QuantumLabel;
        private System.Windows.Forms.Label Quantum;
        private System.Windows.Forms.FlowLayoutPanel CPU;
        private System.Windows.Forms.FlowLayoutPanel IO;
        private System.Windows.Forms.Label IOLabel;
        private System.Windows.Forms.Label IOQueueLabel;
        private System.Windows.Forms.Label CPULabel;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Label cpuIdle;
        private System.Windows.Forms.Label ioIdle;
        private System.Windows.Forms.FlowLayoutPanel ReadyQueue;
        private System.Windows.Forms.FlowLayoutPanel ioQueue;
        private System.Windows.Forms.TableLayoutPanel ResultTable;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Quantum1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label cpuUtilization;
        private System.Windows.Forms.Label label1;

    }
}

