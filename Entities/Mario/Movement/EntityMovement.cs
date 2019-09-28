using System;
using Microsoft.Xna.Framework;
using Sprint5.World;
using Sprint5.World.Blocks;
using Sprint5.Entities.Items;
using Sprint5.Entities.Enemies;
using Sprint5.Entities.Mario;

namespace Sprint5.Entities.Movement
{
    public class EntityMovement : IMovement
    {
        private Game1 game;

        public EntityMovement(Game1 game)
        {
            this.game = game;
        }

        public bool IsOnGround(IMoving entity)
        {
            // Get game tile map
            Level level = game.Map;

            // Make it easier to access entity variables
            Vector2 position = entity.Position;
            int hitbox_x = entity.Bounds.X;
            int hitbox_y = entity.Bounds.Y;
            int hitbox_w = entity.Bounds.Width;
            int hitbox_h = entity.Bounds.Height;
            
            // Calculate the tile area currently covered by the entity
            int covered_xmin = (int)(position.X + hitbox_x);
            int covered_xmax = (int)Math.Ceiling(position.X + hitbox_x + hitbox_w) - 1;
            int covered_ymax = (int)Math.Ceiling(position.Y + hitbox_y + hitbox_h) - 1;
            int ground_y = covered_ymax + 1;

            // Entity is not at the exact top of a tile space
            if (covered_ymax != (position.Y + hitbox_y + hitbox_h - 1))
            {
                return false;
            }
            
            // Check if a block exists in the tile directly underneath the entity
            return level.ContainsBlock(covered_xmin, covered_xmax, ground_y, ground_y);
        }

        public void MoveEntity(IMoving entity, float x, float y)
        {
            // Don't waste our time if the entity isn't actually moving
            if (x == 0 && y == 0)
            {
                return;
            }

            // Get game tile map
            Level level = game.Map;

            // Make it easier to access entity bounds
            Vector2 position = entity.Position;
            int hitbox_x = entity.Bounds.X;
            int hitbox_y = entity.Bounds.Y;
            int hitbox_w = entity.Bounds.Width;
            int hitbox_h = entity.Bounds.Height;

            // Calculate the tile area currently covered by the entity
            int covered_xmin = (int)(position.X + hitbox_x);
            int covered_xmax = (int)Math.Ceiling(position.X + hitbox_x + hitbox_w) - 1;
            int covered_ymin = (int)(position.Y + hitbox_y);
            int covered_ymax = (int)Math.Ceiling(position.Y + hitbox_y + hitbox_h) - 1;

            // Handle x movement
            if (x > 0)
            {
                // Get the farthest tile we want to move to
                int move_x = (int)Math.Ceiling(position.X + hitbox_x + hitbox_w + x) - 1;

                // Step block by block to move as far as possible
                for (int tile_x = covered_xmax; tile_x <= move_x; tile_x++)
                {
                    if (level.ContainsBlock(tile_x, tile_x, covered_ymin, covered_ymax))
                    {
                        // We reached a collision, stop moving and handle collision
                        HandleBlockCollision(entity, Side.LEFT, tile_x, tile_x, covered_ymin, covered_ymax);
                        break;
                    }
                    else
                    {
                        // No block collision, step as far as the next tile
                        float step = MathHelper.Min(x, tile_x + 1 - position.X - hitbox_x - hitbox_w);
                        position.X += step;
                        if (entity is Mario.Mario || entity is MarioStar)
                        {
                            float cameraStep = step * 30f;
                            Game1.Camera.PanCamera(cameraStep, game);
                        }
                        x -= step;

                        // Handle possible entity collisions
                        HandleEntityCollisions(entity, Side.LEFT, position.X, position.X + hitbox_x + hitbox_w, position.Y, position.Y + hitbox_y + hitbox_h);
                    }
                }
            }
            else if (x < 0)
            {
                // Get the farthest tile we want to move to
                int move_x = (int)(entity.Position.X + hitbox_x + x);

                // Step block by block to move as far as possible
                for (int tile_x = covered_xmin; tile_x >= move_x; tile_x--)
                {
                    if (level.ContainsBlock(tile_x, tile_x, covered_ymin, covered_ymax))
                    {
                        // We reached a collision, stop moving and handle collision
                        HandleBlockCollision(entity, Side.RIGHT, tile_x, tile_x, covered_ymin, covered_ymax);
                        break;
                    }
                    else
                    {
                        // No block collision, step as far as the next tile
                        
                            float step = MathHelper.Max(x, tile_x - position.X - hitbox_x);
                        if (entity is Mario.Mario || entity is MarioStar)
                        {
                            float cameraStep = step * 30f;
                            Game1.Camera.PanCamera(cameraStep, game);
                        }
                            position.X += step;
                            x -= step;

                            // Handle possible entity collisions
                            HandleEntityCollisions(entity, Side.RIGHT, position.X, position.X + hitbox_x + hitbox_w, position.Y, position.Y + hitbox_y + hitbox_h);
                        
                    }
                }
            }

            // Update area covered horizontally as it may have changed
            covered_xmin = (int)(position.X + hitbox_x);
            covered_xmax = (int)Math.Ceiling(position.X + hitbox_x + hitbox_w) - 1;

            // Handle y movement
            if (y > 0)
            {
                // Get the farthest tile we want to move to
                int move_y = (int)Math.Ceiling(position.Y + hitbox_y + hitbox_h + y) - 1;

                // Step block by block to move as far as possible
                for (int tile_y = covered_ymax; tile_y <= move_y; tile_y++)
                {
                    if (level.ContainsBlock(covered_xmin, covered_xmax, tile_y, tile_y))
                    {
                        // We reached a collision, stop moving and handle collision
                        HandleBlockCollision(entity, Side.TOP, covered_xmin, covered_xmax, tile_y, tile_y);
                        break;
                    }
                    else
                    {
                        // No block collision, step as far as the next tile
                        float step = MathHelper.Min(y, tile_y + 1 - position.Y - hitbox_y - hitbox_h);
                        position.Y += step;
                        y -= step;

                        // Handle possible entity collisions
                        HandleEntityCollisions(entity, Side.TOP, position.X, position.X + hitbox_x + hitbox_w, position.Y, position.Y + hitbox_y + hitbox_h);
                    }
                }
            }
            else if (y < 0)
            {
                // Get the farthest tile we want to move to
                int move_y = (int)(position.Y + hitbox_y + y);

                // Step block by block to move as far as possible
                for (int tile_y = covered_ymin; tile_y >= move_y; tile_y--)
                {
                    if (level.ContainsBlock(covered_xmin, covered_xmax, tile_y, tile_y))
                    {
                        // We reached a collision, stop moving and handle collision
                        HandleBlockCollision(entity, Side.BOTTOM, covered_xmin, covered_xmax, tile_y, tile_y);
                        break;
                    }
                    else
                    {
                        // No block collision, step as far as the next tile
                        float step = MathHelper.Max(y, tile_y - position.Y - hitbox_y);
                        position.Y += step;
                        y -= step;

                        // Handle possible entity collisions
                        HandleEntityCollisions(entity, Side.BOTTOM, position.X, position.X + hitbox_x + hitbox_w, position.Y, position.Y + hitbox_y + hitbox_h);
                    }
                }
            }
            
            // Stop entity's velocity in a direction if a collision occured
            if (x != 0 || y != 0)
            {
                entity.Velocity.Scl(new Vector2(x == 0 ? 1 : 0, y == 0 ? 1 : 0));
            }

            // Update the entity's position
            entity.Position = position;
        }

