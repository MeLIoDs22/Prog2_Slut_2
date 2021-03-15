using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slut_Project_2.Engine.Graphics._2D
{
    /// <summary>
    /// A template for 2D sprites.
    /// </summary>
    class Template_2D : Base_Graphics
    {

#region Fields

        protected Texture2D _texture;
        protected Vector2 _origin;


        protected Rectangle _position_Size;
        #endregion



#region Properties

        public override Vector2 Position { get; set; }
        public float Rotation { get; set; }
        #endregion



#region Methods
        /// <summary>
        /// Creates a 2D sprite.
        /// </summary>
        /// <param name="texture">Texture for the sprite.</param>
        /// <param name="origin">Origin point for the texture.</param>
        public Template_2D(Texture2D texture, Vector2? origin)
        {
            // Checks if the texture is null.
            if (texture == null)
                throw new NullReferenceException("Texture cannot be null.");
            else
            _texture = texture;

            // Checks if an origin was given for the texture, if not sets the origin to (0,0).
            if (origin != null) { _origin = (Vector2)origin; }
            else { _origin = Vector2.Zero; }
        }

        public override void Update(GameTime gameTime)
        {
            // Updates the position info for the sprite.
            _position_Size = new Rectangle((int)Position.X, (int)Position.Y, 100, 100);

        }
        
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            // Draws the sprite.
            spriteBatch.Draw(_texture, _position_Size, null, Color.White, Rotation, _origin, SpriteEffects.None, 0);
        }
        #endregion
    }
}
