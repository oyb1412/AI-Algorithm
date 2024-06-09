using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour {
    private Player player;
    private BehaviorTree bt;
    private void Awake() {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void Start() {
        bt = new BehaviorTree(SettingBT());
    }

    private void Update() {
        bt.OnUpdate();
    }

    INode SettingBT() {
        return new SelectorNode
        (
            new List<INode>()
            {
            new SequenceNode
            (
                new List<INode>()
                {
                    new LeafNode(CheckDistance),
                    new LeafNode(Movement),
                }
            ),
             new SequenceNode
            (
                new List<INode>()
                {
                    new LeafNode(Idle),
                }
            ),
            }
        );
    }

    private INode.NodeState CheckDistance() {
        if (Vector2.Distance(transform.position, player.transform.position) < 5f)
            return INode.NodeState.Fail;

        return INode.NodeState.Success;
    }

    private INode.NodeState Movement() {
        if (Vector2.Distance(transform.position, player.transform.position) > 1f) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 4f);
            return INode.NodeState.Running;
        }

        return INode.NodeState.Success;
    }

    private INode.NodeState Idle() {
        return INode.NodeState.Success;
    }
}