using System;
using UnityEngine;

namespace Model
{
    public class ObjDownloadData
    {
        public DateTime Time;
        public Model[] Models;
    }
    public struct Model
    {
        public string Name;
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale;
    }
}
