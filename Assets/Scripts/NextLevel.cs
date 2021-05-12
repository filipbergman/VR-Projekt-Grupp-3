using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string levelName;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.transform.root.name == "Player") {
            SceneManager.LoadScene(levelName);
            other.gameObject.transform.root.position = Vector3.zero;
        }
    }

}
