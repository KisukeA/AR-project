using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Drag : MonoBehaviour {

    bool dragging = false;
    float distance;
    public float ThrowSpeed = 9;
    public float ArchSpeed = 7;
    public float Speed = 10;
    public GameObject pokebal;
    public GameObject arCamera;
    public bool fir;

    private bool steady = false;
    private GameObject pokeballInstance;

    void Start(){
        if(!fir){
            StartCoroutine(Delayed());
        } 
        //gameObject.transform.SetParent(arCamera.transform);
    }
    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        steady = false;
    }

    public void OnMouseUp()
    { 
        StartCoroutine(DelayedFunctionCoroutine(gameObject));
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().velocity += this.transform.forward * ThrowSpeed;
        this.GetComponent<Rigidbody>().velocity += this.transform.up * ArchSpeed;
        dragging = false;
        
    }

 void Update () {
    if(dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = Vector3.Lerp(this.transform.position, rayPoint, Speed * Time.deltaTime);
        }
    
 }
 void LateUpdate()
    {
        if(steady){
        Vector3 offset = new Vector3(Camera.main.transform.position.x - pokebal.transform.position.x,Camera.main.transform.position.y - pokebal.transform.position.y,Camera.main.transform.position.z - pokebal.transform.position.z);
        pokebal.transform.position = Camera.main.transform.position + offset;
    }
    }
 private void OnCollisionEnter(Collision collision)
    {
        // Check if the pokeball collides with any object
        if (collision.gameObject != null)
        {
            // Destroy the pokeball
            //Destroy(gameObject);
            GameObject.Find("Canvas").transform.Find("PokeText").GetComponent<TextMeshProUGUI>().text = "Pokemon Caught";
            Destroy(GameObject.Find("OnScreenNow"));
            StartCoroutine(DExit());
        }
    }
IEnumerator DExit(){
    yield return new WaitForSeconds(1.5f);
    Destroy(GameObject.Find("pokeballone")); 
    GameObject.Find("Canvas").gameObject.SetActive(false);
    arCamera.gameObject.SetActive(false);
    GameObject.Find("World").transform.Find("Calem").transform.Find("Main Camera").gameObject.SetActive(true);
}
IEnumerator Delayed(){
    yield return new WaitForSeconds(0.1f);
    Vector3 worldPosition = new Vector3(59.85f,705.5f,-37);
    transform.position = worldPosition;
    
}
IEnumerator DelayedFunctionCoroutine(GameObject pokeballObject)
{
    yield return new WaitForSeconds(4); // Wait for 3 seconds

    
    // Set the position of the pokeball
    pokeballInstance = Instantiate(pokebal, Vector3.zero, Quaternion.identity);
    pokeballInstance.name = "pokeballone";
    //Drag drag = pokeballInstance.AddComponent<Drag>();
    pokeballInstance.GetComponent<Drag>().pokebal = pokeballInstance;
    pokeballInstance.GetComponent<Drag>().arCamera = arCamera;
    pokeballInstance.GetComponent<Drag>().fir = false;
    //pokeballInstance.transform.position = worldPosition;
    //pokeballInstance.transform.SetParent(arCamera.transform);
    pokeballInstance.GetComponent<Rigidbody>().useGravity = false;
    Destroy(pokeballObject);
}
}