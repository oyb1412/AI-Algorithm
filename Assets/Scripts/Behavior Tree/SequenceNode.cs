using System.Collections.Generic;

/// <summary>
/// 모든 자식 액션 노드를 평가하는 노드
/// 모든 자식노드가 성공해야 성공을 반환
/// 만약 자식노드가 Running중이라면, 다시 한번 더 그 자식노드를 실행해야한다.
/// </summary>
public class SequenceNode : INode {

    List<INode> nodeList;

    public SequenceNode(List<INode> nodeList) {
        this.nodeList = nodeList;
    }

    public INode.NodeState Evaluate() {
        if(nodeList == null || nodeList.Count == 0)
             return INode.NodeState.Fail;

        //자식 LeafNode중 Running상태인 노드가 있다면, 진행을 멈춘다. 
        //즉 그 노드의 Running상태가 바뀔 때 까지 그 노드만 지속적으로 평가한다.

        //자식 LeafNode중 Fail상태인 노드가 있다면, 진행을 멈춘다.

        //모든 자식LeafNode가 Success상태일 경우에만 현재 SequenceNode의 평가를 종료하고
        //다음 SequenceNode를 평가한다.
        foreach(var item in nodeList) {
            switch(item.Evaluate()) {
                case INode.NodeState.Running:
                    return INode.NodeState.Running;
                case INode.NodeState.Success:
                    continue;
                case INode.NodeState.Fail:
                    return INode.NodeState.Fail;
            }
        }

        return INode.NodeState.Success;
    }
}