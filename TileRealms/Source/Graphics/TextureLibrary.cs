using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    class TextureLibrary
    {
        public static TextureLibrary PLAYER_RIGHT = new TextureLibrary("player_right");
        public static TextureLibrary PLAYER_UP    = new TextureLibrary("player_up");
        public static TextureLibrary PLAYER_LEFT  = new TextureLibrary("player_left");
        public static TextureLibrary PLAYER_DOWN  = new TextureLibrary("player_down");
        
        public static TextureLibrary MUTANT_RIGHT = new TextureLibrary("mutant_right");
        public static TextureLibrary MUTANT_UP    = new TextureLibrary("mutant_up");
        public static TextureLibrary MUTANT_LEFT  = new TextureLibrary("mutant_left");
        public static TextureLibrary MUTANT_DOWN  = new TextureLibrary("mutant_down");

        public static TextureLibrary MAGIC_BALL_RED = new TextureLibrary("red");

        public static TextureLibrary HealthBar= new TextureLibrary(@"Health\Health_bar");
        public static TextureLibrary Health = new TextureLibrary(@"Health\Health");

        public static void LoadLibraryContent(ContentManager content)
        {
            PLAYER_RIGHT.LoadContent(content);
            PLAYER_UP.LoadContent(content);
            PLAYER_LEFT.LoadContent(content);
            PLAYER_DOWN.LoadContent(content);

            MUTANT_RIGHT.LoadContent(content);
            MUTANT_UP.LoadContent(content);
            MUTANT_LEFT.LoadContent(content);
            MUTANT_DOWN.LoadContent(content);

            MAGIC_BALL_RED.LoadContent(content);

            //HealthBar.LoadContent(content);
            //Health.LoadContent(content);
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

        public Texture2D GetTexture()
        {
            return texture;
        }
    }
}
