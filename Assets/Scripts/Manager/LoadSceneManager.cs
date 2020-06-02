using System.Collections.Generic;
using System.Linq;
using Model;
using UnityEngine;

namespace Manager
{
    public class LoadSceneManager : MonoBehaviour
    {
        private const string DefautName = "Defaut";

        private GameManager _gameManagerRef;
        
        //This is called On Async Load Scene. 
        void Awake()
        {
            _gameManagerRef = GameManager.Instance;
            LoadAssets();
        }

        void LoadAssets()
        {
            
            var scene = _gameManagerRef.sceneToLoad;
            //load Objects
            scene.Models.ForEach(x =>
            {
                var source = Resources.Load<SceneObj>(x.Name);
                if (source == null) source = Resources.Load<SceneObj>(DefautName);
                var obj = Instantiate(source);
                obj.name = x.Name;
                obj.transform.position = x.Position;
                obj.transform.eulerAngles = x.EulerRot;
                obj.transform.localScale = x.Scale;
                _gameManagerRef.objsScene.Add(obj);
            });
            //load Textures 
            var toLoad = scene.Models.Select(x=>x.Name).AsParallel().Distinct().ToList();
            toLoad.ForEach(x =>
            {
                var textures = Resources.LoadAll<Texture>(x);
                if (!textures.Any()) textures = Resources.LoadAll<Texture>(DefautName);
                _gameManagerRef.objsTextures.Add(new ObjTexture(x,textures));
            });
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
