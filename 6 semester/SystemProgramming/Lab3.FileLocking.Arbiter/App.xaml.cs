using System;
using System.Windows;

namespace Lab3.FileLocking.Arbiter
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static FileAccessArbiter Arbiter;

        public App()
        {
            if (SingleArbiterAppHelper.IsApplicationStarted())
            {
                Environment.Exit(0);
            }
            Arbiter = new FileAccessArbiter();
            SingleArbiterAppHelper.OnStart();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (Arbiter != null)
            {
                Arbiter.Dispose();
            }
            SingleArbiterAppHelper.OnExit();
            base.OnExit(e);
        }
    }
}