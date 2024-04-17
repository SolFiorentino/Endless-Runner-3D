using UnityEngine;

public class CamaraFollow : MonoBehaviour
{


    [SerializeField] Transform Player;
    Vector3 offset;
    
    
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        offset = transform.position - Player.position;

    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 TargetPos = Player.position + offset;
        TargetPos.x = 0;
        transform.position = TargetPos;

    }
}
