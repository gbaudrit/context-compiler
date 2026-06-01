import { memo } from 'react';
import { Handle, Position } from 'reactflow';
import type { StageNode } from '../types';
import { useGraphStore } from '../stores/graphStore';

interface StageNodeProps {
  data: {
    label: string;
    nodeData: StageNode;
    isCollapsed?: boolean;
  };
  id: string;
}

export const StageNodeComponent = memo(({ data, id }: StageNodeProps) => {
  const { toggleNodeCollapse, selectNode } = useGraphStore();
  const hasChildren = data.nodeData.steps.length > 0;

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
        padding: '16px',
        borderRadius: '10px',
        background: 'linear-gradient(135deg, #4facfe 0%, #00f2fe 100%)',
        color: 'white',
        border: '2px solid #3b8bc9',
        minWidth: '280px',
        cursor: 'pointer',
        boxShadow: '0 6px 12px rgba(79, 172, 254, 0.3)',
        transition: 'all 0.2s ease',
      }}
      onMouseEnter={(e) => {
        e.currentTarget.style.transform = 'scale(1.02)';
        e.currentTarget.style.boxShadow = '0 8px 16px rgba(79, 172, 254, 0.4)';
      }}
      onMouseLeave={(e) => {
        e.currentTarget.style.transform = 'scale(1)';
        e.currentTarget.style.boxShadow = '0 6px 12px rgba(79, 172, 254, 0.3)';
      }}
    >
      <Handle type="target" position={Position.Left} style={{ background: '#3b8bc9', width: 10, height: 10 }} />

      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
        <div style={{ flex: 1 }}>
          <div style={{ fontSize: '14px', fontWeight: 'bold', marginBottom: '5px', display: 'flex', alignItems: 'center', gap: '6px' }}>
            <span style={{ fontSize: '16px' }}>🔷</span>
            <span>Stage</span>
          </div>
          <div style={{ fontSize: '13px', opacity: 0.95, fontWeight: '500' }}>
            {data.label}
          </div>
        </div>

        {hasChildren && (
          <button
            onClick={handleToggleCollapse}
            style={{
              background: 'rgba(255,255,255,0.25)',
              border: '1px solid rgba(255,255,255,0.3)',
              borderRadius: '5px',
              color: 'white',
              padding: '5px 10px',
              cursor: 'pointer',
              fontSize: '16px',
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

      <Handle type="source" position={Position.Right} style={{ background: '#3b8bc9', width: 10, height: 10 }} />
    </div>
  );
});

StageNodeComponent.displayName = 'StageNode';
