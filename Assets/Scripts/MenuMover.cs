using UnityEngine;
using UnityEngine.Events;

public class MenuMover : MonoBehaviour
{
    [SerializeField] private GameObject forwardMenu;
    [SerializeField] private GameObject currentMenu;
    [SerializeField] private GameObject backwardMenu;

    [SerializeField] private UnityEvent onMoveForward;

    public void Forward()
    {
        forwardMenu.SetActive(true);
        backwardMenu.SetActive(false);
        currentMenu.SetActive(false);

        onMoveForward.Invoke();
    }

    public void Backward()
    {
        forwardMenu.SetActive(false);
        backwardMenu.SetActive(true);
        currentMenu.SetActive(false);
    }
}
