using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkedGrabbing : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
    PhotonView m_photonView;
    Rigidbody rb;
    bool isBiengHeld = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Awake()
    {
        m_photonView = GetComponent<PhotonView>();
    }


    void Update() {
        if (isBiengHeld)
        {
            rb.isKinematic = true;
            gameObject.layer = 16;
        }
        else
        {
            rb.isKinematic = false;
            gameObject.layer = 15;

        }
    }
    private void TransferOwnership()
    {
        m_photonView.RequestOwnership();
    }

    public void OnSelectEntered()
    {
          Debug.Log("Grabbed"); 
          m_photonView.RPC("StartNetworkGrabbing", RpcTarget.AllBuffered);
          
          if (m_photonView.Owner == PhotonNetwork.LocalPlayer)
          {
            Debug.Log("We don't request the ownership. Already mine. ");
          }
          TransferOwnership();

    }
    public void OnSelectExited()
    {
        Debug.Log("Released");  
        m_photonView.RPC("StopNetworkGrabbing", RpcTarget.AllBuffered);


    }

   public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
   {
        if (targetView != m_photonView){
            return;
        }
        Debug.Log("Ownership Request for: " + targetView.name+ " from "+ requestingPlayer.NickName);
   }
    public void OnOwnershipTransfered(PhotonView targetView, Player previousPlayer)
   {
        Debug.Log("Ownership Transferred to: " + targetView.name+ " from "+ previousPlayer.NickName);

   }
    public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
   {
   }
    
    [PunRPC]
    public void StartNetworkGrabbing()
    {
        isBiengHeld = true;
   }
   [PunRPC]
   public void StopNetworkGrabbing(){
        isBiengHeld = false;
   }
}
