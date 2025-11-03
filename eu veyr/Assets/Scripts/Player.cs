using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Personagem
{
    private SpriteRenderer spriteRenderer;


    public Transform arma;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {


        if (arma.rotation.eulerAngles.z > -90
            && arma.rotation.eulerAngles.z < 90)
        {
            spriteRenderer.flipX = false;
        }

        if (arma.rotation.eulerAngles.z > 90
            && arma.rotation.eulerAngles.z < 270)
        {
            spriteRenderer.flipX = true;
        }




        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += new Vector3(0, getVelocidade() * Time.deltaTime, 0);

        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position -= new Vector3(0, getVelocidade() * Time.deltaTime, 0);

        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(getVelocidade() * Time.deltaTime, 0, 0);

        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position -= new Vector3(getVelocidade() * Time.deltaTime, 0, 0);
        }

    }
}

