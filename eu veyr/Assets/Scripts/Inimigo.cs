using UnityEngine;

public class Inimigo : Personagem
{
    [SerializeField] private int dano = 1;
    
    public float raioDeVisao = 1;
    public CircleCollider2D _visaoCollider2D;

    [SerializeField] private Transform posicaoDoPlayer;
    
    private SpriteRenderer spriteRenderer;
   

  
    
    public void setDano(int dano)
    {
        this.dano = dano;
    }
    public int getDano()
    {
        return this.dano;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       
        
        if (posicaoDoPlayer == null)
        {
            posicaoDoPlayer =  GameObject.Find("Player").transform;
        }
        
        raioDeVisao = _visaoCollider2D.radius;
    }

    void Update()
    {
        
        
        if (posicaoDoPlayer.position.x - transform.position.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        
        if (posicaoDoPlayer.position.x - transform.position.x < 0)
        {
            spriteRenderer.flipX = true;
        }


        if (posicaoDoPlayer != null && 
            Vector3.Distance(posicaoDoPlayer.position, transform.position) <= raioDeVisao )
        {
            Debug.Log("Posição do Pluer"+ posicaoDoPlayer.position);
            
            transform.position = Vector3.MoveTowards(transform.position, 
                posicaoDoPlayer.transform.position,
                getVelocidade() * Time.deltaTime);
            
           
        }
        
        if (getVida() <= 0)
        {
            
            gameObject.SetActive(false);
        }
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            int novaVida = collision.gameObject.GetComponent<Personagem>().getVida() - getDano();
            collision.gameObject.GetComponent<Personagem>().setVida(novaVida);

            
            
            
            gameObject.SetActive(false);
        }
    }
}
