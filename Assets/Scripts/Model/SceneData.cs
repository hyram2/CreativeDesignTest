using System.Linq;

namespace Model
{
    public class SceneData
    {
        public ModelData[] Models;

        public SceneData(SceneModel sceneObj)
        {
            Models = sceneObj.Models.Select(model => new ModelData(model)).ToArray();
        }

        public SceneData()
        {
        }
    }
    public class ModelData
    {
        public string Name;
        public float[] Position;
        public float[] Rotation;
        public float[] Scale;

        public ModelData(Model obj)
        {
            Name = obj.Name;
            Position = new[]
            {
                obj.Position.x,
                obj.Position.y,
                obj.Position.z
            };
            Rotation = new[]
            {
                obj.EulerRot.x,
                obj.EulerRot.y,
                obj.EulerRot.z
            };
            Scale = new[]
            {
                obj.Scale.x,
                obj.Scale.y,
                obj.Scale.z
            };
        }

        public ModelData()
        {
        }
    }
    
}
