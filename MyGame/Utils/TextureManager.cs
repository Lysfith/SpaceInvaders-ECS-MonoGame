using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Utils
{
    public class TextureManager
    {

        private Texture2D _spriteSheet;
        private int _spriteSizeWidth;
        private int _spriteSizeHeight;
        private int _nbSpriteX;
        private int _nbSpriteY;

        public TextureManager(Texture2D spriteSheet, int spriteSizeWidth, int spriteSizeHeight)
        {
            _spriteSheet = spriteSheet;
            _spriteSizeWidth = spriteSizeWidth;
            _spriteSizeHeight = spriteSizeHeight;

            _nbSpriteX = _spriteSheet.Width / _spriteSizeWidth;
            _nbSpriteY = _spriteSheet.Height / _spriteSizeHeight;
        }

        public Rectangle GetRegionByIndex(int index)
        {
            return new Rectangle((index % _nbSpriteX) * _spriteSizeWidth, (index / _nbSpriteY) * _spriteSizeHeight, _spriteSizeWidth, _spriteSizeHeight);
        }

        public Texture2D GetTexture()
        {
            return _spriteSheet;
        }
    }
}
