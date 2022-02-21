using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    public bool controlOn = false;
    public float moveSpeed = 1.0f;
    public Camera playerCamera;

    public Color auraColor;
    public LayerMask layerMask;

    private SphereCollider auraSphere;

    private void Awake() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        auraSphere = GetComponent <SphereCollider> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlOn) {
            
            Quaternion currRot = transform.rotation;

            // print ("Mouse X Coordinate: " + Input.GetAxis ("Mouse X"));
            // print ("Mouse Y Coordinate: " + Input.GetAxis ("Mouse Y"));

            Vector3 currPos = transform.position;

            if (Input.GetKey (KeyCode.LeftArrow)) {
                currPos += -transform.right * moveSpeed * Time.deltaTime;
                print ("Moving left");
            }

            if (Input.GetKey (KeyCode.RightArrow)) {
                currPos += transform.right * moveSpeed * Time.deltaTime;
                print ("Moving right");
            }

            if (Input.GetKey (KeyCode.UpArrow)) {
                currPos += transform.forward * moveSpeed * Time.deltaTime;
                print ("Moving forward");
            }

            if (Input.GetKey (KeyCode.DownArrow)) {
                currPos += -transform.forward * moveSpeed * Time.deltaTime;
                print ("Moving backward");
            }

            transform.position = currPos;                                    
        }
    }

    private void OnDrawGizmos() {
        if (auraSphere) {
            Gizmos.color = auraColor;
            Gizmos.DrawWireSphere (transform.position, auraSphere.radius);
        }
    }

    void UpdateAuraRadius (float radius) {

        if (auraSphere) {
            auraSphere.radius = radius;
            print ("Updated aura influence radius to: " + radius);
        }

        else {
            print ("Aura sphere collider not found");
        }
    }

    void SetAuraState (bool active) {

        if (auraSphere) {
            auraSphere.enabled = active;

            print ("Aura sphere state set to: " + active);
        }
    }


    private void OnTriggerEnter(Collider other) {

        // If the object is virtual and belongs to this user.
        if (other.CompareTag ("Virtual") && (other.gameObject.layer & layerMask) > 0) {
            
            other.gameObject.SetActive (true);

            print ("Detected virtual belonging: " + other.name);
        }

        // If the object is physical.
        else if (other.CompareTag ("Physical")) {
            Material [] materials = other.GetComponent <MeshRenderer> ().materials;

            foreach (Material mat in materials) {
                mat.color = auraColor;
            }

            print ("Changed aura of: " + other.name);
        }
    }

    private void OnTriggerExit(Collider other) {
        // If the object is virtual and belongs to this user.
        if (other.CompareTag ("Virtual") && (other.gameObject.layer & layerMask) > 0) {
            
            other.gameObject.SetActive (false);

            print ("Undetected virtual belonging: " + other.name);
        }

        // If the object is physical.
        else if (other.CompareTag ("Physical")) {
            Material [] materials = other.GetComponent <MeshRenderer> ().materials;

            foreach (Material mat in materials) {
                mat.color = Color.white;
            }

            print ("Reverted aura of: " + other.name);
        }        
    }

    private void OnTriggerStay(Collider other) {
        
    }
}
