namespace MyFirstSFMLGame
{
    public static class SceneManager
    {
        private static List<Scene> scenes = new List<Scene>();

        private static Scene currentActiveScene;

        public static Scene CurrentScene { get { return currentActiveScene; } }

        public static void AddScene(Scene scene)
        {
            scenes.Add(scene);

            if(currentActiveScene == null)
                currentActiveScene = scene;
        }

        public static void LoadScene(int sceneIndex)
        {
            if (sceneIndex >= 0 && sceneIndex < scenes.Count)
            {
                if (currentActiveScene != null)
                {
                    currentActiveScene.Unload();
                }

                currentActiveScene = scenes[sceneIndex];
                currentActiveScene.Load();
            }
        }
    }
}
