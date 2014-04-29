﻿using Microsoft.Xna.Framework;
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
            Entity pikachu = entityFabric.createPikachu();
            hero = pikachu;
            addEntity(pikachu);

            //Création temp méchant !!!!
            Entity monster = entityFabric.createMonster(200, 200);
            addEntity(monster);

            monster = entityFabric.createMonster(100, 100);
            addEntity(monster);

            monster = entityFabric.createMonster(300, 300);
            addEntity(monster);
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
                if (entity.ProcessSystemSet.Contains(nodeClass))
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
}
