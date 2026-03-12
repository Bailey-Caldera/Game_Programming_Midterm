using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 12f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float attackRange = 15f;
    public float attackCooldown = 3f;

    private Transform player;
    private SkinnedMeshRenderer[] meshRenderers;
    private Material[][] mats;
    private Color[][] originalColors;
    private bool canAttack = true;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>(true);

        mats = new Material[meshRenderers.Length][];
        originalColors = new Color[meshRenderers.Length][];

        for (int i = 0; i < meshRenderers.Length; i++)
        {
            mats[i] = meshRenderers[i].materials;
            originalColors[i] = new Color[mats[i].Length];

            for (int j = 0; j < mats[i].Length; j++)
            {
                if (mats[i][j].HasProperty("_BaseColor"))
                    originalColors[i][j] = mats[i][j].GetColor("_BaseColor");
                else if (mats[i][j].HasProperty("_Color"))
                    originalColors[i][j] = mats[i][j].GetColor("_Color");
            }
        }
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if (direction.magnitude > attackRange)
        {
            transform.position += direction.normalized * moveSpeed * Time.deltaTime;
            transform.forward = direction.normalized;
        }
        else if (canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;

        for (int i = 0; i < 2; i++)
        {
            SetFlashColor(Color.red);
            yield return new WaitForSeconds(0.15f);

            ResetColors();
            yield return new WaitForSeconds(0.15f);
        }

        Vector3 direction = player.position - firePoint.position;
        direction.y = 0f;
        direction.Normalize();

        Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    void SetFlashColor(Color color)
    {
        for (int i = 0; i < mats.Length; i++)
        {
            for (int j = 0; j < mats[i].Length; j++)
            {
                if (mats[i][j].HasProperty("_BaseColor"))
                    mats[i][j].SetColor("_BaseColor", color);
                else if (mats[i][j].HasProperty("_Color"))
                    mats[i][j].SetColor("_Color", color);
            }
        }
    }

    void ResetColors()
    {
        for (int i = 0; i < mats.Length; i++)
        {
            for (int j = 0; j < mats[i].Length; j++)
            {
                if (mats[i][j].HasProperty("_BaseColor"))
                    mats[i][j].SetColor("_BaseColor", originalColors[i][j]);
                else if (mats[i][j].HasProperty("_Color"))
                    mats[i][j].SetColor("_Color", originalColors[i][j]);
            }
        }
    }
}