using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Movement;
using System.Collections;
using Sprint5.Physics.Forces;
using Sprint5.Physics.Vectors;
using Sprint5.Entities.Mario;
using Sprint5.Entities.Enemies;

namespace Sprint5.Entities
{
    public abstract class MovingEntity : IMoving
    {
        public abstract Rectangle Bounds { get; set; }

        public abstract ICollision Collision { get; set; }

        public IMovement Movement { get; set; }

        public Vector2 Position { get; set; }

        public LVector2 Velocity { get; set; }

        public LVector2 Acceleration { get; set; }

        private IList forces = new ArrayList();

        protected MovingEntity(Vector2 position, LVector2 velocity, LVector2 acceleration)
        {
            Position = position;
            Velocity = velocity;
            Acceleration = acceleration;
        }
        
        public void ApplyForce(Force force)
        {
            forces.Add(force);
        }

        public void Update(GameTime gameTime)
        {
            // Check if entity is under map kill threshold
            if (Position.Y >= 12.5)
            {
                if (this is IPlayer)
                {
                    IPlayer player = (IPlayer)this;
                    player.CauseDamage();
                }
                else if (this is IEnemy)
                {
                    IEnemy enemy = (IEnemy)this;
                    if (enemy.IsAlive())
                    {
                        enemy.BeStomped();
                    }
                }
            }

            // Calculate the delta time
            float delta = gameTime.ElapsedGameTime.Milliseconds / 1000f;

            // Apply pending forces to acceleration
            foreach (Force force in forces)
            {
                Acceleration.Add(force.Calculate(this, delta));
            }
            forces.Clear();

            // Limit acceleration
            Acceleration.Limit();

            // Increase velocity by acceleration and set to 0
            Velocity.Add(Acceleration.Vector);
            Acceleration.Set(Vector2.Zero);

            // Limit new velocity
            Velocity.Limit();

            // Handle moving entity's position based on velocity
            Movement.MoveEntity(this, Velocity.X * delta, -Velocity.Y * delta);
        }

        public abstract void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
