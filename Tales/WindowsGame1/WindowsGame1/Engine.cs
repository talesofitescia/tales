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
            InputSystem inputSystem = new InputSystem();

            // Faire attention à l'ordre !!!!!!!!!!!!!
            systems.Add(inputSystem);
            //systems.Add(renderSystem);

            //Création pikachu !!!!!!
            Entity pikachu = new Entity();
            PositionComponent position = new PositionComponent(0, 0, 25, 27);
            pikachu.add(position);
            DisplayComponent display = new DisplayComponent();
            display.texture = Content.Load<Texture2D>("pikachu");
            pikachu.add(display);
            //Création Nodes en rapport à pikachu !!!!!
            RenderNode renderNode = new RenderNode();
            renderNode.position = position;
            renderNode.display = display;
            List<Node> list = new List<Node>() { renderNode };
            nodesLists[renderNode.GetType()] = (List<Node>) list;

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
