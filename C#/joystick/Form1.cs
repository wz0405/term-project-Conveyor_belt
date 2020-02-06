using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Runtime.InteropServices;

namespace joystick
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        SerialPort port;
        byte[] readData;
        
        public Form1()
        {
            InitializeComponent(); 
            port = new SerialPort("COM15", 115200, Parity.None, 8, StopBits.One);
            backgroundWorker1.RunWorkerAsync();
            readData = new Byte[1];
            port.Open();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(10);
                port.Read(readData, 0, 1);
                if (readData[0] == 'c')
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                }
                else if (readData[0] == 'u')
                {
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - 1);
                }
                else if (readData[0] == 'd')
                {
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 1);
                }
                else if (readData[0] == 'l')
                {
                    Cursor.Position = new Point(Cursor.Position.X - 1, Cursor.Position.Y);
                }
                else if (readData[0] == 'r')
                {
                    Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y);
                }
                else { }            
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Click";
        }


    }
}
