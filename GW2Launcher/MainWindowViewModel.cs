using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.Reflection;
using System.IO;
using GW2Launcher.Commands;

namespace GW2Launcher
{
    internal class MainWindowViewModel
    {
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

        public void updateArcDps(int account)
        {
            int ExitCode;
            ProcessStartInfo ProcessInfo;
            Process Process;

            String baseDir = AppDomain.CurrentDomain.BaseDirectory;
            //string path = baseDir + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + "Scripts" + Path.DirectorySeparatorChar + "runDeineMudda.bat"

            ProcessInfo = new ProcessStartInfo("cmd.exe", baseDir + "update_arcdps");
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;

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
                p => this.updateArcDps(2));
        }
    }
}
