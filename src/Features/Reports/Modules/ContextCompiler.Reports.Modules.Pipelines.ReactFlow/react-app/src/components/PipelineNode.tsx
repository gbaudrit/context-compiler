import { memo } from 'react';
import { Handle, Position } from 'reactflow';
import type { PipelineNode } from '../types';
import { useGraphStore } from '../stores/graphStore';

interface PipelineNodeProps {
  data: {
    label: string;
    nodeData: PipelineNode;
    isCollapsed?: boolean;
  };
  id: string;
}

export const PipelineNodeComponent = memo(({ data, id }: PipelineNodeProps) => {
  const { toggleNodeCollapse, selectNode } = useGraphStore();
  const hasChildren = data.nodeData.stages.length > 0;

  const handleClick = () => {
    selectNode(id);
  };

  const handleToggleCollapse = (e: React.MouseEvent) => {
    e.stopPropagation();
    toggleNodeCollapse(id);
  };

  return (
    <div
      onClick={handleClick}
      style={{
        padding: '20px',
        borderRadius: '12px',
        background: 'linear-gradient(135deg, #667eea 0%, #764ba2 100%)',
        color: 'white',
        border: '3px solid #5a67d8',
        minWidth: '350px',
        cursor: 'pointer',
        boxShadow: '0 8px 16px rgba(102, 126, 234, 0.3)',
        transition: 'all 0.2s ease',
      }}
      onMouseEnter={(e) => {
        e.currentTarget.style.transform = 'scale(1.02)';
        e.currentTarget.style.boxShadow = '0 12px 24px rgba(102, 126, 234, 0.4)';
      }}
      onMouseLeave={(e) => {
        e.currentTarget.style.transform = 'scale(1)';
        e.currentTarget.style.boxShadow = '0 8px 16px rgba(102, 126, 234, 0.3)';
      }}
    >
      <Handle type="target" position={Position.Left} style={{ background: '#5a67d8', width: 12, height: 12 }} />

      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
        <div style={{ flex: 1 }}>
          <div style={{ fontSize: '16px', fontWeight: 'bold', marginBottom: '6px', display: 'flex', alignItems: 'center', gap: '8px' }}>
            <span style={{ fontSize: '20px' }}>📦</span>
            <span>Pipeline</span>
          </div>
          <div style={{ fontSize: '14px', opacity: 0.95, fontWeight: '500' }}>
            {data.label}
          </div>
        </div>

        {hasChildren && (
          <button
            onClick={handleToggleCollapse}
            style={{
              background: 'rgba(255,255,255,0.25)',
              border: '1px solid rgba(255,255,255,0.3)',
              borderRadius: '6px',
              color: 'white',
              padding: '6px 12px',
              cursor: 'pointer',
              fontSize: '18px',
              transition: 'all 0.2s ease',
            }}
            onMouseEnter={(e) => {
              e.currentTarget.style.background = 'rgba(255,255,255,0.35)';
            }}
            onMouseLeave={(e) => {
              e.currentTarget.style.background = 'rgba(255,255,255,0.25)';
            }}
          >
            {data.isCollapsed ? '▶' : '▼'}
          </button>
        )}
      </div>

      {data.nodeData.parentId && (
        <div style={{ fontSize: '11px', marginTop: '8px', opacity: 0.85, paddingTop: '8px', borderTop: '1px solid rgba(255,255,255,0.2)' }}>
          <strong>Parent:</strong> {data.nodeData.parentId}
        </div>
      )}

      <Handle type="source" position={Position.Right} style={{ background: '#5a67d8', width: 12, height: 12 }} />
    </div>
  );
});

PipelineNodeComponent.displayName = 'PipelineNode';
