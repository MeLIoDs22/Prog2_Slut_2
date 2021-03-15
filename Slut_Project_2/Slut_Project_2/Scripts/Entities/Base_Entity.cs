using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Slut_Project_2.Engine.Graphics._2D;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slut_Project_2.Scripts.Entities
{
    /// <summary>
    /// Base class for all game entities.
    /// </summary>
    class Base_Entity : Template_2D
    {

#region Fields

        protected float _movementSpeed;
        #endregion


#region Methods

        public Base_Entity(Texture2D texture, Vector2? origin) : base(texture, origin)
        {

        }
        #endregion
    }
}
