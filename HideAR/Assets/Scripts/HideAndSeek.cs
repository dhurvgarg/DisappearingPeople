using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class HideAndSeek : MonoBehaviour {

    // Prefab to randomly place around the area
    public GameObject hiddenObject;
    // Canvas for text to pop up on
    public GameObject canvas;

    // Collider attached to camera
    private CapsuleCollider cameraCollider;

    // HashSet of locations that will be set later
    private HashSet<Vector3> locations;

	// Use this for initialization
	void Start () {
        // Hide text
        canvas.SetActive(false);

        locations = new HashSet<Vector3>();
        cameraCollider = GetComponent<CapsuleCollider>();

        // Range is area around person, set to -10 - 10
        float x = Random.Range(-10, 10);
        float z = Random.Range(-10, 10);


        // location of ObjectToFind game object
        Vector3 location = new Vector3(x, -1.5f, z);

        locations.Add(location);

        // Rotate object towards camera
        Quaternion rotation = new Quaternion();
        Vector3 lookPosition = this.transform.position;
        lookPosition.y = -1.5f;

        rotation.SetLookRotation((lookPosition - location).normalized, Vector3.up);

        // Instantiate game object to find
        GameObject newGameObject = Instantiate(hiddenObject, location, rotation);
        newGameObject.tag = "ObjectToFind";

        // Create random objects in different locations
        createObjects(14);
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("ENTERED");

        // Objects that are tagged with TriggerBasedObject disappear
        if (other.gameObject.tag == "TriggerBasedObject") {
            other.gameObject.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
            //other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        // Objects that are tagged with ObjectToFind display text
        if (other.gameObject.tag == "ObjectToFind") {
            canvas.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Objects that are tagged with TriggerBasedObject reappear on exit
        if (other.gameObject.tag == "TriggerBasedObject")
        {
            other.gameObject.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().enabled = true;
            //other.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

        // Objects that are tagged with ObjectToFind rehide text on exit
        if (other.gameObject.tag == "ObjectToFind")
        {
            canvas.SetActive(false);
        }
    }

    void createObjects(int numberOfObjects) {

        for (int i = 0; i < numberOfObjects; i++) {
            float x = Random.Range(-10, 10);
            float z = Random.Range(-10, 10);

            Vector3 location = new Vector3(x, -1.5f, z);

            // Make sure locations aren't repeated
            while (locations.Contains(location)) {
                x = Random.Range(-10, 10);
                z = Random.Range(-10, 10);

                location = new Vector3(x, -1.5f, z);
            }

            locations.Add(location);

            // Rotate objects towards user
            Quaternion rotation = new Quaternion();
            Vector3 lookPosition = this.transform.position;
            lookPosition.y = -1.5f;

            rotation.SetLookRotation((lookPosition - location).normalized, Vector3.up);

            GameObject newGameObject = Instantiate(hiddenObject, location, rotation);


            //newGameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        }


    }
}
