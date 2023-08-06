using UnityEngine;
using UnityEngine.UI;

public class SwitchCamera : MonoBehaviour
{
    public Camera arCamera;
    public Camera mainCamera;

    private void Start()
    {
        // Ensure that the AR camera is initially enabled and the main camera is disabled
        //arCamera.enabled = true;
        //mainCamera.enabled = false;
    }

    public void OnButtonClick()
    {
        Destroy(GameObject.Find("pokeballone")); 
        Destroy(GameObject.Find("OnScreenNow"));
        GameObject.Find("Canvas").gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);  
        arCamera.gameObject.SetActive(false);
        
    }
}
