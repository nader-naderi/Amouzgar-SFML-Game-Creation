using SFML.System;

namespace MyFirstSFMLGame
{
    public static class PhysicsManager
    {
        private static List<Rigidbody> rigidbodies = new List<Rigidbody>();   

        public static void AddRigidBody(Rigidbody newGameObject)
        {
            rigidbodies.Add(newGameObject);
        }

        public static void RemoveRigidbody(Rigidbody newGameObject)
        {
            rigidbodies.Remove(newGameObject);
        }

        public static void Update()
        {
            CollisionDetection();
            ApplyPhysics(1f);
        }

        private static void CollisionDetection()
        {
            for (int i = 0; i < rigidbodies.Count; i++)
            {
                for (int j = 0; j < rigidbodies.Count; j++)
                {
                    GameObejct objectA = rigidbodies[i].gameObejct;
                    GameObejct objectB = rigidbodies[j].gameObejct;

                    if ((objectA == null || objectB == null))
                        continue;

                    if (objectA == objectB)
                        continue;

                    if (objectA.CheckCollision(objectB))
                    {
                        objectA.OnCollisionEnter(objectB);
                        objectB.OnCollisionEnter(objectA);
                    }
                    else
                    {
                        objectA.OnCollisionExit(objectB);
                        objectB.OnCollisionExit(objectA);
                    }
                }
            }
        }

        public static void ApplyPhysics(float deltaTime)
        {
            foreach (Rigidbody body in rigidbodies)
            {
                // Apply Gravity
                body.ApplyForce(new Vector2f(0, body.Gravity) * deltaTime);

                // Apply Velocity
                body.gameObejct.Position += body.Velocity * deltaTime;

                // Apply Firiction
                float firiction = body.Friction * deltaTime;

                if (body.Velocity.X > 0)
                    body.Velocity -= new Vector2f(Math.Min(body.Velocity.X, firiction), 0);
                else if (body.Velocity.X < 0)
                    body.Velocity += new Vector2f(Math.Min(-body.Velocity.X, firiction), 0);
            }
        }
    }
}
