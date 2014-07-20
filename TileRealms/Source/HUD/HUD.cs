using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Diagnostics.Tracing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Windows.Storage;

namespace TileRealms.Source.HUD
{
    class HUD
    {
        Sprite sprite;
        Vector2 location;
        Vector2 size;
        Vector2 camera;

        public HUD(Vector2 _location, Sprite _sprite)
        {
            location = _location;
            sprite = _sprite;
        }

        public void Update(Vector2 cam)
        {
            camera = cam;
        }

        public void Draw(SpriteBatch spriteBatch, double time)
        {
            sprite.Draw(spriteBatch, time, new Vector2(location.X + camera.X, location.Y + camera.Y));
        }
    }
}
