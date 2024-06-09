using System.Collections.Generic;

/// <summary>
/// ��� ������ ��带 ���ϴ� ���
/// ������ ��忡 �߰��� �ڽ� ��带 ������� �򰡸� ����
/// </summary>
public class SelectorNode : INode {

    private List<INode> nodeList;

    public SelectorNode(List<INode> nodeList) {
        this.nodeList = nodeList;
    }
    public INode.NodeState Evaluate() {
        //�̰������� ����������, ��� ��带 ���ϱ⸸ �Ѵ�.
        //���� ��� �� Success�� Running������ ��带 �߰��ϸ�, 
        //�� ������ �����ϰ� �����.
        foreach (var item in nodeList) {
            switch (item.Evaluate()) {
                case INode.NodeState.Running:
                    return INode.NodeState.Running;
                case INode.NodeState.Success:
                    return INode.NodeState.Success;
            }
        }

        return INode.NodeState.Fail;
    }
}