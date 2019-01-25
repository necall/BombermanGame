
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

public class Bomb : NetworkBehaviour
{
    public AudioClip explosionSound;
    public GameObject explosionPrefab;
    public LayerMask levelMask;
    // This LayerMask makes sure the rays cast to check for free spaces only hits the blocks in the level
    private bool exploded = false;
     //爆炸范围
    [SyncVar]
    private int bombScope = 0;

    [SyncVar]
    private NetworkInstanceId ownerNetid;
    private GameObject _owner = null;
    private GameObject owner {
        get {
            if(_owner != null) {
                return _owner;
            }
            foreach(var player in GameObject.FindGameObjectsWithTag("Player")) {
                if(player.GetComponent<NetworkIdentity>().netId == ownerNetid) {
                    _owner = player;
                    break;
                }
            }
            return _owner;
        }
    }

    public void initBomb(int scope, NetworkInstanceId ownerNetid)
    {
        bombScope = scope;
        this.ownerNetid = ownerNetid;
    }

    // Use this for initialization
    void Start ()
    {
        Invoke ("Explode", 3f); //Call Explode in 3 seconds
    }

    void Explode ()
    {
        //Explosion sound
        AudioSource.PlayClipAtPoint (explosionSound, transform.position);

        //Create a first explosion at the bomb position
        Instantiate (explosionPrefab, transform.position, Quaternion.identity) ;
        //For every direction, start a chain of explosions
        StartCoroutine (CreateExplosions (Vector3.forward, bombScope));
        StartCoroutine (CreateExplosions (Vector3.right, bombScope));
        StartCoroutine (CreateExplosions (Vector3.back, bombScope));
        StartCoroutine (CreateExplosions (Vector3.left, bombScope));

        GetComponent<MeshRenderer> ().enabled = false; //Disable mesh
        exploded = true;
        transform.Find("Collider").gameObject.GetComponent<DisableTriggerOnPlayerExit>().enablePlayerDrop();
        transform.Find ("Collider").gameObject.SetActive (false); //Disable the collider
        owner.GetComponent<Player>().bombExploded();
        Destroy (gameObject, .3f); //Destroy the actual bomb in 0.3 seconds, after all coroutines have finished
        
    }

    public void OnTriggerEnter (Collider other)
    {
        if (!exploded & (other.CompareTag ("Explosion") || other.CompareTag("Dart")))
        { //If not exploded yet and this bomb is hit by an explosion...

            CancelInvoke ("Explode"); //Cancel the already called Explode, else the bomb might explode twice 
            Explode (); //Finally, explode!
        }
    }

    private IEnumerator CreateExplosions (Vector3 direction, int power)
    {
        for (int i = 1; i < bombScope; i++)
        { //The 3 here dictates how far the raycasts will check, in this case 3 tiles far
            RaycastHit hit; //Holds all information about what the raycast hits

            Physics.Raycast (transform.position + new Vector3 (0, .5f, 0), direction, out hit, i, levelMask); //Raycast in the specified direction at i distance, because of the layer mask it'll only hit blocks, not players or bombs

            var hitCollider = hit.collider;
            if(hitCollider && hitCollider.gameObject.CompareTag("Weakwall")) {
                Destroy(hitCollider.gameObject);
            }
            if(!hitCollider || hitCollider.gameObject.CompareTag("Weakwall")) {
                GameObject explosion = Instantiate(explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
                explosion.GetComponent<DestroySelf>().setDir(direction);
                explosion.GetComponent<DestroySelf>().setPower(power);
            }
            if(hitCollider) {
                break;
            }
            yield return new WaitForSeconds (.02f); //Wait 50 milliseconds before checking the next location
        }

    }

    public GameObject getOwner(){
        return this.owner;
    }
}
