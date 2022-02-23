using hazedumper;
using swed32;
using System.Diagnostics;
using System.Threading;



namespace csgomemtemplate // If you post your version, please credit the video ;)
{
    public partial class Form1 : Form
    {
        swed swed = new swed();
        IntPtr client, engine;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            swed.GetProcess("csgo"); // init 
            client = swed.GetModuleBase("client.dll");
            engine = swed.GetModuleBase("engine.dll");

            var hp = swed.ReadPointer(client, signatures.dwLocalPlayer);
            var hpint = swed.ReadBytes(hp, netvars.m_iHealth,4);
            MessageBox.Show(BitConverter.ToInt32(hpint, 0).ToString());

        }
    }
}