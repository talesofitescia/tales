using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class Engine
    {
        List<Entity> entities;
        SystemList systems;
        Dictionary<System.Type, List<Node>> nodesLists;
        RenderSystem renderSystem;

        ContentManager Content;
        public Engine(ContentManager Content)
        {
            //Test sequence !!!!!!!!!!
            this.Content = Content;

            entities = new List<Entity>();
            systems = new SystemList();
            nodesLists = new Dictionary<Type, List<Node>>();

            renderSystem = new RenderSystem(this);
            InputSystem inputSystem = new InputSystem(this);
            CollisionSystem collisionSystem = new CollisionSystem(this);
            MoveSystem moveSystem = new MoveSystem(this);
            AnimationSystem animationSystem = new AnimationSystem(this);

            // Faire attention à l'ordre !!!!!!!!!!!!!
            systems.Add(inputSystem);
            systems.Add(collisionSystem);
            systems.Add(moveSystem);
            systems.Add(animationSystem);
            //systems.Add(renderSystem);

            //Création pikachu !!!!!!
            Entity pikachu = new Entity();
            PositionComponent position = new PositionComponent(0, 0, 25, 27);
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
            //Création Nodes en rapport à pikachu !!!!!
            RenderNode renderNode = new RenderNode();
            renderNode.position = position;
            renderNode.display = display;
            List<Node> list = new List<Node>() { renderNode };
            nodesLists[renderNode.GetType()] = list;

            InputNode inputNode = new InputNode();
            inputNode.Position = position;
            inputNode.Collision = collision;
            inputNode.Velocity = velocity;
            inputNode.Display = display;
            list = new List<Node>() { inputNode };
            nodesLists[inputNode.GetType()] = list;

            AnimationNode animationNode = new AnimationNode();
            animationNode.display = display;
            animationNode.position = position;
            list = new List<Node>() { animationNode };
            nodesLists[animationNode.GetType()] = list;

            CollisionNode collisionNode = new CollisionNode();
            collisionNode.Collision = collision;
            list = new List<Node>() { collisionNode };
            nodesLists[collisionNode.GetType()] = list;

            MoveNode moveNode = new MoveNode();
            moveNode.Position = position;
            moveNode.Collision = collision;
            moveNode.Display = display;
            list = new List<Node>() { moveNode };
            nodesLists[moveNode.GetType()] = list;
            

            //Création temp méchant !!!!
            Entity monster = new Entity();
            position = new PositionComponent(100, 200, 25, 27);
            monster.add(position);
            display = new DisplayComponent();
            display.Texture = Content.Load<Texture2D>("mechant_test");
            display.Effect = SpriteEffects.None;
            monster.add(display);
            velocity = new VelocityComponent();
            velocity.velocityX = 2;
            velocity.velocityY = 2;
            monster.add(velocity);
            collision = new CollisionComponent();
            collision.Position = new Rectangle(100, 200, 25, 27);
            monster.add(collision);
            //Création Nodes en rapport au méchant !!!!!
            renderNode = new RenderNode();
            renderNode.position = position;
            renderNode.display = display;
            nodesLists[renderNode.GetType()].Add(renderNode);
            

            /*InputNode inputNode2 = new InputNode();
            inputNode2.position = position2;
            inputNode2.velocity = velocity2;
            inputNode2.display = display2;
            inputNodeList.Add(inputNode2);*/

            animationNode = new AnimationNode();
            animationNode.display = display;
            animationNode.position = position;
            nodesLists[animationNode.GetType()].Add(animationNode);

            collisionNode = new CollisionNode();
            collisionNode.Collision = collision;
            nodesLists[collisionNode.GetType()].Add(collisionNode);

            

            //Création temp méchant 2 !!!!
            monster = new Entity();
            position = new PositionComponent(200, 200, 25, 27);
            monster.add(position);
            display = new DisplayComponent();
            display.Texture = Content.Load<Texture2D>("mechant_test");
            display.Effect = SpriteEffects.None;
            monster.add(display);
            velocity = new VelocityComponent();
            velocity.velocityX = 2;
            velocity.velocityY = 2;
            monster.add(velocity);
            collision = new CollisionComponent();
            collision.Position = new Rectangle(200, 200, 25, 27);
            monster.add(collision);
            //Création Nodes en rapport au méchant !!!!!
            renderNode = new RenderNode();
            renderNode.position = position;
            renderNode.display = display;
            nodesLists[renderNode.GetType()].Add(renderNode);

            animationNode = new AnimationNode();
            animationNode.display = display;
            animationNode.position = position;
            nodesLists[animationNode.GetType()].Add(animationNode);

            collisionNode = new CollisionNode();
            collisionNode.Collision = collision;
            nodesLists[collisionNode.GetType()].Add(collisionNode);
        }

        public void addEntity(Entity e)
        {
            entities.Add(e);
            foreach (Systems s in e.nodeCreatList)
            {

            }
        }

        public void removeEntity(Entity e)
        {
            entities.Remove(e);
        }

        public void addSystem(ISystem s, int priority)
        {
            systems.Add(s);

        }
        public void removeSystem(ISystem s)
        {
            systems.Remove(s);
        }
        public List<Node> getNodeList(Type nodeClass)
        {
            return nodesLists[nodeClass];
        }

        public void update(GameTime gameTime)
        {
            foreach (ISystem system in systems)
            {
                system.update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            renderSystem.update(spriteBatch);
        }
    }
}
