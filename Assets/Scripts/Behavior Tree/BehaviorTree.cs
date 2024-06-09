/// <summary>
/// ��� ����� ��Ʈ ���
/// SelectorNode�� �ݺ��ؼ� ���Ѵ�.
/// </summary>
public class BehaviorTree
{
    private INode rootNode;

    public BehaviorTree(INode rootNode) {
        this.rootNode = rootNode;
    }

    public void OnUpdate() {
        rootNode.Evaluate();
    }
}
