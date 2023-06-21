using System;

namespace TA.Desktop.Commands
{
    public class CloseApplicationCommand : Command
    {
        public override void Execute(object parameter)
        {
            Environment.Exit(0);
        }
    }
}