        private void HandleBlockCollision(IMoving entity, Side side, int xMin, int xMax, int yMin, int yMax)
        {
            Level level = game.Map;
            for (int x = xMin; x <= xMax; x++)
            {
                for (int y = yMin; y <= yMax; y++)
                {
                    IBlock block = level.GetBlock(x, y);
                    if (block != null)
                    {
                        // Handle collision between entity and block on given side
                        entity.Collision.Handle(entity, block, side);
                    }
                }
            }
        }

        private void HandleEntityCollisions(IMoving entity, Side side, float xMin, float xMax, float yMin, float yMax)
        {
            foreach (IItem item in game.WorldLoader.Items)
            {
                HandleEntityCollision(entity, item, side, xMin, xMax, yMin, yMax);
            }
            foreach (IEnemy enemy in game.WorldLoader.Enemies)
            {
                HandleEntityCollision(entity, enemy, side, xMin, xMax, yMin, yMax);
            }
        }

        private static void HandleEntityCollision(IMoving entity, IEntity target, Side side, float xMin, float xMax, float yMin, float yMax)
        {
            if (entity == target)
            {
                return;
            }
            float xMinT = target.Position.X;
            float yMinT = target.Position.Y;
            if (BoundsOverlap(xMin, xMax, yMin, yMax, xMinT, xMinT + target.Bounds.Width, yMinT, yMinT + target.Bounds.Height))
            {
                entity.Collision.Handle(entity, target, side);
            }
        }

        private static bool BoundsOverlap(float l1, float r1, float b1, float t1, float l2, float r2, float b2, float t2)
        {
            return !(l1 > r2 || l2 > r1 || t1 < b2 || t2 < b1);
        }
    }
}
