using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    internal class CommandClass
    {
        public String Command_name = "";
        public String Help = "";

        public CommandClass(String i_CommandName, String i_Help)
        {
            Command_name = i_CommandName;
            Help = i_Help;
        }
    }
}
