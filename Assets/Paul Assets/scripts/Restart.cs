 using UnityEngine;
 using UnityEngine.SceneManagement;
 using System.Collections;
 
 public class Restart : MonoBehaviour {
 
     public void RestartGame() {
     	Destroy(GameObject.Find("MixedRealityCameraParent"));
     	Destroy(GameObject.Find("Manager"));
     	Destroy(GameObject.Find("InputManager"));
     	Destroy(GameObject.Find("SpatialMapping"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
     }
 
 }