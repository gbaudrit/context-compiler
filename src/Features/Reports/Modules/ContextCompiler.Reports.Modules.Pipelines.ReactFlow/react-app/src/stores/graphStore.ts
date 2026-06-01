import { create } from 'zustand';
import type { 
  GraphData, 
  FlowNode, 
  FlowEdge, 
  Filters, 
  ViewState
} from '../types';

interface GraphStore {
  // Data
  rawData: GraphData | null;
  nodes: FlowNode[];
  edges: FlowEdge[];

  // UI State
  selectedNodeId: string | null;
  collapsedNodes: Set<string>;
  filters: Filters;
  viewState: ViewState;

  // Computed
  filteredNodeIds: Set<string> | null;

  // Actions
  loadData: (data: GraphData) => void;
  setNodes: (nodes: FlowNode[]) => void;
  setEdges: (edges: FlowEdge[]) => void;
  selectNode: (nodeId: string | null) => void;
  toggleNodeCollapse: (nodeId: string) => void;
  setFilter: (filterType: keyof Filters, value: string | undefined) => void;
  clearFilters: () => void;
  setViewState: (state: Partial<ViewState>) => void;
  applyFilters: () => void;
}

export const useGraphStore = create<GraphStore>((set, get) => ({
  // Initial state
  rawData: null,
  nodes: [],
  edges: [],
  selectedNodeId: null,
  collapsedNodes: new Set(),
  filters: {},
  viewState: {
    showPipelineIds: false,
    showHierarchy: true,
    fitView: true,
  },
  filteredNodeIds: null,

  // Load raw data from window or API
  loadData: (data: GraphData) => {
    set({ rawData: data });
    // Initial filter application will be done after layout
  },

  setNodes: (nodes: FlowNode[]) => {
    set({ nodes });
  },

  setEdges: (edges: FlowEdge[]) => {
    set({ edges });
  },

  selectNode: (nodeId: string | null) => {
    set({ selectedNodeId: nodeId });
  },

  toggleNodeCollapse: (nodeId: string) => {
    const { collapsedNodes } = get();
    const newCollapsed = new Set(collapsedNodes);

    if (newCollapsed.has(nodeId)) {
      newCollapsed.delete(nodeId);
    } else {
      newCollapsed.add(nodeId);
    }

    set({ collapsedNodes: newCollapsed });
  },

  setFilter: (filterType: keyof Filters, value: string | undefined) => {
    set((state) => ({
      filters: {
        ...state.filters,
        [filterType]: value,
      },
    }));

    // Apply filters after setting
    get().applyFilters();
  },

  clearFilters: () => {
    set({ filters: {}, filteredNodeIds: null });
  },

  setViewState: (state: Partial<ViewState>) => {
    set((prevState) => ({
      viewState: {
        ...prevState.viewState,
        ...state,
      },
    }));
  },

  applyFilters: () => {
    const { rawData, filters } = get();

    if (!rawData) {
      set({ filteredNodeIds: null });
      return;
    }

    // If no filters, show all nodes
    if (Object.keys(filters).length === 0 || Object.values(filters).every(v => !v)) {
      set({ filteredNodeIds: null });
      return;
    }

    const matchingNodeIds = new Set<string>();

    // Filter pipelines
    let matchingPipelines = rawData.pipelines;
    if (filters.pipeline) {
      matchingPipelines = matchingPipelines.filter(p => p.id === filters.pipeline);
    }

    // Add matching pipeline nodes
    matchingPipelines.forEach(p => matchingNodeIds.add(p.id));

    // Filter stages
    let matchingStages = rawData.stages.filter(s => 
      matchingPipelines.some(p => p.id === s.pipelineId)
    );

    if (filters.phase) {
      matchingStages = matchingStages.filter(s => s.name === filters.phase);
    }

    matchingStages.forEach(s => matchingNodeIds.add(s.id));

    // Filter steps
    let matchingSteps = rawData.steps.filter(s => 
      matchingStages.some(st => st.id === s.stageId)
    );

    if (filters.module) {
      matchingSteps = matchingSteps.filter(s => s.moduleId === filters.module);
    }

    if (filters.item) {
      matchingSteps = matchingSteps.filter(s => s.itemId === filters.item);
    }

    matchingSteps.forEach(s => matchingNodeIds.add(s.id));

    set({ filteredNodeIds: matchingNodeIds });
  },
}));

// Selector helpers
export const useSelectedNode = () => {
  const { selectedNodeId, nodes } = useGraphStore();
  return nodes.find(n => n.id === selectedNodeId);
};

export const useFilteredNodes = () => {
  const { nodes, filteredNodeIds } = useGraphStore();

  if (filteredNodeIds === null) {
    return nodes;
  }

  return nodes.filter(n => filteredNodeIds.has(n.id));
};

export const useFilteredEdges = () => {
  const { edges, filteredNodeIds } = useGraphStore();

  if (filteredNodeIds === null) {
    return edges;
  }

  // Only show edges where both source and target are in filtered nodes
  return edges.filter(e => 
    filteredNodeIds.has(e.source) && filteredNodeIds.has(e.target)
  );
};

// Helper to get unique values for filters
export const useFilterOptions = () => {
  const rawData = useGraphStore(state => state.rawData);

  if (!rawData) {
    return { pipelines: [], phases: [], modules: [], items: [] };
  }

  const pipelines = Array.from(new Set(rawData.pipelines.map(p => p.id))).sort();
  const phases = Array.from(new Set(rawData.stages.map(s => s.name))).sort();
  const modules = Array.from(new Set(rawData.steps.map(s => s.moduleId))).sort();
  const items = Array.from(new Set(rawData.steps.map(s => s.itemId).filter(Boolean) as string[])).sort();

  return { pipelines, phases, modules, items };
};
