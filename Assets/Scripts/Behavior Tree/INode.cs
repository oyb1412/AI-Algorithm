/// <summary>
/// ��� ��� Ŭ������ �����ؾ� �ϴ� �������̽�
/// ���� ����� ���¸� ��ȯ
/// </summary>
public interface INode {
    public enum NodeState {
        Running,
        Success,
        Fail,
    }

    public NodeState Evaluate();
}