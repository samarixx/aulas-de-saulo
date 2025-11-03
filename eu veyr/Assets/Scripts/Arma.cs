using UnityEngine;

public class Arma : MonoBehaviour
{
    public Transform saidaTiro;
    
    public GameObject bala;
    public float intevaloDisparo = 0.1f;
    
    private float tempoDeDisparo = 0;
    
    private Camera camera;
    public GameObject cursor;

    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        camera = Camera.main;
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        if (gameObject.transform.rotation.eulerAngles.z > -90 && gameObject.transform.rotation.eulerAngles.z < 90)
        {
            transform.localScale = new Vector3(1 , 1, 1);
        }
        
        if (gameObject.transform.rotation.eulerAngles.z > 90 && gameObject.transform.rotation.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3( 1, -1, 1);
        }

        
        float camDis = camera.transform.position.y - transform.position.y;

        
        Vector3 mouse = camera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, camDis));

        float AngleRad = Mathf.Atan2 (mouse.y - transform.position.y, mouse.x - transform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        transform.rotation =  Quaternion.AngleAxis( angle, Vector3.forward);
       
        Debug.Log("giovanini "+angle);
        
        cursor.transform.position = new Vector3(mouse.x, mouse.y, cursor.transform.position.z);
        
        Debug.DrawLine(transform.position, mouse , Color.red);
        
        
        if (tempoDeDisparo <=0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            Debug.Log("atirou");
         
            GameObject b = Instantiate (this.bala,saidaTiro.position, saidaTiro.rotation) as GameObject;
            
            tempoDeDisparo = intevaloDisparo;
        }

        if (tempoDeDisparo > 0)
        {
            tempoDeDisparo -= Time.deltaTime;
        }
    }
}
