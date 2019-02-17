using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Test.Commands;

namespace Test
{
    internal class MainWindowViewModel
    {
        #region Button
        public bool CanPressButton { get; set; } = true;

        public RelayCommand ShowMessageBoxCommand { get; set; }

        public void DoWhenButtonClicked()
        {
            MessageBox.Show("test", "test");
        }
        #endregion    

        public string MainWindowCaption { get; private set; } = "Penis";

        public bool PasswordVisible { get; set; } = true;

        public MainWindowViewModel()
        {
            ShowMessageBoxCommand = new RelayCommand(
                p => this.CanPressButton,
                p => this.DoWhenButtonClicked());
        }
    }
}
