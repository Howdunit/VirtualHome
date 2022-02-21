using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraBehavior : MonoBehaviour
{
    public List <UserInfluence> owners = new List<UserInfluence> ();
    private Material mat;


    private void Awake() {
        mat = GetComponent <MeshRenderer> ().material;

        foreach (UserInfluence owner in owners) {
            Color _color = owner.userColor;
            int _index = owner.userIndex;
            mat.SetColor (("_User" + _index + "Color"), _color);
            mat.SetVector (("_User" + _index + "Pos"), owner.transform.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mat) {

            foreach (UserInfluence owner in owners) {
                Color _color = owner.userColor;
                int _index = owner.userIndex;
                mat.SetColor (("_User" + _index + "Color"), _color);
                mat.SetVector (("_User" + _index + "Pos"), owner.transform.position);
            }        
        }
    }
}
