using Library.EntityComponentSystem.Components;
using Library.EntityComponentSystem.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Data.Systems
{
    public class DrawEntitySystem : DrawSystem
    {
        public override void Draw(IList<Entity> entities, double elapsedTime, SpriteBatch spriteBatch)
        {
            //Sprites
            var sprites = entities.Where(x => !x.ToRemove && (x.HasComponent(1) || x.HasComponent(2)));

            foreach (var s in sprites)
            {
                SpriteComponent spriteComponent = (SpriteComponent)s.GetComponent(1);
                var transformComponent = (TransformComponent)s.GetComponent(0);

                if(s.HasComponent(2))
                {
                    var spriteAnimationComponent = (SpriteAnimationComponent)s.GetComponent(2);

                    spriteAnimationComponent.LastFrameChanged += elapsedTime;
                    if (spriteAnimationComponent.LastFrameChanged > spriteAnimationComponent.IntervalFrameChanged * 1000)
                    {
                        spriteComponent.CurrentIndex++;

                        if (spriteComponent.CurrentIndex > spriteAnimationComponent.IndexEnd)
                        {
                            spriteComponent.CurrentIndex = spriteAnimationComponent.IndexStart;
                        }

                        spriteAnimationComponent.LastFrameChanged = 0;
                    }
                }
                

                var region = MyGame.Instance.TextureManager.GetRegionByIndex(spriteComponent.CurrentIndex);
                spriteBatch.Draw(MyGame.Instance.TextureManager.GetTexture(),
                   new Rectangle(
                       (int)(transformComponent.X),
                       (int)(transformComponent.Y),
                       (int)(region.Width * spriteComponent.ScaleX),
                       (int)(region.Height * spriteComponent.ScaleY)
                       ),
                   new Rectangle(
                       region.X,
                       region.Y,
                       region.Width,
                       region.Height
                       ),
                   spriteComponent.Color,
                   transformComponent.Rotation,
                   new Vector2(
                       region.Width * spriteComponent.OriginX,
                       region.Height * spriteComponent.OriginY),
                   spriteComponent.Effect,
                   0);
            }
        }
    }
}
