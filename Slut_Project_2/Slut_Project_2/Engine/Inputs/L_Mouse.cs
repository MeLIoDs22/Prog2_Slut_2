using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slut_Project_2.Engine.Inputs
{
    /// <summary>
    /// Processes mouse inputs.
    /// </summary>
    public class L_Mouse
    {
        public MouseState CurrentState, OldState;

        public L_Mouse()
        {
            CurrentState = new MouseState();
            OldState = new MouseState();
        }

        public void Update(GameTime gameTime)
        {
            OldState = CurrentState;
            CurrentState = Mouse.GetState();


        }
    }
}
