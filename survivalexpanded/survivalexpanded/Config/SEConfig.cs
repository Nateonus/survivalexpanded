using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;

namespace SurvivalExpanded.Config
{
    /// <summary>
    /// All configs extend from this. A rather simple way of ensuring we're not using server-side configs on the client, and vice-versa.
    /// </summary>
    public abstract class SEConfig
    {
        /// <summary>
        /// Return true if the config can be loaded on this side.
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        public abstract bool EnsureSide(EnumAppSide side);
    }
}
