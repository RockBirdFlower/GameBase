public class GameManager
{
    private bool _isInit = false;
    public bool IsInit=>_isInit;

    public void Init()
    {
        _isInit = true;
    }
}