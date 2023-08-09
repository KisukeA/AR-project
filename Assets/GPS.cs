using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GpsSystem : MonoBehaviour
{
 Vector2 RInit;
 Vector2 RCurrentPosition;
 Vector2 FInit;
 Vector2 FCurrentPosition;

 public float Scale;

 public bool FakingLocation;

 public void Start()
 {
  Input.location.Start(0.5f);
  Input.compass.enabled = true;

  FInit = Vector2.zero;
 }

 IEnumerator UpdatePosition()
 {
  if(FakingLocation == false) {
   if(Input.location.isEnabledByUser == false) {
    Debug.Log("ERROR: User has not enabled location!");
    //GameObject.Find("ErrorText").GetComponent<Text>().text = "Please turn on GPS and try again.";
   }

   int maxWaitForLocation = 20;
   while(Input.location.status == LocationServiceStatus.Initializing && maxWaitForLocation > 0) {
    yield return new WaitForSeconds (1);
    maxWaitForLocation--;
   }

   if (maxWaitForLocation < 1) {
    Debug.Log("Initialising failed. Try again.");
    //GameObject.Find("ErrorText").GetComponent<Text>().text = "Error. Please try again.";
    yield return null;
   }

   if(Input.location.status == LocationServiceStatus.Failed) {
    Debug.Log("Location Service Status Failed!");
    GameObject.Find("ErrorText").GetComponent<Text>().text = "Location services have failed!";
    yield return null;
   } else {
    if(RInit == Vector2.zero) {
     RInit = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
     SetLocation(Input.location.lastData.latitude, Input.location.lastData.longitude);
    }

   }
  } 
  else 
  {
   SetLocation(100 + Time.time, 100 + Time.time);
  }




 }


 void SetLocation(float latitude, float longitude)
 {
  RCurrentPosition = new Vector2(latitude, longitude);
  Vector2 delta = new Vector2(RCurrentPosition.x - RInit.x, RCurrentPosition.y - RInit.y);
  RCurrentPosition = delta * Scale;
  this.transform.position = new Vector3(RCurrentPosition.x, 1, RCurrentPosition.y);
  //GameObject.Find("Canvas").GetComponent<Text>().text = this.transform.position.x + " : " + this.transform.position.y + " : " + this.transform.position.z;
    Debug.Log(this.transform.position.x + " : " + this.transform.position.y + " : " + this.transform.position.z);
 }

 void Update()
 {
  StartCoroutine(UpdatePosition());
 }

}