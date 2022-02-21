using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfluence : MonoBehaviour
{
    [SerializeField] public Color userColor = Color.white;
    [SerializeField] public int userIndex = 0;
    [SerializeField] private bool isInfluencePublic = false;
    [SerializeField] private float influenceRadius = 1.0f;

    private List <AuraBehavior> objectsOwned = new List<AuraBehavior> ();



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
