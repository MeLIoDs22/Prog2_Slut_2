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
        private Weapon_Mode _weaponMode;


        // The weapon modes buffers.
        private float _singleAndSemiBuffer = 0.18F;
        private float _autoBffer = 0.1F;
        private float _semiBulletsColdown = 0.05f;

        // Variables needed for the diffrent weapon modes.
        private float _buffer;
        private float _bufferLength;
        private bool _bufferState;


        private int _semiBulletsCap = 3;
        private int _currentSemiShots = 0;
        // True for the duration of the semi-shot.(Until all the shoots have been shoot, which are 3 by default.)
        private bool _semiShotState;


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

            _weaponMode = new Weapon_Mode();
        }




        public override void Update(GameTime gameTime)
        {
            // Rotates the player towards the mouse.
            Rotation = Globals.G_RotateTowards(Position, Globals.G_Mouse.MousePosition);
            _direction = Vector2.Subtract(Globals.G_Mouse.MousePosition, Position);
            _direction.Normalize();

            MovementFree();
            Shooting(gameTime);
            ChangeWeaponMode();


            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            base.Draw(spriteBatch, gameTime);
        }



        // Up and down move the player towards and away from mouse.
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
        // Moves with no consideration to mouse position.
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



        // Shooting methods
        private void ShootBullet()
        {
            var temp = _bullet.Clone() as Bullet;
            temp.Position = this.Position;
            temp.Rotation = this.Rotation;
            temp._direction = this._direction;

            Globals.G_Manager.AddObject(temp);
        }
        private void Shooting(GameTime gameTime)
        {
            // Resets buffer when desired timeout is reached.
            if(_buffer >= _bufferLength || _buffer >= _semiBulletsColdown && _semiShotState==true)
            {
                _buffer = 0;
                _bufferState = false;
            }

            // Shooting code.
            switch (_weaponMode)
            {
                case Weapon_Mode.Single:
                    _bufferLength = _singleAndSemiBuffer;
                    if (Globals.G_Keyboard.SpaceOne)
                    {
                        if (_buffer == 0)
                        {
                            ShootBullet();
                            _bufferState = true;
                        }
                    }
                    break;
                    // This one was annoying to write. xd
                case Weapon_Mode.Semi_Auto:
                    _bufferLength = _singleAndSemiBuffer;
                    if (Globals.G_Keyboard.SpaceOne && _currentSemiShots == 0 && _bufferState==false)
                    {
                        _semiShotState = true;
                        _bufferState = true;
                    }

                    if (_semiShotState)
                    {
                        if (_buffer == 0)
                        {
                            ShootBullet();
                            _currentSemiShots++;
                            _bufferState = true;
                        }

                        if (_currentSemiShots == _semiBulletsCap)
                        {
                            _semiShotState = false;
                            _currentSemiShots = 0;
                        }
                    }
                    break;
                case Weapon_Mode.Auto:
                    _bufferLength = _autoBffer;
                    if (Globals.G_Keyboard.SpaceOn)
                    {
                        if (_buffer == 0)
                        {
                            ShootBullet();
                            _bufferState = true;
                        }
                    }
                    break;
            }

            // Incriments the buffer if it's being used.
            if(_bufferState)
                _buffer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        }
        private void ChangeWeaponMode()
        {
            if (Globals.G_Keyboard.C)
            {
                switch (_weaponMode)
                {
                    case Weapon_Mode.Single:
                        _weaponMode = Weapon_Mode.Semi_Auto;
                        break;
                    case Weapon_Mode.Semi_Auto:
                        _weaponMode = Weapon_Mode.Auto;
                        break;
                    case Weapon_Mode.Auto:
                        _weaponMode = Weapon_Mode.Single;
                        break;
                }
            }
        }
    }
}
