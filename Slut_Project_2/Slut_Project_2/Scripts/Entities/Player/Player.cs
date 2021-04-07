using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Slut_Project_2.Scripts.Entities.Player.Weapons.Projectiles;
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
        private Bullet _bullet;

        public Player(Texture2D texture, Vector2? origin) : base(texture, origin)
        {
            // Sets the player texture origin.
            _origin = new Vector2(texture.Width / 2, texture.Height / 2);

            // Temporary position for testing.
            Position = new Vector2(Globals.ScreenWidth / 2, Globals.ScreenHeight / 2);

            _movementSpeed = 5f;
            _width = 100;
            _height = 100;

            _bullet = new Bullet(Globals.G_Manager._textures["Bullet"], new Vector2(Globals.G_Manager._textures["Bullet"].Width/2, Globals.G_Manager._textures["Bullet"].Height/2));
        }




        public override void Update(GameTime gameTime)
        {
            // Rotates the player towards the mouse.
            Rotation = Globals.G_RotateTowards(Position, Globals.G_Mouse.MousePosition);
            _direction = Vector2.Subtract(Globals.G_Mouse.MousePosition, Position);
            _direction.Normalize();

            MovementFree();

            if (Globals.G_Keyboard.SpaceOn)
            {
                var temp = _bullet.Clone() as Bullet;
                temp.Position = this.Position;
                temp.Rotation = this.Rotation;
                temp._direction = this._direction;

                Globals.G_Manager.AddObject(temp);
            }




            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            base.Draw(spriteBatch, gameTime);
        }



        // Up and down move towards and aways from mouse.
        private void MovementToMouse()
        {
            if (Globals.G_Keyboard.Up)
                Position += _direction * _movementSpeed;
            
            if (Globals.G_Keyboard.Down)
                Position -= _direction * _movementSpeed;

            if (Globals.G_Keyboard.Right)
                Position += _movementX * _movementSpeed;

            if (Globals.G_Keyboard.Left)
                Position -= _movementX * _movementSpeed;
        }
        // Moves with no considiration to mouse position.
        private void MovementFree()
        {
            if (Globals.G_Keyboard.Up)
                Position -= _movementY * _movementSpeed;

            if (Globals.G_Keyboard.Down)
                Position += _movementY * _movementSpeed;

            if (Globals.G_Keyboard.Right)
                Position += _movementX * _movementSpeed;

            if (Globals.G_Keyboard.Left)
                Position -= _movementX * _movementSpeed;
        }
    }
}
