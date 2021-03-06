using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemShooter : MonoBehaviour
{
    public float force;

    protected Collider2D succCollider;
    protected Collider2D catcherCollider;
    protected Collider2D playerCollider;
    
    protected ItemInventory inventory;

    protected Controls controls;

    protected void Start() {
        inventory = GetComponent<ItemInventory>();
        controls = GetComponentInParent<Controls>();
        succCollider = GetComponent<Collider2D>();
        playerCollider = controls.GetComponent<Collider2D>();
        ItemCatcher catcher = GetComponentInChildren<ItemCatcher>();
        catcherCollider = catcher.GetComponent<Collider2D>();
    }

    public void ShootDown() {
        GameObject projectile = inventory.Pop();
        if(projectile == null) return;
        Collider2D projCollider = projectile.GetComponent<Collider2D>();
        Rigidbody2D projBody = projectile.GetComponent<Rigidbody2D>();
        SpriteRenderer projRenderer = projectile.GetComponent<SpriteRenderer>();
        //Physics2D.IgnoreCollision(catcherCollider, projCollider);
        projBody.velocity = Vector3.zero;
        projectile.transform.position = transform.position + (Vector3)controls.Direction;
        projRenderer.color = Color.cyan;
        projectile.SetActive(true);
        projBody.AddForce(controls.Direction * force);
    }
}

