using Slut_Project_2.Engine.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slut_Project_2.Scripts.World
{
    /// <summary>
    /// Static class to allow easy access to some objects, variables and methods.
    /// </summary>
    public static class Globals
    {
        public static L_Keyboard L_Keyboard { get; }
        public static L_Mouse L_Mouse { get; set; }

        static Globals()
        {
            L_Keyboard = new L_Keyboard();
            L_Mouse = new L_Mouse();
        }

    }
}
