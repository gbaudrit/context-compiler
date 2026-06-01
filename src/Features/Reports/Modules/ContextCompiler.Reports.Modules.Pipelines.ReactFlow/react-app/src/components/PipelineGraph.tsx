import { useCallback, useEffect } from 'react';
import ReactFlow, {
  MiniMap,
  Controls,
  Background,
  useNodesState,
  useEdgesState,
  BackgroundVariant,
  Node,
  Edge,
} from 'reactflow';
import 'reactflow/dist/style.css';

import { PipelineNodeComponent } from './PipelineNode';
import { StageNodeComponent } from './StageNode';
import { StepNodeComponent } from './StepNode';
import { useGraphStore, useFilteredNodes, useFilteredEdges } from '../stores/graphStore';
import { calculateLayout } from '../services/layoutService';

const nodeTypes = {
  pipelineNode: PipelineNodeComponent,
  stageNode: StageNodeComponent,
  stepNode: StepNodeComponent,
};

export const PipelineGraph = () => {
  const { 
    rawData, 
    collapsedNodes,
    setNodes: setStoreNodes,
    setEdges: setStoreEdges,
    viewState,
  } = useGraphStore();

  const filteredNodes = useFilteredNodes();
  const filteredEdges = useFilteredEdges();

  const [nodes, setNodes, onNodesChange] = useNodesState([]);
  const [edges, setEdges, onEdgesChange] = useEdgesState([]);

  // Calculate layout when data or collapsed nodes change
  useEffect(() => {
    if (!rawData) return;

    const runLayout = async () => {
      try {
        const { nodes: layoutedNodes, edges: layoutedEdges } = await calculateLayout(
          rawData,
          collapsedNodes
        );

        // Update nodes with collapse state
        const nodesWithCollapseState = layoutedNodes.map(node => ({
          ...node,
          data: {
            ...node.data,
            isCollapsed: collapsedNodes.has(node.id),
          },
        }));

        setStoreNodes(nodesWithCollapseState);
        setStoreEdges(layoutedEdges);
      } catch (error) {
        console.error('Failed to calculate layout:', error);
      }
    };

    runLayout();
  }, [rawData, collapsedNodes, setStoreNodes, setStoreEdges]);

  // Update React Flow nodes and edges when store changes
  useEffect(() => {
    setNodes(filteredNodes as Node[]);
    setEdges(filteredEdges as Edge[]);
  }, [filteredNodes, filteredEdges, setNodes, setEdges]);

  // Fit view when requested
  useEffect(() => {
    if (viewState.fitView && nodes.length > 0) {
      // Trigger fit view through React Flow's API
      // This will be handled by the fitView prop on ReactFlow
    }
  }, [viewState.fitView, nodes]);

  const onNodeClick = useCallback((_event: React.MouseEvent, node: Node) => {
    useGraphStore.getState().selectNode(node.id);
  }, []);

  if (!rawData) {
    return (
      <div style={{ 
        width: '100%', 
        height: '100%', 
        display: 'flex', 
        alignItems: 'center', 
        justifyContent: 'center',
        background: '#f5f5f5'
      }}>
        <div style={{ textAlign: 'center' }}>
          <h2>No Pipeline Data</h2>
          <p>No pipeline data available to visualize.</p>
        </div>
      </div>
    );
  }

  return (
    <div style={{ width: '100%', height: '100%' }}>
      <ReactFlow
        nodes={nodes}
        edges={edges}
        onNodesChange={onNodesChange}
        onEdgesChange={onEdgesChange}
        onNodeClick={onNodeClick}
        nodeTypes={nodeTypes}
        fitView={viewState.fitView}
        minZoom={0.1}
        maxZoom={2}
        defaultEdgeOptions={{
          animated: false,
          style: { stroke: '#b1b1b7', strokeWidth: 2 },
        }}
        // Read-only mode: disable all interactions except zoom/pan/click
        nodesDraggable={false}
        nodesConnectable={false}
        elementsSelectable={true}
        selectNodesOnDrag={false}
      >
        <Background variant={BackgroundVariant.Dots} gap={16} size={1} />
        <Controls />
        <MiniMap 
          nodeColor={(node) => {
            if (node.type === 'pipelineNode') return '#667eea';
            if (node.type === 'stageNode') return '#4facfe';
            return '#93c5fd';
          }}
          style={{
            background: '#f5f5f5',
            border: '1px solid #ddd',
          }}
        />
      </ReactFlow>
    </div>
  );
};
