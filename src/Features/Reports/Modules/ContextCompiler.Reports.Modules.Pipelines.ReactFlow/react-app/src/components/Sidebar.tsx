import { useGraphStore, useSelectedNode, useFilterOptions } from '../stores/graphStore';
import type { StepNode } from '../types';

export const Sidebar = () => {
  const selectedNode = useSelectedNode();
  const { filters, setFilter, clearFilters, viewState, setViewState } = useGraphStore();
  const filterOptions = useFilterOptions();

  const handleFilterChange = (filterType: keyof typeof filters, value: string) => {
    setFilter(filterType, value || undefined);
  };

  const renderNodeDetails = () => {
    if (!selectedNode) {
      return (
        <div style={{ padding: '15px', color: '#6b7280' }}>
          <p>Select a node to view details</p>
        </div>
      );
    }

    const nodeData = selectedNode.data.nodeData;

    if (nodeData.type === 'pipeline') {
      return (
        <div style={{ padding: '15px' }}>
          <h3 style={{ margin: '0 0 10px 0', color: '#667eea' }}>📦 Pipeline</h3>
          <div style={{ fontSize: '14px' }}>
            <div><strong>ID:</strong> {nodeData.id}</div>
            <div><strong>Name:</strong> {nodeData.name}</div>
            {nodeData.parentId && (
              <div><strong>Parent:</strong> {nodeData.parentId}</div>
            )}
            <div><strong>Stages:</strong> {nodeData.stages.length}</div>
          </div>
        </div>
      );
    }

    if (nodeData.type === 'stage') {
      return (
        <div style={{ padding: '15px' }}>
          <h3 style={{ margin: '0 0 10px 0', color: '#4facfe' }}>🔷 Stage</h3>
          <div style={{ fontSize: '14px' }}>
            <div><strong>ID:</strong> {nodeData.id}</div>
            <div><strong>Name:</strong> {nodeData.name}</div>
            <div><strong>Pipeline:</strong> {nodeData.pipelineId}</div>
            <div><strong>Steps:</strong> {nodeData.steps.length}</div>
          </div>
        </div>
      );
    }

    if (nodeData.type === 'step') {
      const step = nodeData as StepNode;
      return (
        <div style={{ padding: '15px' }}>
          <h3 style={{ margin: '0 0 10px 0', color: '#3b82f6' }}>○ Step</h3>
          <div style={{ fontSize: '14px' }}>
            <div><strong>Name:</strong> {step.name}</div>
            <div><strong>Module:</strong> {step.moduleId}</div>
            {step.itemId && <div><strong>Item:</strong> {step.itemId}</div>}
            <div>
              <strong>Status:</strong>{' '}
              <span style={{
                color: step.status === 'completed' ? '#10b981' : step.status === 'failed' ? '#ef4444' : '#3b82f6',
                fontWeight: 'bold'
              }}>
                {step.status.toUpperCase()}
              </span>
            </div>
            {step.duration > 0 && (
              <div><strong>Duration:</strong> {step.duration.toFixed(2)}ms</div>
            )}
            {step.startTime && (
              <div><strong>Start:</strong> {new Date(step.startTime).toLocaleTimeString()}</div>
            )}
            {step.endTime && (
              <div><strong>End:</strong> {new Date(step.endTime).toLocaleTimeString()}</div>
            )}
            {step.errorMessage && (
              <div style={{ marginTop: '10px', color: '#ef4444' }}>
                <strong>Error:</strong>
                <div style={{ 
                  background: '#fee2e2', 
                  padding: '8px', 
                  borderRadius: '4px',
                  marginTop: '5px',
                  fontSize: '12px'
                }}>
                  {step.errorMessage}
                </div>
              </div>
            )}
          </div>
        </div>
      );
    }

    return null;
  };

  return (
    <div style={{
      width: '320px',
      height: '100%',
      background: 'white',
      borderLeft: '1px solid #e5e7eb',
      display: 'flex',
      flexDirection: 'column',
      overflow: 'hidden'
    }}>
      {/* Filters Section */}
      <div style={{
        padding: '15px',
        borderBottom: '1px solid #e5e7eb',
        overflowY: 'auto',
        maxHeight: '50%'
      }}>
        <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '15px' }}>
          <h3 style={{ margin: 0, fontSize: '16px' }}>Filters</h3>
          <button
            onClick={clearFilters}
            style={{
              background: 'none',
              border: '1px solid #d1d5db',
              borderRadius: '4px',
              padding: '4px 8px',
              cursor: 'pointer',
              fontSize: '12px'
            }}
          >
            Clear All
          </button>
        </div>

        {/* Pipeline Filter */}
        <div style={{ marginBottom: '12px' }}>
          <label style={{ display: 'block', fontSize: '13px', marginBottom: '4px', fontWeight: '500' }}>
            Pipeline
          </label>
          <select
            value={filters.pipeline || ''}
            onChange={(e) => handleFilterChange('pipeline', e.target.value)}
            style={{
              width: '100%',
              padding: '6px',
              borderRadius: '4px',
              border: '1px solid #d1d5db',
              fontSize: '13px'
            }}
          >
            <option value="">All Pipelines</option>
            {filterOptions.pipelines.map(p => (
              <option key={p} value={p}>{p}</option>
            ))}
          </select>
        </div>

        {/* Phase Filter */}
        <div style={{ marginBottom: '12px' }}>
          <label style={{ display: 'block', fontSize: '13px', marginBottom: '4px', fontWeight: '500' }}>
            Phase
          </label>
          <select
            value={filters.phase || ''}
            onChange={(e) => handleFilterChange('phase', e.target.value)}
            style={{
              width: '100%',
              padding: '6px',
              borderRadius: '4px',
              border: '1px solid #d1d5db',
              fontSize: '13px'
            }}
          >
            <option value="">All Phases</option>
            {filterOptions.phases.map(p => (
              <option key={p} value={p}>{p}</option>
            ))}
          </select>
        </div>

        {/* Module Filter */}
        <div style={{ marginBottom: '12px' }}>
          <label style={{ display: 'block', fontSize: '13px', marginBottom: '4px', fontWeight: '500' }}>
            Module
          </label>
          <select
            value={filters.module || ''}
            onChange={(e) => handleFilterChange('module', e.target.value)}
            style={{
              width: '100%',
              padding: '6px',
              borderRadius: '4px',
              border: '1px solid #d1d5db',
              fontSize: '13px'
            }}
          >
            <option value="">All Modules</option>
            {filterOptions.modules.map(m => (
              <option key={m} value={m}>{m}</option>
            ))}
          </select>
        </div>

        {/* Item Filter */}
        <div style={{ marginBottom: '12px' }}>
          <label style={{ display: 'block', fontSize: '13px', marginBottom: '4px', fontWeight: '500' }}>
            Item
          </label>
          <select
            value={filters.item || ''}
            onChange={(e) => handleFilterChange('item', e.target.value)}
            style={{
              width: '100%',
              padding: '6px',
              borderRadius: '4px',
              border: '1px solid #d1d5db',
              fontSize: '13px'
            }}
          >
            <option value="">All Items</option>
            {filterOptions.items.map(i => (
              <option key={i} value={i}>{i}</option>
            ))}
          </select>
        </div>

        {/* View Options */}
        <div style={{ marginTop: '20px', paddingTop: '15px', borderTop: '1px solid #e5e7eb' }}>
          <h4 style={{ margin: '0 0 10px 0', fontSize: '14px' }}>View Options</h4>

          <label style={{ display: 'flex', alignItems: 'center', marginBottom: '8px', cursor: 'pointer' }}>
            <input
              type="checkbox"
              checked={viewState.showPipelineIds}
              onChange={(e) => setViewState({ showPipelineIds: e.target.checked })}
              style={{ marginRight: '8px' }}
            />
            <span style={{ fontSize: '13px' }}>Show Pipeline IDs</span>
          </label>

          <label style={{ display: 'flex', alignItems: 'center', cursor: 'pointer' }}>
            <input
              type="checkbox"
              checked={viewState.showHierarchy}
              onChange={(e) => setViewState({ showHierarchy: e.target.checked })}
              style={{ marginRight: '8px' }}
            />
            <span style={{ fontSize: '13px' }}>Show Hierarchy Links</span>
          </label>
        </div>
      </div>

      {/* Node Details Section */}
      <div style={{
        flex: 1,
        overflowY: 'auto',
        borderTop: '1px solid #e5e7eb'
      }}>
        <h3 style={{ 
          margin: 0, 
          padding: '15px 15px 10px 15px', 
          fontSize: '16px',
          position: 'sticky',
          top: 0,
          background: 'white',
          borderBottom: '1px solid #f3f4f6'
        }}>
          Node Details
        </h3>
        {renderNodeDetails()}
      </div>
    </div>
  );
};
