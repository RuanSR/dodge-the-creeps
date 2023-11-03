using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Godot;

namespace DodgeTheCreeps.src.scenes.Shared
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