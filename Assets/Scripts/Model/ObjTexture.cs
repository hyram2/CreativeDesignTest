using UnityEngine;

namespace Model
{
    public class ObjTexture
    {
        public string Name{ get; set; }
        public Texture[] Textures{ get; set; }
        public ObjTexture(string name, Texture[] textures)
        {
            Name = name;
            Textures = textures;
        }
    }
}