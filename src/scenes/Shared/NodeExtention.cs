using Godot;

namespace DodgeTheCreeps.src.Scenes.Shared
{
    public static class NodeExtention
    {
        public static T LoadAndInstance<T>(this Node node, string path) where T : Node
        {
            var packedScene = ResourceLoader.Load<PackedScene>(path);

            if (packedScene == null) return null;

            T instance = packedScene.Instance() as T;

            if (instance == null) { return null; }

            node.AddChild(instance);

            return instance;
        }
    }
}