using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BH4.WindowsFormsApp
{
    public partial class Form1 : Form
    {
        List<Panel> listPanel = new List<Panel>();
        int currentPanelIdx = 0;

        private string RunPythonScript(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = cmd;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.panelStart.Controls.Add(btnStart);
            this.panelStart.Controls.Add(lblTitle);


            // Add Panels to list and hide
            listPanel.Add(this.panelStart);
            listPanel.Add(this.panelInput);
            this.panelInput.Hide();
            this.panelStart.Hide();

            listPanel[currentPanelIdx].Show();

        }

        
        // btnStart_Click
        private void button1_Click(object sender, EventArgs e)
        {
            // Switching panels
            listPanel[currentPanelIdx].Hide();
            currentPanelIdx++;
            listPanel[currentPanelIdx].Show();
        }

        private void panelStart_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            string input = this.txtCategoryInput.Text;

        }
    }
}
