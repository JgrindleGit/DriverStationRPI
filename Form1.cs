using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace DriverStation
{
    public partial class Form1 : Form
    {
        bool state = false;
        bool connect = false;
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

        public Form1()
        {
            InitializeComponent();
            Form1_Load();
            richTextBox1.AppendText("Client Started\r\n");
            button1.BackColor = Color.Green;
            button2.BackColor = Color.Red;
            richTextBox1.BackColor = Color.Red;
            
        }
        private void Form1_Load()
        {
            
            try
            {
                clientSocket.ConnectAsync("10.31.41.5", 3141);
            }
            catch (System.Net.Sockets.SocketException)
            {
                System.Net.Sockets.SocketException argEx = new System.Net.Sockets.SocketException();
                throw argEx;
            }
            if (clientSocket.Connected == true)
            {
                richTextBox1.AppendText("Client connected to robot\r\n");
                connect = true;
            }
        }
        // When clicked Robot will enable
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(state == false && connect == true){
                richTextBox1.AppendText("Robot was Enabled\r\n");
                
                state = true;
                richTextBox1.BackColor = Color.Green;
            }
            else if (connect == false)
            {
                richTextBox1.AppendText("Not Connected, Not switched. Still Disabled\r\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (state == true && connect == true)
            {
                richTextBox1.AppendText("Robot was Disabled\r\n");
                state = false;
                richTextBox1.BackColor = Color.Red;
            }
            else if (connect == false)
            {
                richTextBox1.AppendText("Not Connected Disabled\r\n");
            }
        }
    }
}
