using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExpanded.Config
{
    /// <summary>
    /// This is a set of all paths for config files.
    /// </summary>
    public static class ConfigPaths
    {
        //Prefixes
        public const string CLIENT = "survivalexpanded/client/";
        public const string SERVER = "survivalexpanded/server/";
     

        public const string ENABLED_MODULES = SERVER + "enabledmodules.json";

    }
}
