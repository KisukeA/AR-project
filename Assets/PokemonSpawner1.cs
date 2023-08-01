using System.Collections;
using UnityEngine;

public class PokemonSpawner1 : MonoBehaviour
{
    public GameObject pokemonPrefab1;
    public GameObject pokemonPrefab2;
    public GameObject pokemonPrefab3;
    public GameObject pokemonPrefab4;
    public GameObject pokemonPrefab5;
    public GameObject pokemonPrefab6;
    public GameObject pokemonPrefab7;
    public GameObject pokemonPrefab8;
    public GameObject particlePrefab;
    public GameObject pokeballPrefab;

    public Transform target;

    private int spawnRadius = 25;
    private int despawnDuration = 40; // Duration before despawning Pokemon
    private int visibleDistance = 13; // Distance at which the Pokemon becomes visible
    private int spawnInterval = 5;
    private float lastSpawnTime;
    private int numPokemonToSpawn = 5;
    private float movementThreshold = 10f; // Adjust this value as desired

    private Transform pokemonParent; // Parent object to hold the spawned Pokemon

    private void Start()
    {
        lastSpawnTime = Time.time;
        // Create a new parent object for the spawned Pokemon
        pokemonParent = new GameObject("PokemonParent").transform;

    }

    private void Update()
    {
        // Check if enough time has passed to spawn new Pokemon
        if (Time.time - lastSpawnTime >= spawnInterval){
            spawnInterval = 30;
            // Determine the number of Pokemon to spawn based on player movement
            //numPokemonToSpawn = GetNumPokemonToSpawn();

            // Spawn new Pokemon objects
            for (int i = 0; i < numPokemonToSpawn; i++)
            {
                SpawnPokemon();
            }

            // Update the last spawn time
            lastSpawnTime = Time.time;
        }
    }

    private int GetNumPokemonToSpawn()
    {
        // Check player movement by comparing the current and previous positions
        Vector3 currentPosition = target.position;
        Vector3 previousPosition = currentPosition - target.forward * Time.deltaTime;
        float distance = Vector3.Distance(currentPosition, previousPosition);

        // Adjust the number of Pokemon to spawn based on the player's movement distance
        if (distance >= movementThreshold)
        {
            return Mathf.RoundToInt(distance * 0.1f); // Adjust the factor as desired
        }
        else
        {
            return 10; // Default number of Pokemon to spawn when standing still
        }
    }

    private void SpawnPokemon()
    {
        // Generate a random position within the spawn radius
        Vector2 randomOffset = Random.insideUnitCircle;
        Vector3 spawnPosition = target.position + new Vector3(randomOffset.x * spawnRadius, 0f, randomOffset.y * spawnRadius);
        float distance = Vector3.Distance(target.position, spawnPosition);

        // Instantiate the Pokemon object at the spawn position
        GameObject pokemonObject;
        int p = Random.Range(0,10000);
        if(p>=9990){
            pokemonObject = Instantiate(pokemonPrefab6, spawnPosition, Quaternion.identity);
            pokemonObject.transform.eulerAngles = new Vector3(0,Random.Range(0,360),0);
            if (distance <= visibleDistance)
            {
                pokemonObject.SetActive(true); // Set the Pokemon object active
            }
            else
            {
                pokemonObject.SetActive(false); // Set the Pokemon object inactive
            }
        }
        else if(p>=9800){
            pokemonObject = Instantiate(pokemonPrefab5, spawnPosition, Quaternion.identity);
            pokemonObject.transform.eulerAngles = new Vector3(0,Random.Range(0,360),0);
            if (distance <= visibleDistance)
            {
                pokemonObject.SetActive(true); // Set the Pokemon object active
            }
            else
            {
                pokemonObject.SetActive(false); // Set the Pokemon object inactive
            }
        }
        else if(p>=8000){
            pokemonObject = Instantiate(pokemonPrefab4, spawnPosition, Quaternion.identity);
            pokemonObject.transform.eulerAngles = new Vector3(0,Random.Range(0,360),0);
            if (distance <= visibleDistance)
            {
                pokemonObject.SetActive(true); // Set the Pokemon object active
            }
            else
            {
                pokemonObject.SetActive(false); // Set the Pokemon object inactive
            }
        }
        else if(p>=6400){
            pokemonObject = Instantiate(pokemonPrefab3, spawnPosition, Quaternion.identity);
            pokemonObject.transform.eulerAngles = new Vector3(0,Random.Range(0,360),0);
            if (distance <= visibleDistance)
            {
                pokemonObject.SetActive(true); // Set the Pokemon object active
            }
            else
            {
                pokemonObject.SetActive(false); // Set the Pokemon object inactive
            }
        }
        else if(p>=4800){
            pokemonObject = Instantiate(pokemonPrefab7, spawnPosition, Quaternion.identity);
            pokemonObject.transform.eulerAngles = new Vector3(0,Random.Range(0,360),0);
            if (distance <= visibleDistance)
            {
                pokemonObject.SetActive(true); // Set the Pokemon object active
            }
            else
            {
                pokemonObject.SetActive(false); // Set the Pokemon object inactive
            }
        }
        else if(p>=3200){
            pokemonObject = Instantiate(pokemonPrefab8, spawnPosition, Quaternion.identity);
            pokemonObject.transform.eulerAngles = new Vector3(0,Random.Range(0,360),0);
            if (distance <= visibleDistance)
            {
                pokemonObject.SetActive(true); // Set the Pokemon object active
            }
            else
            {
                pokemonObject.SetActive(false); // Set the Pokemon object inactive
            }
        }
        else if(p>=1600){
            pokemonObject = Instantiate(pokemonPrefab2, spawnPosition, Quaternion.identity);
            pokemonObject.transform.eulerAngles = new Vector3(0,Random.Range(0,360),0);
            if (distance <= visibleDistance)
            {
                pokemonObject.SetActive(true); // Set the Pokemon object active
            }
            else
            {
                pokemonObject.SetActive(false); // Set the Pokemon object inactive
            }
        }
        else{
            pokemonObject = Instantiate(pokemonPrefab1, spawnPosition, Quaternion.identity);
            pokemonObject.transform.eulerAngles = new Vector3(0,Random.Range(0,360),0);
            if (distance <= visibleDistance)
            {
                pokemonObject.SetActive(true); // Set the Pokemon object active
            }
            else
            {
                pokemonObject.SetActive(false); // Set the Pokemon object inactive
            }
        }
        // Set the parent of the Pokemon object to the Pokemon parent object
        pokemonObject.transform.SetParent(pokemonParent);

        // Add the PokemonVisibility script to the Pokemon object
        PokemonVisibility1 visibilityScript = pokemonObject.AddComponent<PokemonVisibility1>();
        visibilityScript.visibleDistance = visibleDistance;


        StartCoroutine(DespawnPokemon(pokemonObject));
    }

    private IEnumerator DespawnPokemon(GameObject pokemonObject)
    {
        yield return new WaitForSeconds(despawnDuration);

        // Remove the Pokemon object from the scene
        Destroy(pokemonObject);
    }
}
