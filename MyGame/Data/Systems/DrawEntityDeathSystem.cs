using Library.EntityComponentSystem.Components;
using Library.EntityComponentSystem.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Data.Components;
using MyGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Data.Systems
{
    public class DrawEntityDeathSystem : DrawSystem
    {
        public override void Draw(IList<Entity> entities, double elapsedTime, SpriteBatch spriteBatch)
        {
            //Sprites
            var sprites = entities.Where(x => x.ToRemove && (x.HasComponent(1) || x.HasComponent(2)));

            foreach (var s in sprites)
            {
                var transformComponent = (TransformComponent)s.GetComponent(0);
                var scoreComponent = (ScoreComponent)s.GetComponent(9);

                var font = FontManager.Instance.GetFont(FontEnum.ARIAL_10);
                var measuringString = font.MeasureString(scoreComponent.Score.ToString());

                spriteBatch.DrawString(font,
                   scoreComponent.Score.ToString(),
                   new Vector2(transformComponent.X - measuringString.X *0.5f, transformComponent.Y - measuringString.Y * 0.5f),
                   Color.White
                   );
            }
        }
    }
}
