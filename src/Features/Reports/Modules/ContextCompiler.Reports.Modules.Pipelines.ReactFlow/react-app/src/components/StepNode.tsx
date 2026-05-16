import { memo } from 'react';
import { Handle, Position } from 'reactflow';
import type { StepNode } from '../types';
import { useGraphStore } from '../stores/graphStore';

interface StepNodeProps {
  data: {
    label: string;
    nodeData: StepNode;
  };
  id: string;
}

const STATUS_STYLES = {
  started: {
    background: 'linear-gradient(135deg, #93c5fd 0%, #60a5fa 100%)',
    border: '2px solid #3b82f6',
    color: '#1e3a8a',
  },
  completed: {
    background: 'linear-gradient(135deg, #86efac 0%, #22c55e 100%)',
    border: '2px solid #16a34a',
    color: '#14532d',
  },
  failed: {
    background: 'linear-gradient(135deg, #fca5a5 0%, #ef4444 100%)',
    border: '2px solid #dc2626',
    color: '#7f1d1d',
  },
};

export const StepNodeComponent = memo(({ data, id }: StepNodeProps) => {
  const { selectNode } = useGraphStore();
  const status = data.nodeData.status;
  const style = STATUS_STYLES[status];

  const handleClick = () => {
    selectNode(id);
  };

  return (
    <div
      onClick={handleClick}
      style={{
        padding: '14px',
        borderRadius: '8px',
        ...style,
        minWidth: '230px',
        cursor: 'pointer',
        boxShadow: '0 4px 8px rgba(0,0,0,0.15)',
        transition: 'all 0.2s ease',
      }}
      onMouseEnter={(e) => {
        e.currentTarget.style.transform = 'scale(1.03)';
        e.currentTarget.style.boxShadow = '0 6px 12px rgba(0,0,0,0.2)';
      }}
      onMouseLeave={(e) => {
        e.currentTarget.style.transform = 'scale(1)';
        e.currentTarget.style.boxShadow = '0 4px 8px rgba(0,0,0,0.15)';
      }}
    >
      <Handle type="target" position={Position.Left} style={{ background: style.border.split(' ')[2], width: 8, height: 8 }} />

      <div style={{ fontSize: '13px', fontWeight: 'bold', marginBottom: '4px', display: 'flex', alignItems: 'center', gap: '6px' }}>
        <span style={{ fontSize: '16px' }}>
          {status === 'completed' ? '✓' : status === 'failed' ? '✗' : '○'}
        </span>
        <span>{data.nodeData.name}</span>
      </div>

      <div style={{ fontSize: '11px', opacity: 0.85, fontWeight: '500' }}>
        {data.nodeData.moduleId}
      </div>

      {data.nodeData.itemId && (
        <div style={{ fontSize: '10px', opacity: 0.75, marginTop: '4px', paddingTop: '4px', borderTop: `1px solid ${style.color}33` }}>
          <strong>Item:</strong> {data.nodeData.itemId.split('/').pop()}
        </div>
      )}

      {status === 'completed' && data.nodeData.duration > 0 && (
        <div style={{ fontSize: '11px', fontWeight: 'bold', marginTop: '4px', display: 'inline-block', background: 'rgba(0,0,0,0.1)', padding: '2px 6px', borderRadius: '4px' }}>
          ⏱️ {data.nodeData.duration.toFixed(0)}ms
        </div>
      )}

      {status === 'failed' && data.nodeData.errorMessage && (
        <div style={{ 
          fontSize: '10px', 
          color: '#991b1b', 
          marginTop: '4px',
          maxWidth: '200px',
          overflow: 'hidden',
          textOverflow: 'ellipsis',
          whiteSpace: 'nowrap',
          background: 'rgba(255,255,255,0.5)',
          padding: '4px 6px',
          borderRadius: '4px',
        }}>
          ⚠️ {data.nodeData.errorMessage}
        </div>
      )}

      <Handle type="source" position={Position.Right} style={{ background: style.border.split(' ')[2], width: 8, height: 8 }} />
    </div>
  );
});

StepNodeComponent.displayName = 'StepNode';
