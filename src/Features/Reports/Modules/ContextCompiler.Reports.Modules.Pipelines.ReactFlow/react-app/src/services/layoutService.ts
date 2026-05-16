import type { GraphData, FlowNode, FlowEdge } from '../types';

const NODE_DIMENSIONS = {
  pipeline: { width: 400, height: 100 },
  stage: { width: 300, height: 80 },
  step: { width: 250, height: 70 },
};

const SPACING = {
  horizontal: 200,
  verticalPipeline: 350,
  verticalStage: 150,
  verticalStep: 120,
};

interface LayoutResult {
  nodes: FlowNode[];
  edges: FlowEdge[];
}

function createHierarchicalLayout(data: GraphData, collapsedNodes: Set<string>): LayoutResult {
  const nodes: FlowNode[] = [];
  const edges: FlowEdge[] = [];
  let currentY = 50;
  const rootPipelines = data.pipelines.filter(p => !p.parentId);
  const childPipelines = data.pipelines.filter(p => p.parentId);

  rootPipelines.forEach((pipeline) => {
    const pipelineX = 100;
    const pipelineY = currentY;
    nodes.push({ id: pipeline.id, type: 'pipelineNode', data: { label: pipeline.name, nodeData: pipeline, isCollapsed: collapsedNodes.has(pipeline.id) }, position: { x: pipelineX, y: pipelineY } });
    if (!collapsedNodes.has(pipeline.id)) {
      const pipelineStages = data.stages.filter(s => s.pipelineId === pipeline.id);
      let maxStageHeight = 0;
      pipelineStages.forEach((stage, stageIndex) => {
        const stageX = pipelineX + (stageIndex * (NODE_DIMENSIONS.stage.width + SPACING.horizontal));
        const stageY = pipelineY + SPACING.verticalStage;
        nodes.push({ id: stage.id, type: 'stageNode', data: { label: stage.name, nodeData: stage, isCollapsed: collapsedNodes.has(stage.id) }, position: { x: stageX, y: stageY } });
        if (!collapsedNodes.has(stage.id)) {
          const stageSteps = data.steps.filter(s => s.stageId === stage.id);
          stageSteps.forEach((step, stepIndex) => {
            const stepX = stageX + (stepIndex * (NODE_DIMENSIONS.step.width + SPACING.horizontal / 2));
            const stepY = stageY + SPACING.verticalStep;
            nodes.push({ id: step.id, type: 'stepNode', data: { label: step.name, nodeData: step }, position: { x: stepX, y: stepY } });
          });
          const stageHeight = SPACING.verticalStep + NODE_DIMENSIONS.step.height;
          maxStageHeight = Math.max(maxStageHeight, stageHeight);
        }
      });
      currentY += SPACING.verticalPipeline + maxStageHeight;
    } else {
      currentY += NODE_DIMENSIONS.pipeline.height + 100;
    }
  });

  childPipelines.forEach((pipeline, index) => {
    const pipelineX = 100 + (index * (NODE_DIMENSIONS.pipeline.width + SPACING.horizontal));
    const pipelineY = currentY;
    nodes.push({ id: pipeline.id, type: 'pipelineNode', data: { label: pipeline.name, nodeData: pipeline, isCollapsed: collapsedNodes.has(pipeline.id) }, position: { x: pipelineX, y: pipelineY } });
    if (!collapsedNodes.has(pipeline.id)) {
      const pipelineStages = data.stages.filter(s => s.pipelineId === pipeline.id);
      pipelineStages.forEach((stage, stageIndex) => {
        const stageX = pipelineX + (stageIndex * (NODE_DIMENSIONS.stage.width + SPACING.horizontal));
        const stageY = pipelineY + SPACING.verticalStage;
        nodes.push({ id: stage.id, type: 'stageNode', data: { label: stage.name, nodeData: stage, isCollapsed: collapsedNodes.has(stage.id) }, position: { x: stageX, y: stageY } });
        if (!collapsedNodes.has(stage.id)) {
          const stageSteps = data.steps.filter(s => s.stageId === stage.id);
          stageSteps.forEach((step, stepIndex) => {
            const stepX = stageX + (stepIndex * (NODE_DIMENSIONS.step.width + SPACING.horizontal / 2));
            const stepY = stageY + SPACING.verticalStep;
            nodes.push({ id: step.id, type: 'stepNode', data: { label: step.name, nodeData: step }, position: { x: stepX, y: stepY } });
          });
        }
      });
    }
  });

  data.edges.forEach(edge => {
    const sourceNode = nodes.find(n => n.id === edge.source);
    const targetNode = nodes.find(n => n.id === edge.target);
    if (sourceNode && targetNode) {
      let edgeStyle: any = { stroke: '#b1b1b7', strokeWidth: 2 };
      let edgeType = 'smoothstep';
      let animated = false;
      if (edge.type === 'pipeline-to-pipeline') { edgeStyle = { stroke: '#667eea', strokeWidth: 3, strokeDasharray: '5,5' }; }
      else if (edge.type === 'pipeline-to-stage') { edgeStyle = { stroke: '#4facfe', strokeWidth: 2.5 }; edgeType = 'step'; }
      else if (edge.type === 'stage-to-stage') { edgeStyle = { stroke: '#06b6d4', strokeWidth: 2 }; }
      else if (edge.type === 'stage-to-step') { edgeStyle = { stroke: '#93c5fd', strokeWidth: 2 }; edgeType = 'step'; }
      else if (edge.type === 'step-to-step') { edgeStyle = { stroke: '#d1d5db', strokeWidth: 1.5 }; }
      edges.push({ id: edge.id, source: edge.source, target: edge.target, type: edgeType, animated, style: edgeStyle });
    }
  });
  return { nodes, edges };
}

export async function calculateLayout(data: GraphData, collapsedNodes: Set<string> = new Set()): Promise<LayoutResult> {
  try { return createHierarchicalLayout(data, collapsedNodes); }
  catch (error) { console.error('Layout calculation failed:', error); const nodes: FlowNode[] = []; let yOffset = 0; data.pipelines.forEach(pipeline => { nodes.push({ id: pipeline.id, type: 'pipelineNode', data: { label: pipeline.name, nodeData: pipeline }, position: { x: 0, y: yOffset } }); yOffset += 150; }); return { nodes, edges: [] }; }
}

export async function recalculatePartialLayout(data: GraphData, _changedNodeIds: string[], _currentNodes: FlowNode[], collapsedNodes: Set<string>): Promise<LayoutResult> {
  return calculateLayout(data, collapsedNodes);
}
