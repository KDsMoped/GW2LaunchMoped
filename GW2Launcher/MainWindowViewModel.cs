using System;
using System.Diagnostics;
using System.Windows;


using GW2Launcher.Commands;

namespace GW2Launcher
{
    internal class MainWindowViewModel
    {
        private string gw2BinPath = "D:\\Games\\ArenaNet\\Guild Wars 2\\bin64";

        public bool CanPressButton { get; set; } = true;

        public RelayCommand LaunchMainAccountCommand { get; set; }
        public RelayCommand LaunchAltAccount1Command { get; set; }
        public RelayCommand LaunchAltAccount2Command { get; set; }
        public RelayCommand UpdateArcDpsCommand { get; set; }

        public void launchAccount(int account)
        {
            int ExitCode;
            ProcessStartInfo ProcessInfo;
            Process Process;

            String baseDir = AppDomain.CurrentDomain.BaseDirectory;
            //string path = baseDir + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + "Scripts" + Path.DirectorySeparatorChar + "runDeineMudda.bat"

            String path = baseDir + "run_account.bat account" + account;

            ProcessInfo = new ProcessStartInfo("cmd.exe", path);
            ProcessInfo.CreateNoWindow = false;
            ProcessInfo.UseShellExecute = false;
            // *** Redirect the output ***
            ProcessInfo.RedirectStandardError = true;
            ProcessInfo.RedirectStandardOutput = true;

            Process = Process.Start(ProcessInfo);
            Process.WaitForExit();

            ExitCode = Process.ExitCode;
            Process.Close();

            MessageBox.Show("ExitCode: " + ExitCode.ToString(), "ExecuteCommand");
        }

        public MainWindowViewModel()
        {
            LaunchMainAccountCommand = new RelayCommand(
                p => this.CanPressButton,
                p => this.launchAccount(0));

            LaunchAltAccount1Command = new RelayCommand(
                p => this.CanPressButton,
                p => this.launchAccount(1));

            LaunchAltAccount2Command = new RelayCommand(
                p => this.CanPressButton,
                p => this.launchAccount(2));

            UpdateArcDpsCommand = new RelayCommand(
                p => this.CanPressButton,
                p => new ArcDpsUpdater(gw2BinPath).Download());
        }
    }
}
