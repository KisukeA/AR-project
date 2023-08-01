using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PokemonVisibility1 : MonoBehaviour
{
    public float visibleDistance; // Distance at which the Pokemon becomes visible
    //public bool check = true;
    public bool first = true;

    private GameObject pokeballInstance;
    private bool image = true;
    private GameObject target;
    private bool isVisible = false;
    private Collider pokemonCollider;

    private void Start()
    {
        // Find the target prefab instance by its name
        target = GameObject.Find("PlayerTarget");

    }

    private void Update()
    {
        //if(check){
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
        //}
        
    }
}
