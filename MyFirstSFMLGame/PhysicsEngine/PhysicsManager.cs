
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
                Collider colliderA = rigidbodies[i].gameObject.GetComponent<Collider>();

                for (int j = 0; j < rigidbodies.Count; j++)
                {
                    Collider colliderB = rigidbodies[j].gameObject.GetComponent<Collider>();

                    if (colliderA == null || colliderB == null)
                        continue;

                    if (colliderA.CheckCollision(colliderB))
                    {
                        colliderA.gameObject.OnCollisionEnter(colliderB.gameObject);
                        colliderB.gameObject.OnCollisionEnter(colliderA.gameObject);
                        Console.WriteLine("AA");
                    }
                    else
                    {
                        colliderA.gameObject.OnCollisionExit(colliderB.gameObject);
                        colliderB.gameObject.OnCollisionExit(colliderA.gameObject);
                    }
                }
            }
        }

        public static void ApplyPhysics(float deltaTime)
        {
            foreach (Rigidbody body in rigidbodies)
                body.Update(deltaTime);
        }
    }
}
