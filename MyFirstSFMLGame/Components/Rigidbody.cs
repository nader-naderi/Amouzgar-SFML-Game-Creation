using MyFirstSFMLGame;
using SFML.System;

namespace MyFirstSFMLGame
{
    /// <summary>
    /// جسم صلب
    /// </summary>
    public class Rigidbody : Component, IPhysical
    {
        public float Mass { get; set; } = 1;
        public float Gravity { get; set; } = 0.001f;
        public float Friction { get; set; } = 10.5f;
        public Vector2f Velocity { get; set; }

        public void ApplyForce(Vector2f force)
        {
            Velocity += force;
        }

        public override void Update(float deltaTime)
        {
            // Apply Gravity
            ApplyForce(new Vector2f(0, Gravity) * Mass * deltaTime);

            // Apply Velocity
            gameObject.Position += Velocity * deltaTime;

            // Apply Friction
            float friction = Friction * deltaTime;

            if (Velocity.X > 0)
                Velocity -= new Vector2f(Math.Min(Velocity.X, friction), 0);
            else if (Velocity.X < 0)
                Velocity += new Vector2f(Math.Min(-Velocity.X, friction), 0);
        }
    }
}
