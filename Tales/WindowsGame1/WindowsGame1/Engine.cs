using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WindowsGame1
{
    class Engine
    {
        List<Entity> entities;
        SystemList systems;
        Dictionary<System.Type, List<Node>> nodesLists;
        RenderSystem renderSystem;

        // Réfléchir à un système de distribution de la référence du héro joué à un instant T. Profite au moins à PatrolSystem
        Entity hero;

        ContentManager Content;
        public Engine(ContentManager Content)
        {
            //Test sequence !!!!!!!!!!
            this.Content = Content;

            entities = new List<Entity>();
            systems = new SystemList();
            nodesLists = new Dictionary<Type, List<Node>>();

            // Initialisation des systèmes
            renderSystem = new RenderSystem(this);
            InputSystem inputSystem = new InputSystem(this);
            PatrolSystem patrolSystem = new PatrolSystem(this);
            CollisionSystem collisionSystem = new CollisionSystem(this);
            MoveSystem moveSystem = new MoveSystem(this);
            AnimationSystem animationSystem = new AnimationSystem(this);

            // Faire attention à l'ordre !!!!!!!!!!!!!
            systems.Add(inputSystem);
            systems.Add(collisionSystem);
            systems.Add(patrolSystem);
            systems.Add(collisionSystem);
            systems.Add(moveSystem);
            systems.Add(animationSystem);
            //systems.Add(renderSystem);

            // Création des listes de noeuds de nodeLists
            nodesLists[new AnimationNode().GetType()] = new List<Node>();
            nodesLists[new CollisionNode().GetType()] = new List<Node>();
            nodesLists[new InputNode().GetType()] = new List<Node>();
            nodesLists[new MoveNode().GetType()] = new List<Node>();
            nodesLists[new PatrolNode().GetType()] = new List<Node>();


            // Trouver moyen de pouvoir avoir une classe Archetype rempli de methodes statiques !
            Archetype entityFabric = new Archetype(Content);
            
            //Création pikachu !!!!!!
            Entity pikachu = entityFabric.createPikachu(0, 0);
            hero = pikachu;
            addEntity(pikachu);


            //Création temp méchant !!!!
            Entity monster = entityFabric.createMonster(200, 200);
            addEntity(monster);

            monster = entityFabric.createMonster(100, 100);
            addEntity(monster);

            monster = entityFabric.createMonster(300, 300);
            addEntity(monster);


            monster = entityFabric.createMonster(400, 400);
            addEntity(monster);





           /* XmlDocument document = new XmlDocument();
            document.Load(@"D:\sprites\tileset\example.tmx");

            XmlNodeList nodes = document.GetElementsByTagName("tileset");
            List<TileSet> tileSets = new List<TileSet>();
            foreach (XmlNode node in nodes)
            {
                int firstGid = Convert.ToInt32(node.Attributes["firstgid"].InnerText);
                String name = node.Attributes["name"].InnerText;
                int tileWidth = Convert.ToInt32(node.Attributes["tilewidth"].InnerText);
                int tileHeight = Convert.ToInt32(node.Attributes["tileheight"].InnerText);

                XmlNode imgNode = node.FirstChild;
                String src = imgNode.Attributes["source"].InnerText;
                int imgWidth = Convert.ToInt32(imgNode.Attributes["width"].InnerText);
                int imgHeight = Convert.ToInt32(imgNode.Attributes["height"].InnerText);

                TileSet tileSet = new TileSet(firstGid, name, tileWidth, tileHeight, src, imgWidth, imgHeight);
                tileSets.Add(tileSet);
            }

            foreach (TileSet tileSet in tileSets)
            {
                Console.WriteLine(tileSet.TileHeight);
            }

        public class TileSet
        {
            public int FirstGid { get; set; }
            public int LastGid { get; set; }
            public String Name { get; set; }
            public int TileWidth { get; set; }
            public String Source { get; set; }
            public int TileHeight { get; set; }
            public int ImageWidth { get; set; }
            public int ImageHeight { get; set; }
            //public Texture2D texture { get; set; } 
            public int TileAmountWidth { get; set; }
 
            public TileSet(int FirstGid, String Name, int TileWidth, int TileHeight, String Source, int ImageWidth, int ImageHeight)
           {
              this.FirstGid = FirstGid;
              this.Name = Name;
              this.TileWidth = TileWidth;
              this.TileHeight = TileHeight;
              this.Source = Source;
              this.ImageWidth = ImageWidth;
              this.ImageHeight = ImageHeight;
              TileAmountWidth = (int) Math.Floor((double) (ImageWidth / TileWidth));
              LastGid = TileAmountWidth * (int) Math.Floor((double) (ImageHeight / TileHeight)) + FirstGid - 1;
           }*/
        }

        public void addEntity(Entity e)
        {
            entities.Add(e);
        }

        public void removeEntity(Entity e)
        {
            entities.Remove(e);
        }

        // Ne pas oublier de re réfléchir à un moyen propre de distribuer la réf du héro
        public Entity getHero()
        {
            return hero;
        }

        public void setHero(Entity hero)
        {
            this.hero = hero;
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
            List<Node> list = new List<Node>();
            foreach (Entity entity in entities)
            {
                ProcessSystemComponent processSystem;
                try
                {
                    processSystem = (ProcessSystemComponent) entity.get(new ProcessSystemComponent().GetType());
                }
                catch
                {
                    throw new NoProcessSystemInEntityException();
                }
                if (processSystem.ProcessSystemSet.Contains(nodeClass))
                {
                    if (nodeClass == new AnimationNode().GetType())
                    {
                        AnimationNode animationNode = new AnimationNode();
                        animationNode.display = (DisplayComponent) entity.get(new DisplayComponent().GetType());
                        animationNode.position = (PositionComponent) entity.get(new PositionComponent(0, 0, 0, 0).GetType());
                        list.Add(animationNode);
                    }
                    else if (nodeClass == new AttackNode().GetType())
                    {
                        
                    }
                    else if (nodeClass == new CollisionNode().GetType())
                    {
                        CollisionNode collisionNode = new CollisionNode();
                        collisionNode.Collision = (CollisionComponent) entity.get(new CollisionComponent().GetType());
                        list.Add(collisionNode);
                    }
                    else if (nodeClass == new InputNode().GetType())
                    {
                        InputNode inputNode = new InputNode();
                        inputNode.Position = (PositionComponent) entity.get(new PositionComponent(0, 0, 0, 0).GetType());
                        inputNode.Collision = (CollisionComponent) entity.get(new CollisionComponent().GetType());
                        inputNode.Velocity = (VelocityComponent) entity.get(new VelocityComponent().GetType());
                        list.Add(inputNode);
                    }
                    else if (nodeClass == new MoveNode().GetType())
                    {
                        MoveNode moveNode = new MoveNode();
                        moveNode.Position = (PositionComponent) entity.get(new PositionComponent(0, 0, 0, 0).GetType());
                        moveNode.Collision = (CollisionComponent) entity.get(new CollisionComponent().GetType());
                        moveNode.Display = (DisplayComponent) entity.get(new DisplayComponent().GetType());
                        list.Add(moveNode);
                    }
                    else if (nodeClass == new PatrolNode().GetType())
                    {
                        PatrolNode patrolNode = new PatrolNode();
                        patrolNode.Position = (PositionComponent) entity.get(new PositionComponent(0, 0, 0, 0).GetType());
                        patrolNode.Collision = (CollisionComponent) entity.get(new CollisionComponent().GetType());
                        patrolNode.Velocity = (VelocityComponent) entity.get(new VelocityComponent().GetType());
                        patrolNode.Patrol = (PatrolComponent) entity.get(new PatrolComponent().GetType());
                        patrolNode.Range = (RangeOfViewComponent) entity.get(new RangeOfViewComponent().GetType());
                        list.Add(patrolNode);
                    }
                    else if (nodeClass == new RenderNode().GetType())
                    {
                        RenderNode renderNode = new RenderNode();
                        renderNode.position = (PositionComponent)entity.get(new PositionComponent(0, 0, 0, 0).GetType());
                        renderNode.display = (DisplayComponent)entity.get(new DisplayComponent().GetType());
                        list.Add(renderNode);
                    }
                }
                nodesLists[nodeClass] = list;
            }
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


    class NoProcessSystemInEntityException : Exception
    {

    }
}
