using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms.Source.Graphics
{
    class TextureLibrary
    {
        static List<TextureLibrary> textures = new List<TextureLibrary>();

        static TextureLibrary PLAYER_DOWN = new TextureLibrary("player_down");

        static void LoadLibraryContent(ContentManager content)
        {
            PLAYER_DOWN.LoadContent(content);
            textures.Add(PLAYER_DOWN);
        }

        String path;
        Texture2D texture;

        private TextureLibrary(String res)
        {
            path = res;
        }

        void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(path);
        }
    }
}
