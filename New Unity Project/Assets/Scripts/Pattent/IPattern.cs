
public interface IPattern
{
    void OnStart();
    void OnUpdate();
    void OnEnd();

    bool IsTweening();
    int GetTotalBallCount();
}
