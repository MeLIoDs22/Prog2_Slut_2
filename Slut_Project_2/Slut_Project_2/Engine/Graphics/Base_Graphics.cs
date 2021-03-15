using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slut_Project_2.Engine.Graphics
{
    /// <summary>
    /// Base class inherited by all graphical classes.
    /// </summary>
    abstract class Base_Graphics
    {
        public abstract Vector2 Position { get; set; }


        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
