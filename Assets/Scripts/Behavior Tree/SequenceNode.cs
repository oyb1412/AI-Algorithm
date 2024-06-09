using System.Collections.Generic;

/// <summary>
/// ��� �ڽ� �׼� ��带 ���ϴ� ���
/// ��� �ڽĳ�尡 �����ؾ� ������ ��ȯ
/// ���� �ڽĳ�尡 Running���̶��, �ٽ� �ѹ� �� �� �ڽĳ�带 �����ؾ��Ѵ�.
/// </summary>
public class SequenceNode : INode {

    List<INode> nodeList;

    public SequenceNode(List<INode> nodeList) {
        this.nodeList = nodeList;
    }

    public INode.NodeState Evaluate() {
        if(nodeList == null || nodeList.Count == 0)
             return INode.NodeState.Fail;

        //�ڽ� LeafNode�� Running������ ��尡 �ִٸ�, ������ �����. 
        //�� �� ����� Running���°� �ٲ� �� ���� �� ��常 ���������� ���Ѵ�.

        //�ڽ� LeafNode�� Fail������ ��尡 �ִٸ�, ������ �����.

        //��� �ڽ�LeafNode�� Success������ ��쿡�� ���� SequenceNode�� �򰡸� �����ϰ�
        //���� SequenceNode�� ���Ѵ�.
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