using UnityEngine;

/// <summary>
/// �ǂ�MonoBehaviour�N���X���V���O���g���ɂł���ėp�V���O���g�����N���X
/// </summary>
/// <typeparam name="T">���̃N���X���p������N���X�̌^</typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // �ÓI�C���X�^���X�Q��
    private static T _instance;

    // �C���X�^���X���j������Ă��邩�������t���O
    private static bool _isQuitting = false;

    // �V���O���g���C���X�^���X�ɃA�N�Z�X���邽�߂̌��J�v���p�e�B
    public static T Instance
    {
        get
        {
            // �A�v���P�[�V�������I�����Ȃ�V�����C���X�^���X���쐬���Ȃ��悤null��Ԃ�
            if (_isQuitting)
            {
                return null;
            }

            // �C���X�^���X�����݂��Ȃ��ꍇ�A�V�[�����ŒT��
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                // ����ł����݂��Ȃ��ꍇ�́A�V����GameObject���쐬���ăR���|�[�l���g��ǉ�
                if (_instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    _instance = obj.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    // �p���N���X�ŃI�[�o�[���C�h�\�ȉ��z���\�b�h
    protected virtual void Awake()
    {
        if (_instance != null && _instance != this)
        {
            // �C���X�^���X�����ɑ��݂��A���ꂪ���݂̃C���X�^���X�łȂ��ꍇ�A�����j��
            Destroy(gameObject);
            return;
        }

        _instance = this as T;

        // �I�v�V�����F�V�[�����[�h�ԂŃI�u�W�F�N�g������������
        DontDestroyOnLoad(gameObject);
    }

    // �A�v���P�[�V�����I�����̒ǐ�
    protected virtual void OnApplicationQuit()
    {
        _isQuitting = true;
    }

    // �I�u�W�F�N�g�j�����̒ǐ�
    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _isQuitting = true;
        }
    }
}