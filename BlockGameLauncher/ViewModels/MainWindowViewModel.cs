using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGameLauncher.ViewModels
{
    public class MainWindowViewModel
    {

        private bool _showLoginElements;

        public MainWindowViewModel()
        {
            _showLoginElements = true;
        }

        public bool ShowLoginElements()
        {
            return _showLoginElements;
        }

    }
}
