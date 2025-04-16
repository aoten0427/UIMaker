using UnityEngine;

/// <summary>
/// どのMonoBehaviourクラスもシングルトンにできる汎用シングルトン基底クラス
/// </summary>
/// <typeparam name="T">このクラスを継承するクラスの型</typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // 静的インスタンス参照
    private static T _instance;

    // インスタンスが破棄されているかを示すフラグ
    private static bool _isQuitting = false;

    // シングルトンインスタンスにアクセスするための公開プロパティ
    public static T Instance
    {
        get
        {
            // アプリケーションが終了中なら新しいインスタンスを作成しないようnullを返す
            if (_isQuitting)
            {
                return null;
            }

            // インスタンスが存在しない場合、シーン内で探す
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                // それでも存在しない場合は、新しいGameObjectを作成してコンポーネントを追加
                if (_instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    _instance = obj.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    // 継承クラスでオーバーライド可能な仮想メソッド
    protected virtual void Awake()
    {
        if (_instance != null && _instance != this)
        {
            // インスタンスが既に存在し、それが現在のインスタンスでない場合、これを破棄
            Destroy(gameObject);
            return;
        }

        _instance = this as T;

        // オプション：シーンロード間でオブジェクトを持続させる
        DontDestroyOnLoad(gameObject);
    }

    // アプリケーション終了時の追跡
    protected virtual void OnApplicationQuit()
    {
        _isQuitting = true;
    }

    // オブジェクト破棄時の追跡
    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _isQuitting = true;
        }
    }
}