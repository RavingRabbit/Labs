using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Windows;

namespace Lab4.FileEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (SingleAppInstanceHelper.IsApplicationStarted())
            {
                Environment.Exit(0);
            }
            else
            {
                SingleAppInstanceHelper.OnStart();
            }
            base.OnStartup(e);
        }
        
        protected override void OnExit(ExitEventArgs e)
        {
            var editorInstance = Model.FileEditor.Instance;
            if (editorInstance != null)
            {
                editorInstance.CloseFile(false);
            }
            SingleAppInstanceHelper.OnExit();
            base.OnExit(e);
        }
    }
}
