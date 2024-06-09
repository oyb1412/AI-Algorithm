/// <summary>
/// 모든 노드 클래스가 구현해야 하는 인터페이스
/// 현재 노드의 상태를 반환
/// </summary>
public interface INode {
    public enum NodeState {
        Running,
        Success,
        Fail,
    }

    public NodeState Evaluate();
}