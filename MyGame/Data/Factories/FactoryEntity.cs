using Library.EntityComponentSystem.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Data.Components;
using MyGame.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Data.Factories
{
    public class FactoryEntity
    {
        public static void CreatePlayer(Entity entity)
        {
            entity.AddComponent(0, new TransformComponent()
            {
                X = (int)(MyGame.Instance.ScreenWidth * 0.5),
                Y = (int)(MyGame.Instance.ScreenHeight - 50),
                Rotation = 0
            });

            entity.AddComponent(1, new SpriteComponent()
            {
                Color = Color.White,
                OriginX = 0.5f,
                OriginY = 0.5f,
                ScaleX = 2.0f,
                ScaleY = 2.0f,
                CurrentIndex = 0,
                Visible = true,
                Effect = SpriteEffects.None
            });

            entity.AddComponent(5, new TypeComponent()
            {
                Type = Enums.EnumTypeEntity.PLAYER
            });

            entity.AddComponent(6, new ShootComponent()
            {
                Index = 32,
                IntervalBetweenShoot = 0.5,
                LastShootTime = 0
            });

            entity.AddComponent(7, new HitBoxComponent()
            {
                Width = 32,
                Height = 32
            });

            entity.AddComponent(8, new LifeComponent()
            {
                LifeMax = 3,
                CurrentLife = 3
            });

            entity.AddComponent(9, new ScoreComponent()
            {
                Score = 0
            });

            entity.AddComponent(10, new InputComponent()
            {
                
            });
        }

        public static void CreateShoot(Entity entity, int x, int y, float directionX, float directionY, int index, EnumTypeEntity type)
        {
            entity.AddComponent(0, new TransformComponent()
            {
                X = x,
                Y = y,
                Rotation = 0
            });

            entity.AddComponent(1, new SpriteComponent()
            {
                Color = Color.White,
                OriginX = 0.5f,
                OriginY = 0.5f,
                ScaleX = 1.0f,
                ScaleY = 1.0f,
                CurrentIndex = index,
                Visible = true,
                Effect = SpriteEffects.None
            });

            entity.AddComponent(4, new MoveToComponent()
            {
                StartX = x,
                StartY = y,
                EndX = (int)(x + (MyGame.Instance.ScreenWidth * directionX)),
                EndY = (int)(y + (MyGame.Instance.ScreenHeight * directionY)),
                TimeMax = 10,
                Repeat = false
            });

            entity.AddComponent(5, new TypeComponent()
            {
                Type = type
            });
        }

        public static void CreateEnnemy1(Entity entity, int x, int y, Color color)
        {
            CreateEnnemy(entity, x, y, color, 64, 65);

            entity.AddComponent(4, new MoveToComponent()
            {
                StartX = x,
                StartY = y,
                EndX = 700 + x,
                EndY = y,
                TimeMax = 10,
                Repeat = false
            });

            entity.AddComponent(9, new ScoreComponent()
            {
                Score = 200
            });
        }

        public static void CreateEnnemy2(Entity entity, int x, int y, Color color)
        {
            CreateEnnemy(entity, x, y, color, 66, 67);

            entity.AddComponent(4, new MoveToComponent()
            {
                StartX = x,
                StartY = y,
                EndX = 700 + x,
                EndY = y,
                TimeMax = 10,
                Repeat = false
            });

            entity.AddComponent(9, new ScoreComponent()
            {
                Score = 100
            });
        }

        public static void CreateEnnemy3(Entity entity, int x, int y, Color color)
        {
            CreateEnnemy(entity, x, y, color, 68, 69);

            entity.AddComponent(4, new MoveToComponent()
            {
                StartX = x,
                StartY = y,
                EndX = 700 + x,
                EndY = y,
                TimeMax = 10,
                Repeat = false
            });

            entity.AddComponent(9, new ScoreComponent()
            {
                Score = 300
            });
        }

        public static void CreateEnnemy4(Entity entity, int x, int y, Color color)
        {
            CreateEnnemy(entity, x, y, color, 70, 70);

            entity.AddComponent(4, new MoveToComponent()
            {
                StartX = -32,
                StartY = 30,
                EndX = MyGame.Instance.ScreenWidth + 32,
                EndY = 30,
                TimeMax = 20,
                Repeat = true
            });

            entity.AddComponent(9, new ScoreComponent()
            {
                Score = 500
            });
        }

        public static void CreateEnnemy(Entity entity, int x, int y, Color color, int indexStart, int indexEnd)
        {
            entity.TimeBeforeRemove = 0.5;

            entity.AddComponent(0, new TransformComponent()
            {
                X = x,
                Y = y,
                Rotation = 0
            });

            entity.AddComponent(1, new SpriteComponent()
            {
                Color = color,
                OriginX = 0.5f,
                OriginY = 0.5f,
                ScaleX = 2.0f,
                ScaleY = 2.0f,
                CurrentIndex = indexStart,
                Visible = true,
                Effect = SpriteEffects.None
            });

            entity.AddComponent(5, new TypeComponent()
            {
                Type = Enums.EnumTypeEntity.ENEMY
            });

            entity.AddComponent(6, new ShootComponent()
            {
                Index = 33,
                IntervalBetweenShoot = 2,
                LastShootTime = 0
            });

            entity.AddComponent(7, new HitBoxComponent()
            {
                Width = 32,
                Height = 32
            });

            entity.AddComponent(8, new LifeComponent()
            {
                LifeMax = 2,
                CurrentLife = 1
            });

            if (indexStart != indexEnd)
            {
                entity.AddComponent(2, new SpriteAnimationComponent()
                {
                    IndexStart = indexStart,
                    IndexEnd = indexEnd,
                    IntervalFrameChanged = 0.5
                });
            }

            
        }
    }
}
