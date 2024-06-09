using UnityEngine;

public class Player : MonoBehaviour {
    private void Update() {
        if(Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.up * Time.deltaTime * 5f;
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.down * Time.deltaTime * 5f;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * Time.deltaTime * 5f;
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * Time.deltaTime * 5f;
        }
    }
}