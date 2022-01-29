using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Cinemachine.CinemachineVirtualCamera realWorldCamera;

    public Cinemachine.CinemachineVirtualCamera fakeWorldCamera;

    public Animator fadeAnim;

    // public Cinemachine.CinemachineVirtualCamera fadeToBlackCamera;

    public bool realWorldCameraActive = true;

    public void ChangeCamera()
    {
        if (realWorldCameraActive)
        {
            fadeAnim.SetTrigger("Fade");
           
            ChangetoDreamWorld();
        }
        else 
        {
            fadeAnim.SetTrigger("Fade");
       
            ChangetoRealWorld();
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
