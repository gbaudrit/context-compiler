import { useMemo, useCallback } from 'react';
import { useGraphStore } from '../stores/graphStore';
import type { FlowNode } from '../types';

/**
 * Performance optimization utilities for React Flow
 */

/**
 * Memoized node computation to avoid unnecessary re-renders
 */
export const useOptimizedNodes = () => {
  const nodes = useGraphStore(state => state.nodes);
  const filteredNodeIds = useGraphStore(state => state.filteredNodeIds);

  return useMemo(() => {
    if (!filteredNodeIds) return nodes;
    return nodes.filter(n => filteredNodeIds.has(n.id));
  }, [nodes, filteredNodeIds]);
};

/**
 * Memoized edge computation
 */
export const useOptimizedEdges = () => {
  const edges = useGraphStore(state => state.edges);
  const filteredNodeIds = useGraphStore(state => state.filteredNodeIds);

  return useMemo(() => {
    if (!filteredNodeIds) return edges;
    return edges.filter(e => 
      filteredNodeIds.has(e.source) && filteredNodeIds.has(e.target)
    );
  }, [edges, filteredNodeIds]);
};

/**
 * Memoized node click handler
 */
export const useNodeClickHandler = () => {
  return useCallback((nodeId: string) => {
    useGraphStore.getState().selectNode(nodeId);
  }, []);
};

/**
 * Memoized collapse toggle handler
 */
export const useCollapseToggleHandler = () => {
  return useCallback((nodeId: string) => {
    useGraphStore.getState().toggleNodeCollapse(nodeId);
  }, []);
};

/**
 * Virtualization helper: Only render nodes in viewport
 */
export const useViewportNodes = (
  allNodes: FlowNode[],
  viewport: { x: number; y: number; zoom: number },
  viewportWidth: number,
  viewportHeight: number
) => {
  return useMemo(() => {
    // Calculate visible area with some padding
    const padding = 200;
    const visibleArea = {
      x: -viewport.x / viewport.zoom - padding,
      y: -viewport.y / viewport.zoom - padding,
      width: viewportWidth / viewport.zoom + padding * 2,
      height: viewportHeight / viewport.zoom + padding * 2,
    };

    // Filter nodes that are in or near the visible area
    return allNodes.filter(node => {
      const nodeRight = node.position.x + 300; // approximate max node width
      const nodeBottom = node.position.y + 100; // approximate max node height

      return (
        node.position.x < visibleArea.x + visibleArea.width &&
        nodeRight > visibleArea.x &&
        node.position.y < visibleArea.y + visibleArea.height &&
        nodeBottom > visibleArea.y
      );
    });
  }, [allNodes, viewport, viewportWidth, viewportHeight]);
};

/**
 * Debounced filter application
 */
export const useDebouncedFilter = (delay: number = 300) => {
  let timeoutId: number;

  return useCallback((filterFn: () => void) => {
    clearTimeout(timeoutId);
    timeoutId = setTimeout(filterFn, delay) as unknown as number;
  }, [delay]);
};

/**
 * Compute statistics efficiently
 */
export const useGraphStats = () => {
  const rawData = useGraphStore(state => state.rawData);

  return useMemo(() => {
    if (!rawData) {
      return {
        totalPipelines: 0,
        totalStages: 0,
        totalSteps: 0,
        completedSteps: 0,
        failedSteps: 0,
        totalDuration: 0,
      };
    }

    const completedSteps = rawData.steps.filter(s => s.status === 'completed').length;
    const failedSteps = rawData.steps.filter(s => s.status === 'failed').length;
    const totalDuration = rawData.steps.reduce((sum, s) => sum + s.duration, 0);

    return {
      totalPipelines: rawData.pipelines.length,
      totalStages: rawData.stages.length,
      totalSteps: rawData.steps.length,
      completedSteps,
      failedSteps,
      totalDuration,
    };
  }, [rawData]);
};

/**
 * Batch node updates to reduce re-renders
 */
export const useBatchNodeUpdates = () => {
  let updateQueue: Array<() => void> = [];
  let isScheduled = false;

  const flush = useCallback(() => {
    if (updateQueue.length === 0) return;

    // Apply all updates in a single batch
    const updates = [...updateQueue];
    updateQueue = [];
    isScheduled = false;

    updates.forEach(update => update());
  }, []);

  const schedule = useCallback((update: () => void) => {
    updateQueue.push(update);

    if (!isScheduled) {
      isScheduled = true;
      requestAnimationFrame(flush);
    }
  }, [flush]);

  return schedule;
};
