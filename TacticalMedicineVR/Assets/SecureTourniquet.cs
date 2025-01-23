using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class SecureTourniquet : MonoBehaviour
{
    [SerializeField]
    private GameObject windlass;

    [SerializeField]
    private DynamicCharacterAvatar avatar;

    [SerializeField]
    private UMATextRecipe tourniquetRecipe;


    [SerializeField]
    private Collider colliderIsraeli;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check if the windlass rotation on the y-axis is 200 degrees
        if (Mathf.Approximately(windlass.transform.localRotation.eulerAngles.y, 200))
        {
            // TODO: gradually decrease bleeding and size of the tourniquet
        }

        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            colliderIsraeli.enabled = true;
            EquipTourniquet();
        }
    }

    public void EquipTourniquet()
    {
        avatar.SetSlot(tourniquetRecipe);
        avatar.BuildCharacter();
    }
}
