using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Camera cam;
    public GameObject[] prefabElements;
    public GameObject prefabPlayer;
    public GameObject prefabEnemmy;
    public GameObject prefabSpell;
    public GameObject prefabEpee;
    public bool isCastingMegaSpell = false;
    public bool hasASpellTime;


    public SpellScriptableObject[] spellBuildActif;

    public SpellScriptableObject[] buildOne;
    public SpellScriptableObject[] buildDeux;
    public SpellScriptableObject[] buildTrois;

    public GameObject newSpell;
    public Vector3 prefabPLayerForward;

    public DammageEffectScript dammageEffectScript;
    public SlowEffectScript slowEffectScript;
    public BlinkEffectScript blinkEffectScript;
    public DotEffectScript dotEffectScript;
    public HotEffectScript hotEffectScript;
    public DashEffectScript dashEffectScript;

    public float elapsedTime;


    public epeeDetection epeeDetection;

    public Animator epeeAnimator;
    public bool epeecoup;

    public GameObject sphereMegaSpellBody;
    public GameObject rayMegaSpellBody;
    public GameObject coneMegaSpellBody;


    private void Awake()
    {
        hasASpellTime = true;
        instance = this;

    }

    private void Update()
    {
        elapsedTime = Time.deltaTime;
    }

    private void Start()
    {
        epeeAnimator = prefabEpee.GetComponent<Animator>();
        epeecoup = epeeAnimator.GetBool("epeecoup");
    }

    public Vector3 GetMousePos(Transform transform)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Vector3 mousePos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        return mousePos;
    }

    public Vector3 GetMousePosWorld(Transform transform)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Vector3 mousePos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        return mousePos;
    }

    public Vector3 GetMousePosLocal(Transform transform)
    {
        Vector3 mousePosWorld = GetMousePosWorld(transform);

        // �tape 1 : Inversion de la translation
        Vector3 vectorLocalNonTranslate = mousePosWorld - transform.position;

         //�tape 2 : Inversion de la rotation
        Quaternion rotationInverse = Quaternion.Inverse(transform.rotation);
        Vector3 vectorLocalNonRotate = rotationInverse * vectorLocalNonTranslate;

         //�tape 3 : Inversion de l'�chelle
        Vector3 vectorLocalFinal = new Vector3(
            vectorLocalNonRotate.x / transform.localScale.x,
            vectorLocalNonRotate.y / transform.localScale.y,
            vectorLocalNonRotate.z / transform.localScale.z);

        return vectorLocalFinal; 
    }

    public Vector3 InterpolatePoints(Vector3 start, Vector3 end, float f)
    {
        float x = start.x + f * (end.x - start.x);
        float z = start.z + f * (end.z - start.z);

        Vector3 interpolateVector = new Vector3(x,1f,z);

        return interpolateVector;


    }

    public void InstantiateNewSpell(Transform transform)
    {
        newSpell = Instantiate(prefabSpell, transform.position, Quaternion.identity);

    }

    public void ResetElapsedTime ()
    {
        elapsedTime = 0f;
    }



}
