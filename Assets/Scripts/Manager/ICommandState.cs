using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
     public interface ICommandState
     {
          List<SceneObj> SceneObjs { get; set; }

          void OnMouseDown(SceneObj obj);

          void OnMouseDrag();

          void OnStateStart();
          
          void OnStateExit();

          void OnKeyEvent(KeyCode keyCode);
     }
}
