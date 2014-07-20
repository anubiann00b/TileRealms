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
    class HUDController
    {
        List<HUD> HUDSystem;

        public HUDController(Viewport viewport)
        {
            HUDSystem= new List<HUD>();
            HUDSystem.Add(new HUD(new Vector2(0, viewport.Height - 150), new Sprite(new TextureLibrary[] { TextureLibrary.PlayerHUD }, 0, new Vector2(1920, 1080), 0)));
        }

        public void Draw(SpriteBatch spriteBatch, double time, Vector2 camera)
        {
            for (int i = 0; i < HUDSystem.Count; i++)
            {
                HUDSystem.ElementAt(i).Update(camera);
                HUDSystem.ElementAt(i).Draw(spriteBatch, time);
            }
        }
    }
}
