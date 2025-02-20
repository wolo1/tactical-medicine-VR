using UnityEngine;

public class PartyLight : MonoBehaviour
{
    public Light partyLight;
    public float speed = 2f; // Speed of color change

    void Update()
    {
        // Change color over time
        float t = Mathf.PingPong(Time.time * speed, 1);
        partyLight.color = Color.Lerp(Color.red, Color.blue, t);
    }
}
