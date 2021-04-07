using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Slut_Project_2.Scripts.Entities;
using Slut_Project_2.Scripts.Entities.Player;
using Slut_Project_2.Scripts.Entities.Player.Weapons.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slut_Project_2.Scripts
{
    /// <summary>
    /// Manages all objects in the game.
    /// </summary>
  public class WorldManager
    {

#region Fields
        // "_objects" Stores all game objects. "_textures" Stores all game textures.
        private List<Base_Entity> _objects;
        public Dictionary<string, Texture2D> _textures { get; private set; }


        // Stores the player object.
        private Player _player;
        #endregion



        #region Methods
        public WorldManager()
        {
            _textures = new Dictionary<string, Texture2D>();
            _objects = new List<Base_Entity>();
        }




        public void Update(GameTime gameTime)
        {
            if(_objects.Any())
                foreach(var i in _objects.ToArray())
                {
                    if(i.ShouldRemove)
                    {
                        _objects.Remove(i);
                    }
                    else
                    {
                        i.Update(gameTime);
                    }
                }

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if(_objects.Any())
                foreach(var i in _objects.ToArray())
                {
                    i.Draw(spriteBatch, gameTime);
                }

        }




        /// <summary>
        /// Adds a game texture.
        /// </summary>
        /// <param name="name">The reference key value for the texture.</param>
        /// <param name="texture"></param>
        public void AddTexture(string name, Texture2D texture)
        {
            if (texture != null && !string.IsNullOrEmpty(name))
            {
                if (_textures.ContainsKey(name))
                    throw new Exception("Texture name already exists.");
                else
                    _textures.Add(name, texture);
            }
        }
        public void AddObject(Base_Entity _object)
        {
            if (_object is null)
            {
                return;
            }
            else
            {
                if(!_objects.Contains(_object))
                    _objects.Add(_object);
            }

        }

        // Spawns the player at the start of the game.
        public void Start()
        {
            _player = new Player(_textures["Player"], null);

            _objects.Add(_player);
        }
        #endregion
    }
}
