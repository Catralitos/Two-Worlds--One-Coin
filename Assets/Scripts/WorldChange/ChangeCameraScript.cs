using UnityEngine;

namespace WorldChange
{
    public class ChangeCameraScript : MonoBehaviour
    {
        // Start is called before the first frame update

        public Cinemachine.CinemachineVirtualCamera realWorldCamera;

        public Cinemachine.CinemachineVirtualCamera fakeWorldCamera;

        public SimpleTransitionScript transitionHandler;

        // public Cinemachine.CinemachineVirtualCamera fadeToBlackCamera;

        public bool realWorldCameraActive = true;

        public void ChangeCamera()
        {
            if (realWorldCameraActive)
            {
                transitionHandler.ActivateTransition(this, 1);
            }
            else 
            {
                transitionHandler.ActivateTransition(this, 2);
            }
        }

        public void HandleCoinResult(int result)
        {
            if(result == 1 && realWorldCameraActive == true) // Coroa
            {
                Debug.Log("Coroa");
                ChangeCamera();

            } 
            else if(result == 0 && realWorldCameraActive == false)
            {
                Debug.Log("Cara");
                ChangeCamera();
            }
       
        }

        public void CutTo(int cameraNumber)
        {

            if (cameraNumber == 1)
            {
                ChangetoDreamWorld();
            }
            else ChangetoRealWorld();
        }

        void ChangetoDreamWorld()
        {
            realWorldCamera.Priority = 5;
            realWorldCameraActive = false;
        }
        void ChangetoRealWorld()
        {
        
            realWorldCamera.Priority = 10;
            realWorldCameraActive = true;
        }
    }
}
