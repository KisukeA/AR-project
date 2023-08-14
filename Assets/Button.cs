using UnityEngine;
using UnityEngine.UI;

public class SwitchCamera : MonoBehaviour
{
    public Camera arCamera;
    public Camera mainCamera;

    private void Start()
    {
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
