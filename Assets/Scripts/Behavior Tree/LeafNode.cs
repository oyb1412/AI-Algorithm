using System;

/// <summary>
/// �������� �׼��� �����ϴ� ���
/// ������ �׼��� �Ű������� �޾ƿ���,
/// �� ��忡 �����ϸ� �׼��� ���� �� ������� ��ȯ
/// </summary>
public class LeafNode : INode {

    Func<INode.NodeState> onUpdate = null;

    public LeafNode(Func<INode.NodeState> onUpdate) {
        this.onUpdate = onUpdate;
    }

    public INode.NodeState Evaluate() {
        return onUpdate?.Invoke() ?? INode.NodeState.Fail;
    }
}