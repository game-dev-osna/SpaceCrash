using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformHyperDriveCollision : MonoBehaviour
{
    [SerializeField]
    private HypDriRejectCollision manager;

    private void resetToPosition(GameObject pos, Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

        // pause
        // record the ball's current velocity make it pause/float mid-air
        Vector3 savedPauseVelocity = rb.velocity;
        Vector3 savedPauseAngularVelocity = rb.angularVelocity;
        if (rb.isKinematic == false)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        rb.useGravity = false;
        rb.isKinematic = true;

        // unpause
        // to fix that prob where changing iskinematic can make the balls appear to drag, deactivate then
        // activate the ball which seems to fix it
        other.gameObject.SetActive(false);
        other.gameObject.transform.position = pos.transform.position;
        other.gameObject.transform.rotation = pos.transform.rotation;
        other.gameObject.SetActive(true);
        rb.useGravity = true;

        rb.isKinematic = false;
        rb.velocity = savedPauseVelocity;
        rb.angularVelocity = savedPauseAngularVelocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<QuestItem>() != null)
        {
            if (other.gameObject.GetComponent<QuestItem>().QuestItemName == "HyperdriveReplacementCapsule")
            {
                resetToPosition(manager.PosCapsule, other);
            }
            else if (other.gameObject.GetComponent<QuestItem>().QuestItemName == "HyperdriveReplacementBox")
            {
                resetToPosition(manager.PosBox, other);
            }
            else if (other.gameObject.GetComponent<QuestItem>().QuestItemName == "HyperdriveReplacementCylinder")
            {
                resetToPosition(manager.PosCylinder, other);
            }
        }
    }
}
