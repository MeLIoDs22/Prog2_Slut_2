using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Slut_Project_2.Scripts.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slut_Project_2.Scripts.Entities.Player
{
    /// <summary>
    /// PLayer class.
    /// </summary>
    class Player : Base_Entity
    {

        public Player(Texture2D texture, Vector2? origin) : base(texture, origin)
        {
            // Sets the player texture origin.
            _origin = new Vector2(texture.Width / 2, texture.Height / 2);

            // Temporary position for testing.
            Position = new Vector2(Globals.ScreenWidth / 2, Globals.ScreenHeight / 2);
        }




        public override void Update(GameTime gameTime)
        {
            // Rotates the player towards the mouse.
            Rotation = Globals.G_RotateTowards(Position, Globals.G_Mouse.MousePosition);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            base.Draw(spriteBatch, gameTime);
        }
    }
}
