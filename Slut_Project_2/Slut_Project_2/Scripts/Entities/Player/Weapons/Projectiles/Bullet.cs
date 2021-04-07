using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slut_Project_2.Scripts.Entities.Player.Weapons.Projectiles
{
    class Bullet : Base_Projectile, ICloneable
    {
        public Bullet(Texture2D texture, Vector2? origin) : base(texture, origin)
        {
            _lifeSpan = 1f;
            _movementSpeed = 10f;

            _width = 10;
            _height = 10;
        }



        public override void Update(GameTime gameTime)
        {
            Position += _direction * _movementSpeed;

            base.Update(gameTime);
        }



        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
