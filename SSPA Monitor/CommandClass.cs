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
        public String Example = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_CommandName"></param>
        /// <param name="i_CommandHelp"></param>
        public CommandClass(String i_CommandName, String i_CommandHelp)
        {
            Command_name = i_CommandName;
            Help = i_CommandHelp;
        }
    }
}
