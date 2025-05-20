using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public Image selectIcon;
    public TMP_Text description;
    public Transform rightPanelTransform;
    public GameObject itemButtonPrefab;

    public void OnOpen()
    {
        for (int a = rightPanelTransform.childCount - 1; a >= 0; a--)
        {
            Destroy(rightPanelTransform.GetChild(a).gameObject);
        }
        for (int i = 0; i < InventoryManager.instance.inventoryList.Count; i++)
        {
            GameObject itemButtonObj = Instantiate(itemButtonPrefab, rightPanelTransform);
            ItemButton itemButtonCom = itemButtonObj.GetComponent<ItemButton>();
            itemButtonCom.data = InventoryManager.instance.inventoryList[i];
            itemButtonCom.icon.sprite = itemButtonCom.data.icon;
            Button button = itemButtonCom.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                selectIcon.sprite = itemButtonCom.data.icon;
                description.text = itemButtonCom.data.description;
            });
        }
    }
}
