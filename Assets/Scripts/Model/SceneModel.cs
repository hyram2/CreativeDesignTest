using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class SceneModel
    {
        public List<Model> Models = new List<Model>();
        public string Name { get; set; }
        
        public SceneModel(SceneData model)
        {
            foreach (var mdata in model.Models)
            {
                Models.Add(new Model(mdata));
            }
        }

        public SceneModel()
        {
        }
    }
            
    public class Model
    {
        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 EulerRot{ get; set; }
        public Vector3 Scale { get; set; }

        public Model(ModelData data)
        {
            Name = data.Name;
            Position = new Vector3(data.Position[0],data.Position[1],data.Position[2]);
            EulerRot = new Vector3(data.Rotation[0],data.Rotation[1],data.Rotation[2]);
            Scale = new Vector3(data.Scale[0],data.Scale[1],data.Scale[2]);
        }

        public Model(SceneObj objData)
        {
            Name = objData.name;
            Position = objData.transform.position;
            EulerRot = objData.transform.eulerAngles;
            Scale = objData.transform.localScale;
        }
    }

    public class ObjectModel
    {
        public Model ModelRef;
    }
}