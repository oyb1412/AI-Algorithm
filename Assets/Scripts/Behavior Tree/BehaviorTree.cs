/// <summary>
/// 모든 노드의 루트 노드
/// SelectorNode를 반복해서 평가한다.
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
