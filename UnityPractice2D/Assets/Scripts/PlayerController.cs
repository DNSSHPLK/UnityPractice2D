
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D RB;
    SpriteRenderer SR;
    Animator AN; 
    public float speed = 3;
    public Transform heroParent = null;
    bool isInvinc;
    float invincibleTime;
    public float MaxInvicibleTime;
    public static PlayerController current;
    
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        AN = GetComponent<Animator>();
        current = this;
    } 
    private void Start()
    {
        heroParent = transform.parent;
        RB.freezeRotation = true;
        LevelController.current.setStartPosition(transform.position);
    }
    void FixedUpdate()
    {
        //[-1, 1]
        float value = Input.GetAxis("Horizontal");
        if (Mathf.Abs(value) > 0)
        {
            Vector2 vel = RB.velocity;
            vel.x = value * speed;
            RB.velocity = vel;
            if (value < 0)
            {
                SR.flipX = true;
            }
            else
            {
                SR.flipX = false;
            }
        }
        if (isInvinc)
        {
            invincibleTime -= Time.deltaTime;
            GetComponent<SpriteRenderer>().material.color =
                new Color(1, 1 - invincibleTime % 1 / 2, 1 - invincibleTime % 1 / 2);
            if (invincibleTime < 0)
            {
                isInvinc = false;
                GetComponent<SpriteRenderer>().material.color =
                    new Color(1, 1, 1);
            }

        }

        AN.SetBool("IsRunning", Mathf.Abs(value) > 0);
    }
    public static void SetNewParent(Transform obj, Transform new_parent)
    {
        if (obj.transform.parent != new_parent)
        {
            //Сохраняем позицию в Глобальных координатах
            Vector3 pos = obj.transform.position;
            //Устанавливаем нового отца
            obj.transform.parent = new_parent;
            //После изменения отца координаты кролика изменятся
            //Поскольку они теперь относительно другого объекта
            //возвращаем кролика в те же глобальные координаты
            obj.transform.position = pos;
        }
    }
    public void makeinvincible()
    {
        isInvinc = true;
        invincibleTime = MaxInvicibleTime;  
    }
}
