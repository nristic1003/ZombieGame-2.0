using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    

    private Animator anim;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;

    public ShoothingABullet bullet;

    private float timeBetweenAttack = 1.5f;
    public float startTime;

    private AudioSource source;
    public AudioClip shoothing, collectingCoin;
    public bool grounded = true;



    private bool canShoot = true;
    [SerializeField]
    private int numOfBullets = 10;

    private bool gun = false, knife = false;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        
    }

    private void Start()
    {
        GameController.gameManager.setNUmOfBullets(PlayerPrefs.GetInt("NumOfBullets"));
        numOfBullets = PlayerPrefs.GetInt("NumOfBullets");
    }

    // Update is called once per frame
    void Update()
    {

        if(timeBetweenAttack <=0)
        {
            if (knife)
            {
                anim.SetBool("attack", true);
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemies.Length; i++)
                    enemies[i].GetComponent<Enemy>().TakeDamage(2);


            }else if (gun && numOfBullets > 0) // do korišćenja oružja dolazi samo ako glavni karakter ima oružje, i ima bar jedan metak
            {
                numOfBullets--; //broj preostale municije
                GameController.gameManager.setNUmOfBullets(numOfBullets); //čuvanje trenutnog broja preostale municije globalno za korišćenje u drugim nivoima
                anim.SetBool("shoot", true); //podešavanje parametra shoot na true da bi se ispunio uslov za tranziciju u Attack stanje
                source.clip = shoothing; //postavljanje odredjenog zvuka koji će se reprodukovati 
                source.Play(); //reprodukavnje zvuka
                if(transform.localScale.x ==1) //provera na koju stranu je okrenut igrač 1==DESNO, -1==LEVO
                {
                    //DESNO
                    ShoothingABullet clone = Instantiate(bullet, new Vector3(transform.position.x + 1f, transform.position.y - 0.35f, 0), Quaternion.identity); //kreiranje metka koji će biti iskorišćen
                    clone.dirrection = transform.localScale.x; //podešavanje pravca metka -- kreće se desno
                    clone.setScale(transform.localScale);  //podešavanje veličine metka
                }
                else
                {
                    //LEVO
                    ShoothingABullet clone = Instantiate(bullet, new Vector3(transform.position.x - 1f, transform.position.y - 0.35f, 0), Quaternion.identity); //kreiranje metka koji će biti iskorišćen
                    clone.dirrection = transform.localScale.x; //podešavanje pravca metka -- kreće se levo
                    clone.setScale(transform.localScale); //podešavanje veličine metka
                }         
            }
            else
            {
                anim.SetBool("attack", false);
                anim.SetBool("shoot" , false);
            }
            timeBetweenAttack = startTime;
        }
      
        else
        {
                timeBetweenAttack -= Time.deltaTime;
               

            }
       
    }

    public void setAttack(bool at)
    {
        gun = at;
        knife = !at;
    }

    public void clearAttack()
    {
        gun = knife = false;
    }

    public void setBullets(int b)
    {
        numOfBullets += b;
        GameController.gameManager.setNUmOfBullets(numOfBullets);
    }

    public void setCoinClip()
    {
        source.clip = collectingCoin;
        source.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
