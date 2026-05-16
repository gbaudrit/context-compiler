/**
 * Type definitions for pipeline graph data
 */

export interface GraphData {
  pipelines: PipelineNode[];
  stages: StageNode[];
  steps: StepNode[];
  edges: EdgeData[];
}

export interface PipelineNode {
  id: string;
  name: string;
  type: 'pipeline';
  parentId?: string | null;
  stages: string[];
}

export interface StageNode {
  id: string;
  name: string;
  type: 'stage';
  pipelineId: string;
  steps: string[];
}

export interface StepNode {
  id: string;
  name: string;
  type: 'step';
  stageId: string;
  moduleId: string;
  itemId?: string | null;
  status: 'started' | 'completed' | 'failed';
  duration: number;
  startTime?: string | null;
  endTime?: string | null;
  errorMessage?: string | null;
}

export interface EdgeData {
  id: string;
  source: string;
  target: string;
  type: string;
}

export type NodeData = PipelineNode | StageNode | StepNode;

export interface NodeType {
  id: string;
  type: 'pipeline' | 'stage' | 'step';
  data: NodeData;
  position: { x: number; y: number };
}

/**
 * Extended types for React Flow
 */
export interface FlowNode {
  id: string;
  type: 'pipelineNode' | 'stageNode' | 'stepNode';
  data: {
    label: string;
    nodeData: NodeData;
    isCollapsed?: boolean;
  };
  position: { x: number; y: number };
  style?: React.CSSProperties;
}

export interface FlowEdge {
  id: string;
  source: string;
  target: string;
  type?: string;
  style?: React.CSSProperties;
  animated?: boolean;
}

/**
 * Filter types
 */
export interface Filters {
  pipeline?: string;
  phase?: string;
  module?: string;
  item?: string;
}

/**
 * View state
 */
export interface ViewState {
  showPipelineIds: boolean;
  showHierarchy: boolean;
  fitView: boolean;
}

/**
 * Global window type for injected data
 */
declare global {
  interface Window {
    PIPELINE_DATA?: GraphData;
  }
}
