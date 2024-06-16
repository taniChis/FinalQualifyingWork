using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ДП
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            buttonCheckingTheOperation.Text = "Проверка \nфункциональности";
        }

        private void buttonAcceptanceOfPrintedCircuitBoards_Click(object sender, EventArgs e)
        {
            AcceptanceOfPrintedCircuitBoards acceptanceOfPrintedCircuitBoards = new AcceptanceOfPrintedCircuitBoards();
            this.Hide();
            acceptanceOfPrintedCircuitBoards.ShowDialog();
            this.Show();
        }
        private void buttonPrintedCircuitBoards_Click(object sender, EventArgs e)
        {
            PrintedCircuitBoards printedCircuitBoards = new PrintedCircuitBoards();
            this.Hide();
            printedCircuitBoards.ShowDialog();
            this.Show();
        }
        
        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            this.Hide();
            employee.ShowDialog();
            this.Show();
        }

        private void buttonSoftwareUpdate_Click(object sender, EventArgs e)
        {
            SoftwareUpdate softwareUpdate = new SoftwareUpdate();
            this.Hide();
            softwareUpdate.ShowDialog();
            this.Show();
        }

        private void buttonVisualInspection_Click(object sender, EventArgs e)
        {
            VisualInspection visualInspection = new VisualInspection();
            this.Hide();
            visualInspection.ShowDialog();
            this.Show();
        }

        private void buttonCheckingWithTheDevice_Click(object sender, EventArgs e)
        {
            CheckingWithTheDevice checkingWithTheDevice = new CheckingWithTheDevice();
            this.Hide();
            checkingWithTheDevice.ShowDialog();
            this.Show();
        }

        private void buttonCheckingTheOperation_Click(object sender, EventArgs e)
        {
            CheckingTheOperation checkingTheOperation = new CheckingTheOperation();
            this.Hide();
            checkingTheOperation.ShowDialog();
            this.Show();
        }

        private void buttonCheckingWhenThePowerIsOn_Click(object sender, EventArgs e)
        {
            CheckingWhenThePowerIsOn checkingWhenThePowerIsOn = new CheckingWhenThePowerIsOn();
            this.Hide();
            checkingWhenThePowerIsOn.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            this.Hide();
            report.ShowDialog();
            this.Show();
        }
        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
