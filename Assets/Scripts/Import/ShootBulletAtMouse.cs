using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootBulletAtMouse : MonoBehaviour {

    public Animator anim;
    public GameObject target;
    public GameObject tommybullet;
    public GameObject tommypoint;
    public float tommyshake;
    public AudioClip tommySwap;
    public GameObject pistolbullet;
    public GameObject pistolpoint;
    public float pistolshake;
    public AudioClip pistolSwap;
    public GameObject knifeArea;
    public float knifeshake;
    public AudioClip knifeSwap;
    public float bulletLife;
    public WeaponType type;

	public CamShake shaker;

	//UI 
	public GameObject weapon_image;
	public GameObject weapon_text;
	public Sprite tommy_img;
	public Sprite pistol_img;
	public Sprite knife_img;

    private bool fired;
    private bool locked;
    private bool switched;
    private float cooldown;

	private int tommy_ammo = 60;
	private int pistol_ammo = 12;

    public enum WeaponType
    {
        PISTOL,
        TOMMYGUN,
        KNIFE
    }

	// Use this for initialization
	void Start () {
        locked = true;
	}
	
	// Update is called once per frame
	public void FixedUpdate () {
        cooldown += Time.deltaTime;
		if (Input.GetAxisRaw("Fire1") > 0.01)
        {
            if (type == WeaponType.TOMMYGUN && cooldown > 0.1f && tommy_ammo > 0)
            {
                anim.SetTrigger("TommyTrigger");
                cooldown = 0;
                fired = true;
				shaker.addShake(tommyshake);
                GameObject mybullet = GameObject.Instantiate(tommybullet, tommypoint.transform.position, transform.rotation) as GameObject;
                mybullet.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 30, ForceMode.Impulse);
                Physics.IgnoreCollision(gameObject.GetComponentInChildren<Collider>(), mybullet.GetComponentInChildren<Collider>());
                GameObject.Destroy(mybullet, bulletLife);
                GetComponent<ObservedBehaviour>().firedShot();
				tommy_ammo--;
				weapon_text.GetComponent<Text>().text = "" + tommy_ammo;
            }
            if (type == WeaponType.PISTOL && !fired && pistol_ammo > 0)
            {
                anim.SetTrigger("PistolTrigger");
                fired = true;
				shaker.addShake(pistolshake);
                GameObject mybullet = GameObject.Instantiate(pistolbullet, pistolpoint.transform.position, transform.rotation) as GameObject;
                mybullet.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 40, ForceMode.Impulse);
                Physics.IgnoreCollision(gameObject.GetComponentInChildren<Collider>(), mybullet.GetComponentInChildren<Collider>());
                GameObject.Destroy(mybullet, bulletLife);
                GetComponent<ObservedBehaviour>().firedShot();
				pistol_ammo--;
				weapon_text.GetComponent<Text>().text = "" + pistol_ammo;
				weapon_image.GetComponent<Image>().sprite = pistol_img;
            }
            if (type == WeaponType.KNIFE && !fired)
            {
                anim.SetTrigger("KnifeTrigger");
                fired = true;
				shaker.addShake(knifeshake);
                GameObject myknife = GameObject.Instantiate(knifeArea, transform.position + Vector3.up + transform.forward, transform.rotation) as GameObject;
                Physics.IgnoreCollision(gameObject.GetComponentInChildren<Collider>(), myknife.GetComponentInChildren<Collider>());
                GameObject.Destroy(myknife, 0.2f);
                GetComponent<ObservedBehaviour>().swungKnife();
				weapon_text.GetComponent<Text>().text = "";
				weapon_image.GetComponent<Image>().sprite = knife_img;
            }
        }
		if (Input.GetAxisRaw("Fire1") < 0.01)
        {
            fired = false;
        }
		if (Input.GetAxisRaw("Fire2") > 0.01)
        {
            if (!switched && !locked)
            {
                switched = true;
                switch (type)
                {
                    case WeaponType.KNIFE:
                        anim.SetTrigger("KnifeAway");
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().clip = pistolSwap;
                        GetComponent<AudioSource>().Play();
                        type = WeaponType.PISTOL; 
						weapon_text.GetComponent<Text>().text = "" + pistol_ammo;
						weapon_image.GetComponent<Image>().sprite = pistol_img;
						break;
                    case WeaponType.PISTOL:
                        anim.SetTrigger("PistolAway");
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().clip = tommySwap;
                        GetComponent<AudioSource>().Play();
                        type = WeaponType.TOMMYGUN; 
						weapon_image.GetComponent<Image>().sprite = tommy_img;
						weapon_text.GetComponent<Text>().text = "" + tommy_ammo;
						break;
                    case WeaponType.TOMMYGUN:
                        anim.SetTrigger("TommyAway");
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().clip = knifeSwap;
                        GetComponent<AudioSource>().Play();
                        type = WeaponType.KNIFE; 
						weapon_text.GetComponent<Text>().text = "";
						weapon_image.GetComponent<Image>().sprite = knife_img;
						break;
                }
            }
        }
		if (Input.GetAxisRaw("Fire2") < 0.01)
        {
            switched = false;
        }
	}

    public void unlock()
    {
        locked = false;
    }
}
