using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraHandler : MonoBehaviour
{
 //   private Camera playerCam;
 //   private ObjectState.State currentState;

 //   void OnEnable()
 //   {
 //       EventManager.StartListening("Switch",SwitchCameraState);
 //   }

 //   void OnDisable()
 //   {
 //       EventManager.StopListening("Switch", SwitchCameraState);
 //   }

	//// Use this for initialization
	//private void Start ()
 //   {
	//	GetCamera();
 //       SetCameraStartingState();
	//}

 //   private void GetCamera()
 //   {
 //       playerCam = GetComponent<Camera>();
 //   }

 //   private void SetCameraStartingState()
 //   {
 //       currentState = LevelManager.Instance.CurrentLevel.StartingState;

 //       switch (currentState)
 //       {
 //           case ObjectState.State.White:
 //               SetCameraToWhite();
 //               break;

 //           case ObjectState.State.Black:
 //               SetCameraToBlack();
 //               break;
 //       }
 //   }

 //   private void SetCameraToWhite()
 //   {
 //       playerCam.backgroundColor = Color.white;
 //   }

 //   private void SetCameraToBlack()
 //   {
 //       playerCam.backgroundColor = Color.black;
 //   }

 //   private void SwitchCameraState()
 //   {
 //       switch(currentState)
 //       {
 //           case ObjectState.State.Black:
 //               SetCameraToWhite();
 //               currentState = ObjectState.State.White;
 //               break;

 //           case ObjectState.State.White:
 //               SetCameraToBlack();
 //               currentState = ObjectState.State.Black;
 //               break;
 //       }
 //   }
	
	
}
