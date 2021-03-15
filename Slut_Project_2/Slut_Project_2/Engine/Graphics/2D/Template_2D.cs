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

        private Texture2D _texture;
        private Vector2 _origin;

        private float _movementSpeed;
        private float _rotationSpeed;
        #endregion

#region Properties
        public override Vector2 Position { get; set; }
        public float Rotation { get; set; }
        #endregion

#region Methods

        public Template_2D(Texture2D texture, Vector2? origin)
        {
            _texture = texture;

            if (origin == null) { _origin = Vector2.Zero; }
            else { _origin = (Vector2)origin; }
        }

        public override void Update(GameTime gameTime)
        {

        }
        
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }
        #endregion
    }
}
