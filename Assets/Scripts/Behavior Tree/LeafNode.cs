using System;

/// <summary>
/// 직접적인 액션을 수행하는 노드
/// 수행할 액션을 매개변수로 받아오고,
/// 이 노드에 도착하면 액션을 수행 후 결과값을 반환
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