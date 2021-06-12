using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.Characters.ThirdPerson;

public class ControlMyPlayer : MonoBehaviourPun
{
    [SerializeField] private PhotonView phView;
    [SerializeField] private ThirdPersonUserControl userControl;
    [SerializeField] private ThirdPersonCharacter character;

    private void Start()
    {
        phView = GetComponent<PhotonView>(); 
        userControl = GetComponent<ThirdPersonUserControl>();
        character = GetComponent<ThirdPersonCharacter>();

        if (phView.IsMine)
        {
            gameObject.tag = "Player";
        }
        else
        {
            Destroy(userControl);
            Destroy(character);
            Destroy(this);
        }
    }
}
        