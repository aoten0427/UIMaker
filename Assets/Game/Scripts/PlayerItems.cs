using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/PlayerItem")]
public class PlayerItems : ScriptableObject
{
    public static readonly string NAME = "PlayerItems";

    public List<PlayerItem> items = new List<PlayerItem>();

    [System.Serializable]
    public class PlayerItem
    {
        public enum ItemType
        {
            NormalAttack
        }

        [SerializeField]
        ItemType item;
        [SerializeField]
        GameObject m_object;

        public ItemType Item => item;
        public GameObject Object => m_object;
    }

    public GameObject GetItem(PlayerItem.ItemType item)
    {
        // ���X�g����w�肳�ꂽ�A�C�e���^�C�v�Ɉ�v����A�C�e��������
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Item == item)
            {
                return items[i].Object;
            }
        }

        // ������Ȃ������ꍇ��null��Ԃ�
        Debug.LogWarning($"�A�C�e�� '{item}' ��������܂���ł����B");
        return null;
    }
}
