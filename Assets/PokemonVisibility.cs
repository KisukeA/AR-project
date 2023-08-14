using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PokemonVisibility : MonoBehaviour
{
    public float visibleDistance; // Distance at which the Pokemon becomes visible
    public GameObject particlePrefab;
    public GameObject arCamera;
    public GameObject canvas;
    public GameObject pokeballPrefab;
    public bool check = true;
    public bool first = true;

    private GameObject pokeballInstance;
    private bool image = true;
    private GameObject target;
    private bool isVisible = false;
    private Collider pokemonCollider;

    private void Start()
    {
        // Find the target prefab instance by its name
        target = GameObject.Find("Calem");
        pokemonCollider = GetComponent<Collider>();
        if(pokemonCollider == null){
            Transform childObject = transform.Find("GameObject");
            pokemonCollider = childObject.GetComponent<Collider>();
        }

    }

    private void Update()
    {
        if(check){
            if(target != null){
            // Calculate the distance between the Pokemon and the target prefab instance
            float distance = Vector3.Distance(transform.position, target.transform.position);
            Debug.Log("distance "+distance);
            // Set the visibility of the Pokemon based on the distance
            if (distance <= visibleDistance)
            {
                gameObject.SetActive(true); // Set the Pokemon object active
                isVisible = true;
            }
            else
            {
                isVisible = false;
                gameObject.SetActive(false); // Set the Pokemon object inactive
            }
        }
        }
        
        if (isVisible)
        {
            // Check for touch input
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Check if the touch position overlaps with the Pokemon collider
                if (touch.phase == TouchPhase.Began && pokemonCollider != null && IsTouchOverPokemon(touch.position))
                {
                    // Perform the desired action when the Pokemon is touched
                    //ChangeText("janasana");
                    
                    // Example: Spawn a particle effect
                    //GameObject particleEffect = Instantiate(particlePrefab, transform.position, Quaternion.identity);
                    //Destroy(particleEffect,12);
                    //GameObject.Find("Canvas").transform.Find("Image").gameObject.SetActive(image); // Find the Canvas object
                    //image = !image;
                    
                    // Deactivate the main camera
                    Camera.main.gameObject.SetActive(false);

                    // Activate the AR camera and display the new scene or panel
                    arCamera.gameObject.SetActive(true);
                    //panel.SetActive(true)
                    canvas.gameObject.SetActive(true);
                    gameObject.name = "OnScreenNow";
                    canvas.transform.Find("PokeText").GetComponent<TextMeshProUGUI>().text = "Catch 'Em All";
                    //if(first){
                        
                    pokeballInstance = Instantiate(pokeballPrefab, Vector3.zero, Quaternion.identity);
                    pokeballInstance.name = "pokeballone";
                    Drag drag = pokeballInstance.AddComponent<Drag>();
                    drag.pokebal = pokeballInstance;
                    drag.arCamera = arCamera;
                    drag.fir = true;
                    // Set the pokeball's parent to the canvas
                    //pokeballInstance.transform.SetParent(canvas.transform, false);
                    // Position the pokeball at the bottom center of the screen
                    PositionPokeballAtBottomCenter();
                    gameObject.transform.position = new Vector3(59.85f, 707.5f, -30);
                    gameObject.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f); 
                    check = false;
                    //first = false;
                    //}
                    
                    //vrati go na mesto run ko ke stegnit, ak postojt
                    //sredi neso za ona so presmetvit visibility na sekoe
                    //rotiraj go ko so trebit isto
                    //zapamti ja rotacijata i mestoto prvicno
                    // ko ke go pogodis so topka go destroyvis i to e to pisis pokemon caught
                    //gledaj samo da naprajs da sejt vmesto vo sveton pokemonon a topkana da e staticna na ekranon
                    
                }
            }
        }
            
    }
    public void ChangeText(string newText)
    {
        GameObject.Find("Canvas").transform.Find("ErrorText").GetComponent<Text>().text = newText;
    }
    private bool IsTouchOverPokemon(Vector2 touchPosition)
    {
        Ray touchRay = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;

        // Cast a ray from the touch position and check if it hits the Pokemon collider
        if (Physics.Raycast(touchRay, out hit, Mathf.Infinity))
        {
            return hit.collider == pokemonCollider;
        }

        return false;
    }
    private void PositionPokeballAtBottomCenter()
    {
        // Get the AR camera's viewport dimensions 
        //float viewportWidth = 1f; // Full width of the viewport
        //float viewportHeight = 1f; // Full height of the viewport

        // Calculate the position for the pokeball
        //Vector3 pokeballPosition = new Vector3(viewportWidth / 2f, viewportHeight * 0.1f, 1f);

        // Convert the viewport position to world position
        //Vector3 worldPosition = arCamera.GetComponent<Camera>().ViewportToWorldPoint(pokeballPosition);
        //worldPosition.y = 0f; // Set the pokeball at ground level
        Vector3 worldPosition = new Vector3(59.85f,705.5f,-37);
        // Set the position of the pokeball
        pokeballInstance.transform.position = worldPosition;
        //pokeballInstance.transform.SetParent(arCamera.transform);

        //pokeballInstance.transform.localScale = new Vector3(1,1,1);
    }
}

