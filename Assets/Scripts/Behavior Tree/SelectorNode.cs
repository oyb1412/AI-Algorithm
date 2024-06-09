using System.Collections.Generic;

/// <summary>
/// 모든 시퀸스 노드를 평가하는 노드
/// 시퀸스 노드에 추가한 자식 노드를 순서대로 평가를 진행
/// </summary>
public class SelectorNode : INode {

    private List<INode> nodeList;

    public SelectorNode(List<INode> nodeList) {
        this.nodeList = nodeList;
    }
    public INode.NodeState Evaluate() {
        //이곳에서는 실질적으로, 모든 노드를 평가하기만 한다.
        //만약 노드 중 Success나 Running상태의 노드를 발견하면, 
        //그 노드까지 진행하고 멈춘다.
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