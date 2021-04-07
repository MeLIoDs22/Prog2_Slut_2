using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slut_Project_2.Scripts.Entities.Player.Weapons.Projectiles
{
    class Base_Projectile : Base_Entity
    {
        protected float _lifeSpan;
        protected float _timeAlive;
        public Base_Projectile(Texture2D texture, Vector2? origin) : base(texture, origin)
        {
        }

        public override void Update(GameTime gameTime)
        {
            _timeAlive += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timeAlive > _lifeSpan)
                ShouldRemove = true;

            base.Update(gameTime);
        }
    }
}
