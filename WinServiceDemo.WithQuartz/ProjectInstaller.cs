using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace WinServiceDemo.WithQuartz
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void DemoServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            new ServiceController(DemoServiceInstaller.ServiceName).Start();
        }
    }
}
