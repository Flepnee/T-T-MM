using UnityEngine;
using UnityEngine.UI;

public class BuildingSelector : MonoBehaviour
{
    public Button[] buttons;
    public int selectedIndex = 1; 

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    void OnButtonClick(int index)
    {
        selectedIndex = index;
    }
}
