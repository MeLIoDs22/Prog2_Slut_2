using Microsoft.Xna.Framework;
using Slut_Project_2.Engine.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slut_Project_2.Scripts.World
{
    // Delegate used to rotate an object towards another object.
    public delegate float RotateToward(Vector2 pos, Vector2 focus);



    /// <summary>
    /// Static class to allow easy access to some objects, variables and methods.
    /// </summary>
    public static class Globals
    {
        public static WorldManager G_Manager;

        public static int ScreenWidth, ScreenHeight;

        public static L_Keyboard G_Keyboard { get; }
        public static L_Mouse G_Mouse { get; set; }

        public static RotateToward G_RotateTowards;




        static Globals()
        {
            G_Manager = new WorldManager();

            ScreenWidth = 1600;
            ScreenHeight = 800;

            G_Keyboard = new L_Keyboard();
            G_Mouse = new L_Mouse();

            G_RotateTowards = _RotateTowards;
        }




#region Delegate's Methods
        private static float _RotateTowards(Vector2 pos, Vector2 focus)
        {
            return (float)(Math.Atan2((pos.Y - focus.Y), (pos.X - focus.X)) - Math.PI / 2);
        }
        #endregion

    }
}
