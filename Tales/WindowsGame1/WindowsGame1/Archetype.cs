using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    class Archetype
    {
        ContentManager Content;
        public Archetype(ContentManager Content)
        {
            this.Content = Content;
        }
        public Entity createPikachu(int x, int y)
        {
            Entity pikachu = new Entity();
            ProcessSystemComponent processSystem = new ProcessSystemComponent();
            processSystem.ProcessSystemSet.Add(new RenderNode().GetType());
            processSystem.ProcessSystemSet.Add(new InputNode().GetType());
            processSystem.ProcessSystemSet.Add(new AnimationNode().GetType());
            processSystem.ProcessSystemSet.Add(new CollisionNode().GetType());
            processSystem.ProcessSystemSet.Add(new MoveNode().GetType());
            pikachu.add(processSystem);


            PositionComponent position = new PositionComponent(x, y, 25, 27);
            pikachu.add(position);
            DisplayComponent display = new DisplayComponent();
            display.Texture = Content.Load<Texture2D>("pikachu");
            display.Effect = SpriteEffects.None;
            pikachu.add(display);
            VelocityComponent velocity = new VelocityComponent();
            velocity.velocityX = 2;
            velocity.velocityY = 2;
            pikachu.add(velocity);
            CollisionComponent collision = new CollisionComponent();
            pikachu.add(collision);

            

            return pikachu;
        }

        public Entity createMonster(int x, int y)
        {
            Entity monster = new Entity();
            ProcessSystemComponent processSystem = new ProcessSystemComponent();
            processSystem.ProcessSystemSet.Add(new RenderNode().GetType());
            processSystem.ProcessSystemSet.Add(new PatrolNode().GetType());
            processSystem.ProcessSystemSet.Add(new AnimationNode().GetType());
            processSystem.ProcessSystemSet.Add(new CollisionNode().GetType());
            processSystem.ProcessSystemSet.Add(new MoveNode().GetType());
            monster.add(processSystem);
            
            PositionComponent position = new PositionComponent(x, y, 25, 27);
            monster.add(position);
            DisplayComponent display = new DisplayComponent();
            display.Texture = Content.Load<Texture2D>("mechant_test");
            display.Effect = SpriteEffects.None;
            monster.add(display);
            VelocityComponent velocity = new VelocityComponent();
            velocity.velocityX = 1;
            velocity.velocityY = 1;
            monster.add(velocity);
            CollisionComponent collision = new CollisionComponent();
            collision.Position = new Rectangle(100, 200, 25, 27);
            monster.add(collision);
            PatrolComponent patrol = new PatrolComponent();
            patrol.MaxOffset = 40;
            monster.add(patrol);
            RangeOfViewComponent range = new RangeOfViewComponent();
            range.Range = 50;
            monster.add(range);


            

            return monster;
        }
    }
}
