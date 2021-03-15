using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slut_Project_2.Engine.Inputs
{
    /// <summary>
    /// Processes keyboard inputs.
    /// </summary>
    public class L_Keyboard
    {

        public KeyboardState CurrentState, OldState;

        public bool Up;
        public bool Down;
        public bool Left;
        public bool Right;




        public L_Keyboard()
        {
            CurrentState = new KeyboardState();
            OldState = new KeyboardState();
        }




        public void Update(GameTime gameTime)
        {
            OldState = CurrentState;
            CurrentState = Keyboard.GetState();

            Up_Down_Left_Right();
        }




        private void Up_Down_Left_Right()
        {
            if (CurrentState.IsKeyDown(Keys.W) || CurrentState.IsKeyDown(Keys.Up))
                Up = true;
            else Up = false;

            if (CurrentState.IsKeyDown(Keys.S) || CurrentState.IsKeyDown(Keys.Down))
                Down = true;
            else Down = false;

            if (CurrentState.IsKeyDown(Keys.A) || CurrentState.IsKeyDown(Keys.Left))
                Left = true;
            else Left = false;

            if (CurrentState.IsKeyDown(Keys.D) || CurrentState.IsKeyDown(Keys.Right))
                Right = true;
            else Right = false;
        }
    }
}
